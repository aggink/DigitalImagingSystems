using DIS.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.SpatialFiltering
{
    public static class LinearFiltering
    {
        public static (Image bmp, double time) ApplyFilter(Image image, double[,] matrix, int row, int col)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            Bitmap bmp = new Bitmap(image);
            int width = bmp.Width;
            int height = bmp.Height;

            //шаг от центрального пикселя
            int r_hor = (col - 1) / 2;
            int r_ver = (row - 1) / 2;

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            //создаем массив, где будут хранится новое изображение
            byte[] New_rgb = new byte[bytes];

            //позиция крайних пикселей на изображении
            int limit_y = height - 1;
            int limit_x = width - 1;

            Parallel.For(0, rgb.Length / 3, index =>
            {
                //координата пикселя
                int i = index / width;
                int j = index % width;

                //задаем ограничения для взаимодействия с матрицей, чтоб центр матрицы совпал с теккущим положением пикселя
                int start_i1 = i - r_ver;
                int start_j1 = j - r_hor;
                int stop_i1 = i + r_ver;
                int stop_j1 = j + r_hor;

                double sum_r = 0, sum_g = 0, sum_b = 0;
                //проверка на крайниые пиксели
                if (start_i1 < 0 || start_j1 < 0 || stop_i1 >= height || stop_j1 >= width)
                {
                    //B(x, y) = Sum(F(i, j)*f(x + i, y + j))
                    for (int i1 = start_i1, y = 0; i1 <= stop_i1; ++i1, ++y)
                    {
                        for (int j1 = start_j1, x = 0; j1 <= stop_j1; ++j1, ++x)
                        {
                            //если выходит за края, то зеркалим пиксели
                            int pix_i = i1;
                            if (i1 < 0) pix_i = i1 * -1;
                            if (i1 >= height) pix_i = limit_y - (i1 - limit_y);

                            int pix_j = j1;
                            if (j1 < 0) pix_j = j1 * -1;
                            if (j1 >= width) pix_j = limit_x - (j1 - limit_x);

                            int pos_pixR = (pix_i * width + pix_j) * 3;
                            sum_r += matrix[y, x] * rgb[pos_pixR];
                            sum_g += matrix[y, x] * rgb[pos_pixR + 1];
                            sum_b += matrix[y, x] * rgb[pos_pixR + 2];
                        }
                    }
                }
                else
                {
                    //B(x, y) = Sum(F(i, j)*f(x + i, y + j))
                    for (int i1 = start_i1, y = 0; i1 <= stop_i1; ++i1, ++y)
                    {
                        for (int j1 = start_j1, x = 0; j1 <= stop_j1; ++j1, ++x)
                        { 
                            int pos_pixR = (i1 * width + j1) * 3;
                            sum_r += matrix[y, x] * rgb[pos_pixR];
                            sum_g += matrix[y, x] * rgb[pos_pixR + 1];
                            sum_b += matrix[y, x] * rgb[pos_pixR + 2];
                        }
                    }
                }

                //сохраняем изменения
                int pos_r = index * 3;
                New_rgb[pos_r] = (byte)WorkImage.Clamp(sum_r, 0, 255);
                New_rgb[pos_r + 1] = (byte)WorkImage.Clamp(sum_g, 0, 255);
                New_rgb[pos_r + 2] = (byte)WorkImage.Clamp(sum_b, 0, 255);
            });

            System.Runtime.InteropServices.Marshal.Copy(New_rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //останавливаем таймер
            sWatch.Stop();

            //возвращаем картинку к исходному размеру
            return (bmp, sWatch.ElapsedMilliseconds);
        }
    }
}
