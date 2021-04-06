using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Model
{
    public class Layer :IDisposable
    {
        //наше изображение
        public Image image { get; set; }
        //контейнер для картинки
        public PictureBox pictureBox { get; set; }
        public Label label { get; set; }
        //кнопка убрать картинку
        public Button B_delete { get; set; }
        //кнопка передвинуть вверх картинку
        public Button B_up { get; set; }
        //кнопка опустить картинку
        public Button B_down { get; set; }
        //кнопка для перевода изображения на главный
        public Button B_showImage { get; set; }
        public TrackBar trackBar { get; set; }
        //выбор операции
        public ComboBox comboBox { get; set; }
        //выбор цветового канала
        public CheckBox Check_R { get; set; }
        public CheckBox Check_G { get; set; }
        public CheckBox Check_B { get; set; }
        //контейнер для кнопок
        private FlowLayoutPanel FLP_Button;
        //контейнер для цветовых каналов
        private FlowLayoutPanel FLP_Check;
        //контейнер для содержимого
        public FlowLayoutPanel FlowLayoutPanel { get; set; }
        //высота строки для контейнера с изображением
        public static readonly int HeigthLayerRow = 160;
        //высота контейнера с изображением
        public static readonly int HeigthLayer = 155;
        private static readonly Padding margin = new Padding(3, 3, 3, 3);
        private static readonly Padding padding = new Padding(2, 0, 0, 3);
        public Layer(Layer layer)
        {
            this.image = layer.image;
            this.pictureBox = layer.pictureBox;
            this.label = layer.label;
            this.B_delete = layer.B_delete;
            this.B_up = layer.B_up;
            this.B_down = layer.B_down;
            this.trackBar = layer.trackBar;
            this.comboBox = layer.comboBox;
            this.Check_R = layer.Check_R;
            this.Check_G = layer.Check_G;
            this.Check_B = layer.Check_B;
            this.FLP_Button = layer.FLP_Button;
            this.FLP_Check = layer.FLP_Check;
            this.FlowLayoutPanel = layer.FlowLayoutPanel;
        }
        public Layer(Image image, int width)
        {
            this.image = image;

            //Настройка контейнера для картинки
            this.pictureBox = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(width / 2, HeigthLayer),
                Image = (Image)image.Clone(),
                BackColor = Color.Transparent,
            };

            //сообщение о прозрачности
            this.label = new Label()
            {
                Text = "Прозрачность - 0 %",
                Margin = new Padding(25, 3, 3, 3),
                AutoSize = true
            };

            //полоса прокрутки для прозрачности
            this.trackBar = new TrackBar()
            {
                Maximum = 100,
                Minimum = 0,
                Height = 20,
                Width = 100,
                TickStyle = TickStyle.Both,
                Margin = new Padding(25, 3, 3, 3)
            };

            //выбор операций
            this.comboBox = new ComboBox()
            {
                Items = { "нет", "сумма", "среднее арифметическое", "максимум", "минимум", "произведение" },
                SelectedIndex = 0,
                Height = 20,
                Margin = new Padding(15, 3, 3, 3),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            //настройка цветовых каналов
            this.Check_R = new CheckBox()
            {
                BackColor = Color.Red,
                Margin = margin,
                AutoSize = true,
                Checked = true
            };

            this.Check_G = new CheckBox()
            {
                BackColor = Color.Green,
                Margin = margin,
                AutoSize = true,
                Checked = true
            };

            this.Check_B = new CheckBox()
            {
                BackColor = Color.Blue,
                Margin = margin,
                AutoSize = true,
                Checked = true
            };

            //собираем чекбоксы в панель
            this.FLP_Check = new FlowLayoutPanel()
            {
                Controls = { this.Check_R, this.Check_G, this.Check_B },
                Margin = new Padding(43, 3, 3, 3)
            };
            //настройка кнопок
            this.B_up = new Button()
            {
                Text = "↑",
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Standard,
                Margin = margin,
                Padding = padding,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                AutoSize = true
            };

            this.B_down = new Button()
            {
                Text = "↓",
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Standard,
                Margin = margin,
                Padding = padding,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                AutoSize = true
            };

            this.B_showImage = new Button()
            {
                Text = "←",
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Standard,
                Margin = margin,
                Padding = padding,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                AutoSize = true
            };
            this.B_delete = new Button()
            {
                Text = "Х",
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Standard,
                Margin = new Padding(3, 3, 3, 3),
                Padding = new Padding(2, 2, 1, 1),
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                AutoSize = true
            };

            int h = this.B_up.Width + this.B_down.Width + this.B_delete.Width + this.B_showImage.Width + 6;
            //собираем кнопки в панель
            this.FLP_Button = new FlowLayoutPanel()
            {
                Controls = { this.B_showImage, this.B_up, this.B_down, this.B_delete },
                Width = h,
                Height = (new List<int>() { this.B_delete.Height, this.B_down.Height, this.B_up.Height }).Max() + 3,
                Margin = new Padding(10, 3, 3, 3)
            };

            //собираем все воедино 
            this.FlowLayoutPanel = new FlowLayoutPanel
            {
                Controls = { this.FLP_Button, this.comboBox, this.label, this.trackBar, this.FLP_Check },
                Height = HeigthLayer,
                Dock = DockStyle.Fill,
                Margin = new Padding(0)
            };
        }

        public void Dispose()
        {

            if(this.image != null) this.image.Dispose();
            if(this.pictureBox.Image != null) this.pictureBox.Image.Dispose();
            this.pictureBox.Dispose();
            this.label.Dispose();
            this.B_delete.Dispose();
            this.B_up.Dispose();
            this.B_down.Dispose();
            this.trackBar.Dispose();
            this.comboBox.Dispose();
            this.Check_R.Dispose();
            this.Check_G.Dispose();
            this.Check_B.Dispose();
            this.FLP_Button.Dispose();
            this.FLP_Check.Dispose();
            this.FlowLayoutPanel.Dispose();
        }
    }
}
