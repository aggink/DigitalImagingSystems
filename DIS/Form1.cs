using DIS.Manager;
using DIS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS
{
    public partial class Form1 : Form
    {
        private List<Layer> layers = new List<Layer>();
        public Form1()
        {
            InitializeComponent();

            //таблица с картинками
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;

            //задаем рабочие значения для класса managerLayer
            ManagerLayer.tableLayoutPanel = this.tableLayoutPanel1;
            ManagerLayer.layers = this.layers;

            //настройка объекта для выполнения операции в отдельном потоке
            BackgroundWork.form = this;
            BackgroundWork.layers = layers;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWork.Work);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWork.CompletedProcess);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(BackgroundWork.ProgressChanged);

            //настройка гистограммы
            chart1.Series[0].XValueMember = BarGraph.col1;
            chart1.Series[0].YValueMembers = BarGraph.col2;

            button2.Enabled = true;
            button3.Enabled = true;
        }
        //сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            //создание диалогового окна для сохранения изображения
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку";
            //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.OverwritePrompt = true;
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            savedialog.CheckPathExists = true;
            //список форматов файла, отображаемый в поле "Тип файла"
            savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            //отображается ли кнопка "Справка" в диалоговом окне
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    ManagerError.ErrorOK("Произошла ошибка при сохранении изображения!");
                }
            }
        }
        //добавить изображение
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() != DialogResult.OK)
            {
                ManagerError.ErrorOK("Файл не выбран!");
                return;
            }
            try
            {
                Layer layer = new Layer(Image.FromFile(openFileDialog.FileName), tableLayoutPanel1.Width);
                //обработка прозрачности
                layer.trackBar.ValueChanged += new EventHandler(ManagerLayer.TrackBar_ValueChange);
                //обработка цветовых каналов
                layer.Check_R.CheckedChanged += new EventHandler(ManagerLayer.CheckBox_Сhange);
                layer.Check_G.CheckedChanged += new EventHandler(ManagerLayer.CheckBox_Сhange);
                layer.Check_B.CheckedChanged += new EventHandler(ManagerLayer.CheckBox_Сhange);
                //обработка удаления контейнера с изображением
                layer.B_delete.Click += new EventHandler(ManagerLayer.Button_ContainerClose);
                //обработка изменения положения контейнера
                layer.B_up.Click += new EventHandler(ManagerLayer.Button_ContainerUp);
                layer.B_down.Click += new EventHandler(ManagerLayer.Button_ContainerDown);
                //добавляем контейнер в список
                layers.Add(layer);

                if (layers.Count == 1) layers[0].comboBox.Enabled = false;

                //добавляем контейнера в таблицу
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, Layer.HeigthLayerRow));
                int row = tableLayoutPanel1.RowCount;
                tableLayoutPanel1.RowCount = row + 1;
                tableLayoutPanel1.Controls.Add(layer.pictureBox, 0, row);
                tableLayoutPanel1.Controls.Add(layer.FlowLayoutPanel, 1, row);
            }
            catch
            {

                ManagerError.ErrorOK("Произошла ошибка при добавлении картинки!");
            }
        }
        //собрать
        private void button3_Click(object sender, EventArgs e)
        {
            if(layers.Count == 0)
            {
                ManagerError.ErrorOK("Изображения не добавленны!");
                return;
            }
            //закрываем доступ к кнопка
            button2.Enabled = false;
            button3.Enabled = false;

            List<LayerValue> items = new List<LayerValue>();
            foreach(var item in layers)
            {
                items.Add(new LayerValue(item));
            }

            //запускаем операцию в другом потоке
            backgroundWorker1.RunWorkerAsync(items);
        }
        //сбросить график
        private void button4_Click(object sender, EventArgs e)
        {

        }
        //задать кривую
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
