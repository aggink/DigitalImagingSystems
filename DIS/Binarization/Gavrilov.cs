using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DIS.Binarization
{
    public class Gavrilov
    {
        //1 - пограничный белый, 2 - черный
        public static Image Binarization(Image image, int Color = 0)
        {
            Bitmap bmp = new Bitmap(image);

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] rgb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgb, 0, bytes);

            float[] I_pixel = new float[rgb.Length / 3];
            Parallel.For(0, rgb.Length / 3, i =>
            {
               I_pixel[i] = 0.2125f * rgb[i * 3] + 0.7154f * rgb[i * 3 + 1] + 0.0721f * rgb[i * 3 + 2];
            });

            float I_sum = I_pixel.Sum();
            float t = I_sum / (bmp.Width * bmp.Height);

            //выбор изменения пограничного пикселя <= t или < t
            switch (Color)
            {
                case 0:
                    //формируем выходное изображение
                    Parallel.For(0, rgb.Length / 3, i =>
                    {
                        if (I_pixel[i] <= t)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
                case 255:
                    //формируем выходное изображение
                    Parallel.For(0, rgb.Length / 3, i =>
                    {
                        if (I_pixel[i] < t)
                        {
                            rgb[i * 3] = 0;
                            rgb[i * 3 + 1] = 0;
                            rgb[i * 3 + 2] = 0;
                        }
                        else
                        {
                            rgb[i * 3] = 255;
                            rgb[i * 3 + 1] = 255;
                            rgb[i * 3 + 2] = 255;
                        }
                    });
                    break;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //возвращаем картинку к исходному размеру
            return bmp;
        }
    }
}
