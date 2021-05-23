using DIS.Algorithm;
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
    public class MedianFiltering
    {
        public static (Image bmp, double time) ApplyFilter(Image image, int row, int col)
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

            //размер матрицы
            int matrixLenght = row * col;
            //позиция элемента по середине матрицы
            int matrix_posk = matrixLenght / 2;
            //позиция последнего элемента
            int matrix_poslast = matrixLenght - 1;

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

                //создаем массивы для поиска медианы
                int[] matrix_r = new int[matrixLenght];
                int[] matrix_g = new int[matrixLenght];
                int[] matrix_b = new int[matrixLenght];
                int x = 0;

                //проверка на крайниые пиксели
                if (start_i1 < 0 || start_j1 < 0 || stop_i1 >= height || stop_j1 >= width)
                {
                    for (int i1 = start_i1; i1 <= stop_i1; ++i1)
                    {
                        for (int j1 = start_j1; j1 <= stop_j1; ++j1)
                        {
                            //если выходит за края, то зеркалим пиксели
                            int pix_i = i1;
                            if (i1 < 0) pix_i = i1 * -1;
                            if (i1 >= height) pix_i = limit_y - (i1 - limit_y);

                            int pix_j = j1;
                            if (j1 < 0) pix_j = j1 * -1;
                            if (j1 >= width) pix_j = limit_x - (j1 - limit_x);

                            int pos_pixR = (pix_i * width + pix_j) * 3;
                            matrix_b[x] = rgb[pos_pixR];
                            matrix_g[x] = rgb[pos_pixR + 1];
                            matrix_r[x] = rgb[pos_pixR + 2];
                            ++x;
                        }
                    }
                }
                else
                {
                    for (int i1 = start_i1; i1 <= stop_i1; ++i1)
                    {
                        for (int j1 = start_j1; j1 <= stop_j1; ++j1)
                        {
                            int pos_pixR = (i1 * width + j1) * 3;
                            matrix_b[x] = rgb[pos_pixR];
                            matrix_g[x] = rgb[pos_pixR + 1];
                            matrix_r[x] = rgb[pos_pixR + 2];
                            ++x;
                        }
                    }
                }

                //сохраняем изменения
                int pos_r = index * 3;
                New_rgb[pos_r] = (byte)QuickSelect.kthSmallest(matrix_b, 0, matrix_poslast, matrix_posk);
                New_rgb[pos_r + 1] = (byte)QuickSelect.kthSmallest(matrix_g, 0, matrix_poslast, matrix_posk);
                New_rgb[pos_r + 2] = (byte)QuickSelect.kthSmallest(matrix_r, 0, matrix_poslast, matrix_posk);
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
