using DIS.Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DIS.Filtration.Frequency
{
    public class FourierImage : GeneralOperation
    {
        //Визуализация Фурье-образа и фильтра на нем 
        public static Image GetImage((Complex[] r, Complex[] g, Complex[] b) rgb, int Width, int Height, double Brightness)
        {
            Bitmap bmp = new Bitmap(Width, Height);

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] argb = new byte[bytes];


            //double[] G_r = new double[Height * Width];
            //double[] G_g = new double[Height * Width];
            //double[] G_b = new double[Height * Width];
            //Parallel.For(0, Height * Width, index =>
            //{
            //    G_r[index] = Math.Log(rgb.r[index].Magnitude + 1, Math.E);
            //    G_g[index] = Math.Log(rgb.g[index].Magnitude + 1, Math.E);
            //    G_b[index] = Math.Log(rgb.b[index].Magnitude + 1, Math.E);
            //});
            //
            //double m_r = G_r.Max() * 100;
            //double m_g = G_g.Max() * 100;
            //double m_b = G_b.Max() * 100;
            Parallel.For(0, Width * Height, index =>
            {
                int real = index * 4;
                //argb[real] = (byte)Clamp(G_b[index] * m_b, 0, 255);
                //argb[real + 1] = (byte)Clamp(G_g[index] * m_g, 0, 255);
                //argb[real + 2] = (byte)Clamp(G_r[index] * m_r, 0, 255);
                argb[real] = (byte)Clamp(rgb.b[index].Magnitude * 120, 0, 255);
                argb[real + 1] = (byte)Clamp(rgb.g[index].Magnitude * 120, 0, 255);
                argb[real + 2] = (byte)Clamp(rgb.r[index].Magnitude * 120, 0, 255);
                argb[real + 3] = 255;
            });
            
            System.Runtime.InteropServices.Marshal.Copy(argb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            return bmp;
        }
        //наложение фильтров на фурье-образ
        public static Image AddFilter(Image image, List<Filter> filters)
        {
             using (Graphics gr = Graphics.FromImage(image))
             {
                 foreach (var it in filters)
                 {
                     int x1 = it.x - it.r1 / 2;
                     int y1 = it.y - it.r1 / 2;

                     gr.DrawEllipse(Pens.Red, new RectangleF(x1, y1, it.r1, it.r1));

                     int x2 = it.x - it.r2 / 2;
                     int y2 = it.y - it.r2 / 2;

                     gr.DrawEllipse(Pens.Red, new RectangleF(x2, y2, it.r2, it.r2));
                 }
             }
            return image;
        }
    }
}
