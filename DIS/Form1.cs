using DIS.Manager;
using DIS.Manager.FormManager;
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
        MyCanvas canvas = new MyCanvas();

        private const string textTime = "Время обработки изображения: ";
        private const string textSizeImage = "Размер изображения: ";

        public Form1()
        {
            InitializeComponent();

            //убираем выдимость с надписей о времени обработки и о размерах изображения
            L_SizeImage.Visible = false;
            L_Time.Visible = false;

            //таблица с картинками
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 0;

            //задаем рабочие значения для класса managerLayer
            ManagerLayer.tableLayoutPanel = this.tableLayoutPanel1;
            ManagerLayer.layers = this.layers;
            ManagerLayer.pictureBox = this.pictureBox1;
            ManagerLayer.canvas = this.canvas;
            ManagerLayer.ButtonUpdateImg = this.B_ApplyImage;
            ManagerLayer.L_SizeImage = L_SizeImage;
            ManagerLayer.L_Time = L_Time;

            //настройка объекта для выполнения операции в отдельном потоке
            ManagerBackgroundWork.MainImage = pictureBox1;
            ManagerBackgroundWork.chart = chart1;
            ManagerBackgroundWork.backgroundWork = backgroundWorker1;
            ManagerBackgroundWork.Button_AddChanges = B_ApplyImage;
            ManagerBackgroundWork.Button_Save = B_Save;
            ManagerBackgroundWork.Button_Unite = B_CollectImages;
            ManagerBackgroundWork.progressBar = progressBar1;
            ManagerBackgroundWork.panel = panel1;
            ManagerBackgroundWork.layers = layers;
            ManagerBackgroundWork.L_SizeImage = L_SizeImage;
            ManagerBackgroundWork.L_Time = L_Time;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(ManagerBackgroundWork.Work);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ManagerBackgroundWork.CompletedProcess);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(ManagerBackgroundWork.ProgressChanged);

            //настройка гистограммы
            chart1.Series[0].XValueMember = BarGraph.col1;
            chart1.Series[0].YValueMembers = BarGraph.col2;

            B_AddImage.Enabled = true;
            B_CollectImages.Enabled = true;

            //настройка comboBox с функциями
            CB_GradTranInterpolation.Items.AddRange(new string[]
            {
                "Линейная зависимость",
                "Квадратичный сплайн",
                "Кубический сплайн",
                "Полином Лагранжа",
                "Полином Ньютона",
                "Кривая Безье"
            });
            CB_GradTranInterpolation.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_GradTranInterpolation.SelectedIndex = 0;

            //настройка рисования (поистроения графика по точкам)
            canvas.Name = "canvas1";
            canvas.pictureBox = this.pictureBox1;
            canvas.comboBox = this.CB_GradTranInterpolation;
            canvas.chart = this.chart1;
            canvas.panel = this.panel1;
            this.panel1.Controls.Add(canvas);
            canvas.Dock = DockStyle.Fill;

            //настройка бинаризации
            ManagerBinarization.ProgressBar = progressBar1;
            ManagerBinarization.ButtonBinar = B_StartBinarization;
            ManagerBinarization.ButtonResult = B_Binarization;
            ManagerBinarization.MainImage = pictureBox1;
            ManagerBinarization.ImageBinar = PB_OrigImageBinar;
            ManagerBinarization.CB_Gavrilov = CB_Gavrilov;
            ManagerBinarization.CB_Otsu = CB_Otsu;
            ManagerBinarization.CB_BradleyRota = CB_BradleyRota;
            ManagerBinarization.CB_ChristianWolfe = CB_ChristianWolfe;
            ManagerBinarization.CB_Sauwolas = CB_Sauwolas;
            ManagerBinarization.CB_Nibleck = CB_Nibleck;
            ManagerBinarization.NUD_Size = NUD_SizeWindow;
            ManagerBinarization.NUD_KorA = NUD_Koef;
            ManagerBinarization.Canvas = canvas;

            CB_BradleyRota.CheckedChanged += new EventHandler(ManagerBinarization.CB_Checked);
            CB_ChristianWolfe.CheckedChanged += new EventHandler(ManagerBinarization.CB_Checked);
            CB_Gavrilov.CheckedChanged += new EventHandler(ManagerBinarization.CB_Checked);
            CB_Nibleck.CheckedChanged += new EventHandler(ManagerBinarization.CB_Checked);
            CB_Otsu.CheckedChanged += new EventHandler(ManagerBinarization.CB_Checked);
            CB_Sauwolas.CheckedChanged += new EventHandler(ManagerBinarization.CB_Checked);
            NUD_SizeWindow.ValueChanged += new EventHandler(ManagerBinarization.NUD_ValueChanged);
            NUD_Koef.ValueChanged += new EventHandler(ManagerBinarization.NUD_ValueChanged);

            //настройка пространственной фильтрации
            //общие
            ManagerSpatialFilter.PB_MainImage = pictureBox1;
            ManagerSpatialFilter.PB_OriginImage = PB_OrigImageSpatial;
            ManagerSpatialFilter.PrB_ProgressBar = progressBar1;
            ManagerSpatialFilter.Canvas = canvas;
            ManagerSpatialFilter.L_Time = L_Time;
            ManagerSpatialFilter.L_SizeImage = L_SizeImage;
            ManagerSpatialFilter.B_StartChange = B_StartSpatialF;
            //для линейной фильтрации
            ManagerSpatialFilter.TB_Matrix = TB_SpatialMatrix;
            ManagerSpatialFilter.CB_CheckGauss = CB_GaussFilter;
            ManagerSpatialFilter.NUD_Change_Sigma = NUD_SpatialGausSigma;
            ManagerSpatialFilter.NUD_Сhange_R = NUD_SpatialGausR;
            ManagerSpatialFilter.B_LinearFilter = B_LinearFiltering;
            ManagerSpatialFilter.L_TextSigma = L_Spatial_GausSigma;
            ManagerSpatialFilter.L_TextR = L_Spatial_GausR;
            ManagerSpatialFilter.L_TextMatrix = L_Spatial_Matrix;
            ManagerSpatialFilter.L_TextSumMatrix = L_Spatial_MatrixSum;
            //для медианной фильтрации
            ManagerSpatialFilter.NUD_Change_Height = NUD_Spartial_Height;
            ManagerSpatialFilter.NUD_Change_Width = NUD_Spartial_Width;
            ManagerSpatialFilter.B_MedianFilter = B_MedianFiltering;
            ManagerSpatialFilter.L_TextMatrixSize = L_Spartial_SizeMatrix;
            ManagerSpatialFilter.L_TextWidth = L_Spartial_Width;
            ManagerSpatialFilter.L_TextHeight = L_Spartial_Height;

            CB_GaussFilter.CheckedChanged += new EventHandler(ManagerSpatialFilter.CheckBox_ChacngeActive);
            NUD_SpatialGausR.ValueChanged += new EventHandler(ManagerSpatialFilter.NUD_ValueChanged);
            NUD_SpatialGausSigma.ValueChanged += new EventHandler(ManagerSpatialFilter.NUD_ValueChanged);
            B_StartSpatialF.Click += new EventHandler(ManagerSpatialFilter.Button_Start);
            B_LinearFiltering.Click += new EventHandler(ManagerSpatialFilter.Button_ExecuteLinearFilter);
            B_MedianFiltering.Click += new EventHandler(ManagerSpatialFilter.Button_ExecuteMedianFilter);

            //настройка частотной фильтрации
            ManagerFrequencyFilter.PB_MainImage = pictureBox1;
            ManagerFrequencyFilter.PB_FrequencyImage = PB_OrigImageFrequency;
            ManagerFrequencyFilter.PB_FourierImage = PB_FourierImage;
            ManagerFrequencyFilter.L_SizeImage = L_SizeImage;
            ManagerFrequencyFilter.L_Time = L_Time;
            ManagerFrequencyFilter.TB_TextParam = TB__Frequency_TextParam;
            ManagerFrequencyFilter.CB_filterTrue = CB_FreqTrue;
            ManagerFrequencyFilter.CB_filterFalse = CB_FreqFalse;
            ManagerFrequencyFilter.B_Start = B_StartFrequencyF;
            ManagerFrequencyFilter.B_Execute = B_FrequencyFilter;
            ManagerFrequencyFilter.B_ToMainImage = B_FreqToMain;
            ManagerFrequencyFilter.L_X = L_FreqX;
            ManagerFrequencyFilter.L_Y = L_FreqY;
            ManagerFrequencyFilter.L_SizeImageFilter = L_Freq_Size;
            ManagerFrequencyFilter.L_NewSizeImageFilter = L_Freq_NewSize;

            B_StartFrequencyF.Click += new EventHandler(ManagerFrequencyFilter.Button_Start);
            B_FrequencyFilter.Click += new EventHandler(ManagerFrequencyFilter.Button_Execute);
            B_FreqToMain.Click += new EventHandler(ManagerFrequencyFilter.Button_ToMain);
        }

        //сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

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
                    pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch
            {
                ManagerError.ErrorOK("Произошла ошибка при сохранении изображения!");
            }
        }

        //добавить изображение
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    ManagerError.ErrorOK("Файл не выбран!");
                    return;
                }
                //добавляем новый контейнер
                AddLayer(Image.FromFile(openFileDialog.FileName), tableLayoutPanel1.Width);  
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
            B_CollectImages.Enabled = false;
            B_ApplyImage.Enabled = false;

            List<LayerValue> items = new List<LayerValue>();
            foreach(var item in layers)
            {
                items.Add(new LayerValue(item));
                item.Work = false;
                item.B_showImage.BackColor = Color.LightGreen;
            }
            B_ApplyImage.BackColor = Color.LightGreen;

            //запускаем операцию в другом потоке
            backgroundWorker1.RunWorkerAsync(items);
        }

        //сбросить график
        private void button4_Click(object sender, EventArgs e)
        {
            canvas.Clear();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //добавить/применить
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                Layer Worklayer = layers.FirstOrDefault(x => x.Work == true);
                if(Worklayer != null)
                {
                    //если мы работаем с изображением, которое было добавлено
                    Worklayer.image.Dispose();
                    Worklayer.image = (Image)pictureBox1.Image.Clone();
                    Worklayer.pictureBox.Image.Dispose();
                    Worklayer.pictureBox.Image = (Image)pictureBox1.Image.Clone();
                    Worklayer.Work = false;
                    Worklayer.B_showImage.BackColor = Color.LightGreen;
                    B_ApplyImage.BackColor = Color.LightGreen;
                }
                else
                {
                    //добавляем новый контейнер
                    AddLayer((Image)pictureBox1.Image.Clone(), tableLayoutPanel1.Width);
                }
            }
            catch
            {
                ManagerError.ErrorOK("Произошла ошибка при добавлении картинки!");
            }
        }

        //функция для добавления контейнера с изображением, а также обновления таблицы с контейнерами
        private void AddLayer(Image image, int width)
        {
            Layer layer = new Layer(image, width);
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
            //отправляем изображение на редактирование вне рамок argb и сбора
            layer.B_showImage.Click += new EventHandler(ManagerLayer.Button_ShowImage);
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

        //заменить главную картинку измененной с помощью градационных преобразований
        private void button6_Click(object sender, EventArgs e)
        {
            if (canvas.Image == null) return;
            canvas.Image.Dispose();
            canvas.Image = (Image)pictureBox1.Image.Clone();
            canvas.Clear();

            WriteSizeAndTime();
        }

        //включить или выключить бинаризацию
        private void button7_Click(object sender, EventArgs e)
        {
            ManagerBinarization.StartOrStopBinar();
            WriteSizeAndTime();
        }

        //выполнить бинаризацию (заменить главную картинку)
        private void button8_Click_1(object sender, EventArgs e)
        {
            ManagerBinarization.PerformBinar();
            WriteSizeAndTime();
        }

        //подписи к главному изображению
        private void WriteSizeAndTime()
        {
            L_Time.Text = textTime;
            L_Time.Visible = false;
            if (pictureBox1.Image != null)
            {
                L_SizeImage.Text = textSizeImage + pictureBox1.Image.Width.ToString() + " x " + pictureBox1.Image.Height.ToString();
                L_SizeImage.Visible = true;
            }
            else
            {
                L_SizeImage.Text = textSizeImage;
                L_SizeImage.Visible = false;
            }
        }

        private void B_MedianFiltering_Click(object sender, EventArgs e)
        {

        }
    }
}
