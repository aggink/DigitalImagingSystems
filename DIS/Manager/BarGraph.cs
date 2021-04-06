using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Manager
{
    //класс для построения гистограммы изображения
    public static class BarGraph
    {
        //по x - уровни яркости пикселей
        //по y - количество пикселей
        private static DataTable table = null;
        public static readonly string col1 = "bightness";
        public static readonly string col2 = "count";
        public static DataTable BuildBarGraph(Image image)
        {
            if (table == null)
            {
                //создаем таблицу с двемя столбцами
                table = new DataTable("BarGraph");
                table.Columns.Add(col1, typeof(int));
                table.Columns.Add(col2, typeof(int));
                //заполняем строки
                for (int i = 0; i < 256; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i;
                    row[1] = 0;
                    table.Rows.Add(row);
                }
            }
            else
            {
                //обнуляем данные
                for(int i = 0; i < 256; i++)
                {
                    table.Rows[i][1] = 0;
                }
            }
            //открываем изображения для чтения
            Bitmap bmp = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] argb = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, argb, 0, bytes);

            for (int i = 0; i < bytes; i = i + 4)
            {
                int color = (argb[i] + argb[i + 1] + argb[i + 2]) / 3;
                table.Rows[color][1] = (int)table.Rows[color][1] + 1;
            }

            bmp.UnlockBits(bmpData);
            bmp.Dispose();
            return table;
        }
    }
}
