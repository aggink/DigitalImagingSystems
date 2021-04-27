using DIS.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Manager
{
    //класс для обработки запросов с контенейра (контейнер с изображением)
    public static class ManagerLayer
    {
        //таблица с изображениями с формы
        public static TableLayoutPanel tableLayoutPanel;
        //список контейнеров с изображениями
        public static List<Layer> layers;
        //контейнер с главным имзображением
        public static PictureBox pictureBox;
        public static MyCanvas canvas;
        public static Button ButtonUpdateImg;
        //перерисовать таблицу с контейнерами (изображениями)
        public static void UpdateTableLayoutPanel()
        {
            //Используйте RowStyles свойство для доступа к свойствам стиля конкретных строк
            tableLayoutPanel.RowStyles.Clear();
            //Получает коллекцию элементов управления, содержащихся в элементе управления TableLayoutPanel
            tableLayoutPanel.Controls.Clear();
            //выставляем кодичество строк в таблице
            tableLayoutPanel.RowCount = 0;
            
            foreach(var item in layers)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, Layer.HeigthLayerRow));
                int pos = tableLayoutPanel.RowCount;
                tableLayoutPanel.RowCount = pos + 1;
                tableLayoutPanel.Controls.Add(item.pictureBox, 0, pos);
                tableLayoutPanel.Controls.Add(item.FlowLayoutPanel, 1, pos);
            }
        }
        //удаление контейнера с изображением
        public static void Button_ContainerClose(object sender, EventArgs args)
        {
            //получаем нажатую кнопку
            var button = (Button)sender;
            //находим нужный контейнер с картинной
            var container = layers.First(x => x.B_delete == button);
            //удаляем выбранный контейнер из списка 
            layers.Remove(container);

            //блокируем comboBox у первого контейнера
            if(layers.Count > 0)
            {
                layers[0].comboBox.Enabled = false;
                layers[0].comboBox.SelectedIndex = 0;
            }

            //обновление таблицы
            UpdateTableLayoutPanel();
            //очищение памяти
            container.Dispose();
        }
        //изменении положения курсора для задания прозрачности
        public static void TrackBar_ValueChange(object sender, EventArgs args)
        {
            //получаем tackBar
            var trackBar = (TrackBar)sender;
            //находим нужный контейнер с картинкой
            var container = layers.First(x => x.trackBar == trackBar);
            //изменяем надпись с процентами в контейнере
            container.label.Text = "Прозрачность " + trackBar.Value + " %";

            //получаем цветовые каналы
            int R = container.Check_R.Checked ? 1 : 0;
            int G = container.Check_G.Checked ? 1 : 0;
            int B = container.Check_B.Checked ? 1 : 0;

            //очищаем память картинки, которая содержится в pictureBox в контейнере
            container.pictureBox.Image.Dispose();
            //получаем новую картинку с заданными изменениями
            container.pictureBox.Image = WorkImage.SetImgChannelValue(container.image, (float)(1.0 - trackBar.Value / 100.0), R, G, B);
        }
        //изменение каналов цвета
        public static void CheckBox_Сhange(object sender, EventArgs args)
        {
            //получаем checkBox
            var checkBox = (CheckBox)sender;
            //находим нужный контейнер с картинкой
            var container = layers.First(x => x.Check_R == checkBox || x.Check_G == checkBox || x.Check_B == checkBox);

            //получаем цветовые каналы
            int R = container.Check_R.Checked ? 1 : 0;
            int G = container.Check_G.Checked ? 1 : 0;
            int B = container.Check_B.Checked ? 1 : 0;

            //очищаем память картинки, которая содержится в pictureBox в контейнере
            container.pictureBox.Image.Dispose();
            //получаем новую картинку с заданными изменениями
            container.pictureBox.Image = WorkImage.SetImgChannelValue(container.image, (float)(1.0 - container.trackBar.Value / 100.0), R, G, B);
        }
        //перемещение ВВЕРХ контейнера с изображением
        public static void Button_ContainerUp(object sender, EventArgs args)
        {
            //получаем нажатую кнопку
            var button = (Button)sender;
            //находим нужный контейнер с картинной
            var container = layers.First(x => x.B_up == button);

            int index = layers.IndexOf(container);
            if(index > 0)
            {
                //меняем контейнеры местами
                int indexback = index - 1;
                var backContainer = layers[indexback];

                layers[indexback] = container;
                layers[index] = backContainer;

                layers[0].comboBox.Enabled = false;
                layers[0].comboBox.SelectedIndex = 0;

                //обновляем таблицу с изображениями
                UpdateTableLayoutPanel();
            }
        }
        //перемещение ВНИЗ контейнера с изображением
        public static void Button_ContainerDown(object sender, EventArgs args)
        {
            //получаем нажатую кнопку
            var button = (Button)sender;
            //находим нужный контейнер с картинной
            var container = layers.First(x => x.B_down == button);

            int index = layers.IndexOf(container);
            if(index < layers.Count - 1)
            {
                //меняем контейнеры местами
                int indexnext = index + 1;
                var nextcontainer = layers[indexnext];

                layers[index] = nextcontainer;
                layers[indexnext] = container;

                layers[0].comboBox.Enabled = false;
                layers[0].comboBox.SelectedIndex = 0;

                container.comboBox.Enabled = true;

                //обновляем таблицу с изображениями
                UpdateTableLayoutPanel();
            }
        }
        //показать изображение (отображает картинку как главную)
        public static void Button_ShowImage(object sender, EventArgs args)
        {
            //получаем нажатую кнопку
            var button = (Button)sender;
            //находим нужный контейнер с картинной
            var container = layers.First(x => x.B_showImage == button);

            if (!container.Work)
            {
                foreach (var x in layers)
                {
                    x.Work = false;
                    x.B_showImage.BackColor = Color.LightGreen;
                }

                container.Work = true;
                container.B_showImage.BackColor = Color.LimeGreen;

                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }
                if (canvas.Image != null)
                {
                    canvas.Image.Dispose();
                }

                ButtonUpdateImg.BackColor = Color.LimeGreen;

                //устанавливаем картинку
                LayerValue layerValue = new LayerValue(container);
                pictureBox.Image = WorkImage.SetImgChannelValue(layerValue.image, layerValue.Transparency, layerValue.R, layerValue.G, layerValue.B);
                canvas.Image = (Image)pictureBox.Image.Clone();
            }
            else
            {
                container.Work = false;
                container.B_showImage.BackColor = Color.LightGreen;
                ButtonUpdateImg.BackColor = Color.LightGreen;
            }

            canvas.Clear();
        }
    }
}
