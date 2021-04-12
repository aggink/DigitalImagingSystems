using DIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Manager
{
    //класс для выполнения запросов в отдельном потоке
    public static class BackgroundWork
    {
        public static List<Layer> layers;
        public static Form1 form;
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
                form.progressBar1.Value = 100;

                //запуск для построения гистограммы
                form.chart1.DataSource = BarGraph.BuildBarGraph(form.pictureBox1.Image);
                form.chart1.DataBind();
            }
            //открываем доступ к кнопкам
            form.button2.Enabled = true;
            form.button3.Enabled = true;
        }
        //настройка прогресс-бара
        public static void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //устанавливаем процент выполнения асинхронной операции
            form.progressBar1.Value = e.ProgressPercentage;
        }
        //обработка запроса в другом потоке
        public static void Work(object sender, DoWorkEventArgs e)
        {
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
                    form.backgroundWorker1.ReportProgress((int)((float)(layers.Count - 1.0 - i) / (layers.Count - 1.0) * 100.0));
                }
                //выводим результат
                if (form.pictureBox1.Image != null) form.pictureBox1.Image.Dispose();
                form.pictureBox1.Image = result.image;

                if((form.panel1.Controls[0] as MyCanvas).Image != null)
                {
                    (form.panel1.Controls[0] as MyCanvas).Image.Dispose();
                }
                (form.panel1.Controls[0] as MyCanvas).Image = (Image)result.image.Clone();
            }

        }
    }
}
