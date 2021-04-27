using DIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
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
            Bitmap Vimg = new Bitmap(value.image);
            Image img = SetImgChannelValue(Vimg, value.Transparency, value.R, value.G, value.B);
            //подгоняем изображение под один размер
            this.image =  new Bitmap(img, this.size);
            //очищаем память
            img.Dispose();
            Vimg.Dispose();
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
        //градационные преобразования
        public static (Image, DataTable) GradationTransform((Image image, int width, int heigth) img, List<int> values, string col1, string col2)
        {
            int initial_width = img.image.Width;
            int initial_heigth = img.image.Height;

            //создаем таблицу для построения гистограммы
            DataTable table = new DataTable("BarGraph");
            table.Columns.Add(col1, typeof(int));
            table.Columns.Add(col2, typeof(int));

            Bitmap bmp;
            //изменяем размеры изображения
            if (initial_width == img.width && initial_heigth == img.heigth)
            {
                //если исходный формат изображения совпадает с заданным
                bmp = new Bitmap(img.image);
            }
            else
            {
                //иначе приводим к указанному размеру
                bmp = new Bitmap(img.image, new Size(img.width, img.heigth));
            }
            
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapData = bmp.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr intPtr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
            byte[] argb = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(intPtr, argb, 0, bytes);

            Parallel.For(0, argb.Length, (Action<int>)(i => argb[i] = (byte)Clamp(values[argb[i]], 0, 255)));
            int[] n = new int[256];
            Parallel.For(0, argb.Length / 3, (Action<int>)(i => Interlocked.Increment(ref n[(int)((double)((int)argb[i * 3] + (int)argb[i * 3 + 1] + (int)argb[i * 3 + 2]) / 3.0)])));

            for (int i = 0; i < 256; i++)
            {
                DataRow row = table.NewRow();
                row[0] = i;
                row[1] = n[i];
                table.Rows.Add(row);
            }

            System.Runtime.InteropServices.Marshal.Copy(argb, 0, intPtr, bytes);
            bmp.UnlockBits(bitmapData);

            //возвращыем исходные размеры изображения
            if(initial_width == img.width && initial_heigth == img.heigth)
            {
                //если исходный формат изображения совпадает с заданным
                return (bmp, table);
            }

            //иначе возвращаем исходные размеры изображению
            Bitmap bmp_return = new Bitmap(bmp, new Size(initial_width, initial_heigth));
            bmp.Dispose();
            return (bmp_return, table);
        }

        //приводим изображение к градациям серого
        public static Image ConvertToGrayscale(Image img)
        {
            Bitmap image = new Bitmap(img);
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics gfxPic = Graphics.FromImage(bmp);
            ColorMatrix cmxPic = new ColorMatrix();
            cmxPic.Matrix00 = 0.2125f;
            cmxPic.Matrix01 = 0.2125f;
            cmxPic.Matrix02 = 0.2125f;

            cmxPic.Matrix10 = 0.7154f;
            cmxPic.Matrix11 = 0.7154f;
            cmxPic.Matrix12 = 0.7154f;

            cmxPic.Matrix20 = 0.0721f;
            cmxPic.Matrix21 = 0.0721f;
            cmxPic.Matrix22 = 0.0721f;

            ImageAttributes iaPic = new ImageAttributes();
            iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            gfxPic.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, iaPic);
            gfxPic.Dispose();
            iaPic.Dispose();
            image.Dispose();
            return bmp;
        }
    }
}
