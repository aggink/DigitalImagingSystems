using DIS.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Manager
{
    //класс для обработки изображений
    public class WorkImage
    {
        //результат обработки изображений
        public Bitmap image { get; private set; } = null;
        //размеры картинки
        private readonly Size size;
        public WorkImage(LayerValue value, int width, int heigth)
        {
            //устанавливаем максимальный размеры картинки
            this.size = new Size(width, heigth);
            //редактируем изображение
            Image img = SetImgChannelValue(value.image, value.Transparency, value.R, value.G, value.B);
            //подгоняем изображение под один размер
            this.image =  new Bitmap(img, this.size);
            //очищаем память
            img.Dispose();
        }
        //функция для слияния двух картинок
        public void MergeImages(LayerValue value)
        {
            //редактируем изображение
            Image img = SetImgChannelValue(value.image, value.Transparency, value.R, value.G, value.B);
            //подгоняем изображение под один размер
            Bitmap imgWork = new Bitmap(img, this.size);
            //очищаем память
            img.Dispose();

            //Переменная содержит набор из четырех целых чисел, определяющих расположение и размер прямоугольника.
            Rectangle rect = new Rectangle(0, 0, this.size.Width, this.size.Height);

            //Блокирует объект Bitmap в системной памяти.
            BitmapData bmpData_Result = this.image.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            BitmapData bmpData_Add = imgWork.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            //Возвращает или задает адрес данных первого пикселя в точечном рисунке. 
            //Также под этим можно понимать первую строку развертки в точечном рисунке.
            IntPtr ptr_Result = bmpData_Result.Scan0;
            IntPtr ptr_Add = bmpData_Add.Scan0;

            //Объявите массив для хранения байтов растрового изображения.
            //Stride Возвращает или задает ширину шага по индексу (также называемую шириной развертки) объекта Bitmap.
            int bytes = Math.Abs(bmpData_Result.Stride) * this.size.Height;
            byte[] Result_argb = new byte[bytes];
            byte[] Add_argb = new byte[bytes];

            //Скопируйте значения ARGB в массив.
            //Marshal.Copy Копирует данные из управляемого массива в указатель неуправляемой памяти 
            //или из указателя неуправляемой памяти в управляемый массив
            System.Runtime.InteropServices.Marshal.Copy(ptr_Result, Result_argb, 0, bytes);
            System.Runtime.InteropServices.Marshal.Copy(ptr_Add, Add_argb, 0, bytes);

            //выполянем операцию
            ChangeBytes(Result_argb, Add_argb, bytes, value.TypeOperation);

            // Копируем значения ARGB обратно в растровое изображение
            System.Runtime.InteropServices.Marshal.Copy(Result_argb, 0, ptr_Result, bytes);

            // Разблокировать биты.
            this.image.UnlockBits(bmpData_Result);
            imgWork.UnlockBits(bmpData_Add);

            imgWork.Dispose();
        }
        //операция над байтами
        private void ChangeBytes(byte[] argbValues, byte[] WorkArgb, int count, int action)
        {
            double nW = 0, nR = 0;
            for (int i = 0; i < count; i = i + 4)
            {
                switch (action)
                {
                    //нет эффекта
                    case 0:
                        break;

                    //вычисление попиксельно суммы двух изображений
                    case 1:
                        nR = argbValues[i + 3] / 255.0;
                        nW = WorkArgb[i + 3] / 255.0;
                        argbValues[i + 3] = (byte)Clamp(argbValues[i + 3] + WorkArgb[i + 3], 0, 255);
                        argbValues[i + 2] = (byte)Clamp(argbValues[i + 2] * nR + WorkArgb[i + 2] * nW, 0, 255);
                        argbValues[i + 1] = (byte)Clamp(argbValues[i + 1] * nR + WorkArgb[i + 1] * nW, 0, 255);
                        argbValues[i] = (byte)Clamp(argbValues[i] * nR + WorkArgb[i] * nW, 0, 255);
                        break;

                    //вычисление попиксельно среднего арифметического двух изображений
                    case 2:
                        nR = argbValues[i + 3] / 255.0;
                        nW = WorkArgb[i + 3] / 255.0;
                        argbValues[i + 3] = (byte)Clamp(argbValues[i + 3] + WorkArgb[i + 3], 0, 255);
                        argbValues[i + 2] = (byte)Clamp((argbValues[i + 2] * nR + WorkArgb[i + 2] * nW) / 2.0, 0, 255);
                        argbValues[i + 1] = (byte)Clamp((argbValues[i + 1] * nR + WorkArgb[i + 1] * nW) / 2.0, 0, 255);
                        argbValues[i] = (byte)Clamp((argbValues[i] * nR + WorkArgb[i] * nW) / 2.0, 0, 255);
                        break;

                    //вычисление попиксельно максимума двух изображений
                    case 3:
                        nR = argbValues[i + 3] / 255.0;
                        nW = WorkArgb[i + 3] / 255.0;
                        argbValues[i + 3] = (byte)Clamp(argbValues[i + 3] + WorkArgb[i + 3], 0, 255);
                        argbValues[i + 2] = (byte)Clamp(Math.Max(argbValues[i + 2] * nR, WorkArgb[i + 2] * nW), 0, 255);
                        argbValues[i + 1] = (byte)Clamp(Math.Max(argbValues[i + 1] * nR, WorkArgb[i + 1] * nW), 0, 255);
                        argbValues[i] = (byte)Clamp(Math.Max(argbValues[i] * nR, WorkArgb[i] * nW), 0, 255);
                        break;

                    //вычисление попиксельно минимума двух изображений
                    case 4:
                        nR = argbValues[i + 3] / 255.0;
                        nW = WorkArgb[i + 3] / 255.0;
                        argbValues[i + 3] = (byte)Clamp(argbValues[i + 3] + WorkArgb[i + 3], 0, 255);
                        argbValues[i + 2] = (byte)Clamp(Math.Min(argbValues[i + 2] * nR, WorkArgb[i + 2] * nW), 0, 255);
                        argbValues[i + 1] = (byte)Clamp(Math.Min(argbValues[i + 1] * nR, WorkArgb[i + 1] * nW), 0, 255);
                        argbValues[i] = (byte)Clamp(Math.Min(argbValues[i] * nR, WorkArgb[i] * nW), 0, 255);
                        break;

                    //вычисление попиксельно произведения двух изображений
                    case 5:
                        nR = argbValues[i + 3] / 255.0;
                        nW = WorkArgb[i + 3] / 255.0;
                        argbValues[i + 3] = (byte)Clamp(argbValues[i + 3] + WorkArgb[i + 3], 0, 255);
                        argbValues[i + 2] = (byte)Clamp(argbValues[i + 2] * nR * (1 - nW) + argbValues[i + 2] * nR * WorkArgb[i + 2] * nW / 255.0, 0, 255);
                        argbValues[i + 1] = (byte)Clamp(argbValues[i + 1] * nR * (1 - nW) + argbValues[i + 1] * nR * WorkArgb[i + 1] * nW / 255.0, 0, 255);
                        argbValues[i] = (byte)Clamp(argbValues[i] * nR * (1 - nW) + argbValues[i] * WorkArgb[i] * nR * nW / 255.0, 0, 255);
            break;
                    default:
                        break;
                }
            }
        }
        private static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        //изменение изображения опираясь на цветовые каналы rgba
        public static Image SetImgChannelValue(Image img, float tran, int R = 1, int G = 1, int B = 1)
        {
            //создаем bitmap для работы с изображением
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //создаем объект graphics
            Graphics graphics = Graphics.FromImage(bmp);
            //создаем объект матрицы цвета RGBAW
            ColorMatrix colorMatrix = new ColorMatrix()
            {
                Matrix00 = R,
                Matrix11 = G,
                Matrix22 = B,
                Matrix33 = tran
            };
            //создаем объект, который будет содержаить сведения о том, каким образом обрабатываются цвета точечных рисунков и метафайлов во время отрисовки.
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //отрисовываем изображения по заданным свойствам
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
            //очищаем память
            graphics.Dispose();
            imageAttributes.Dispose();
            return bmp;
        }
    }
}
