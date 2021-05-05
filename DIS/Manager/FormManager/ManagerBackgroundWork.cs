using DIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DIS.Manager
{
    //класс для выполнения запросов в отдельном потоке
    public static class ManagerBackgroundWork
    {
        public static List<Layer> layers;

        public static ProgressBar progressBar = null;
        public static Chart chart = null;
        public static Button Button_Save = null;
        public static Button Button_Unite = null;
        public static Button Button_AddChanges = null;
        public static PictureBox MainImage = null;
        public static BackgroundWorker backgroundWork = null;
        public static Panel panel = null;
        public static Label L_SizeImage = null;
        public static Label L_Time = null;

        public static double time = 0;
        private const string textTime = "Время обработки изображения: ";
        private const string textSizeImage = "Размер изображения: ";

        //обработка при завершении операции, ее остановке или ошибки
        public static void CompletedProcess(object sender, RunWorkerCompletedEventArgs e)
        {
            //ошибка при асинхронной операции
            if(e.Error != null)
            {
                ManagerError.ErrorOK(e.Error.Message);
                return;
            }
            //при отмене асинхронной операции
            if (e.Cancelled)
            {
                ManagerError.ErrorOK("Обработка изображений остановленна");
                return;
            }
            //при успешном завершении
            if (layers.Any())
            {
                //показатель обработки изображения
                progressBar.Value = 100;

                //запуск для построения гистограммы
                chart.DataSource = BarGraph.BuildBarGraph(MainImage.Image);
                chart.DataBind();
            }
            //открываем доступ к кнопкам
            Button_Save.Enabled = true;
            Button_Unite.Enabled = true;
            Button_AddChanges.Enabled = true;

            //выводим время обработки и инфу о размере картинки
            L_SizeImage.Text = textSizeImage + MainImage.Image.Width.ToString() + " x " + MainImage.Height.ToString();
            L_Time.Text = textTime + time + " мс.";
            L_Time.Visible = true;
            L_SizeImage.Visible = true;
        }
        //настройка прогресс-бара
        public static void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //устанавливаем процент выполнения асинхронной операции
            progressBar.Value = e.ProgressPercentage;
        }
        //обработка запроса в другом потоке
        public static void Work(object sender, DoWorkEventArgs e)
        {
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            List<LayerValue> layerValues = (List<LayerValue>)e.Argument;
            //выполняем слияние картинок
            if (layerValues.Any())
            {
                //определяем размеры самой большой картинки
                int heigth = layerValues.Max(x => x.image.Height);
                int wigth = layerValues.Max(x => x.image.Width);
                
                //создаем объект для наложения картинок
                WorkImage result = new WorkImage(layerValues[0], wigth, heigth);

                //вызываем функцию для обработки всех изображений
                for(int i = 1; i < layerValues.Count; i++)
                {
                    result.MergeImages(layerValues[i]);
                    //обновление прогресса обработки в другом потоке
                    backgroundWork.ReportProgress((int)((float)(layers.Count - 1.0 - i) / (layers.Count - 1.0) * 100.0));
                }

                //выводим результат
                if (MainImage.Image != null) MainImage.Image.Dispose();
                MainImage.Image = (Image)result.image.Clone();

                //заменяем начальное изображение для градационных преобразований
                if((panel.Controls[0] as MyCanvas).Image != null) (panel.Controls[0] as MyCanvas).Image.Dispose();
                (panel.Controls[0] as MyCanvas).Image = (Image)result.image.Clone();

                result.image.Dispose();

                //останавливаем таймер и получаем время
                sWatch.Stop();
                time = sWatch.ElapsedMilliseconds;
            }
        }
    }
}
