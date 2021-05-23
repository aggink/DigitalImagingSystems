using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Filtration
{
    public class BMP : IDisposable
    {
        public Bitmap bmp { get; private set; }
        public BitmapData bitmapData { get; private set; }
        public IntPtr intPtr { get; private set; }
        public int bytes { get; private set; }
        public byte[] argb { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Сhannels { get; private set; } 
        public BMP(int width, int height)
        {
            this.bmp = new Bitmap(width, height);
            this.Width = bmp.Width;
            this.Height = bmp.Height;

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, width, height);
            this.bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            this.Сhannels = 4;

            this.intPtr = bitmapData.Scan0;
            this.bytes = Math.Abs(bitmapData.Stride) * height;

            this.argb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, argb, 0, bytes);
        }
        public BMP(Image image)
        {
            this.bmp = new Bitmap(image);
            this.Width = bmp.Width;
            this.Height = bmp.Height;

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            this.bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            this.Сhannels = 4;

            this.intPtr = bitmapData.Scan0;
            this.bytes = Math.Abs(bitmapData.Stride) * Height;

            this.argb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, argb, 0, bytes);
        }
        public BMP(Image image, int Width, int Height)
        {
            this.bmp = new Bitmap(image, new Size(Width, Height));
            this.Width = Width;
            this.Height = Height;

            //создаем байтовый массив
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            this.bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            this.Сhannels = 4;

            this.intPtr = bitmapData.Scan0;
            this.bytes = Math.Abs(bitmapData.Stride) * Height;

            this.argb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, argb, 0, bytes);
        }
        public void Save()
        {
            System.Runtime.InteropServices.Marshal.Copy(argb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);
        }
        public void Save(byte[] rgb)
        {
            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);
        }

        public void Dispose()
        {
            bmp.Dispose();
        }
    }
}
