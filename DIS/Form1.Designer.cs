
namespace DIS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.L_Time = new System.Windows.Forms.Label();
            this.L_SizeImage = new System.Windows.Forms.Label();
            this.B_ApplyImage = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.ImageEditor = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_CollectImages = new System.Windows.Forms.Button();
            this.B_AddImage = new System.Windows.Forms.Button();
            this.GradationTran = new System.Windows.Forms.TabPage();
            this.B_GradTransApply = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.B_GradTransReturnToOrig = new System.Windows.Forms.Button();
            this.CB_GradTranInterpolation = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Binarization = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NUD_Koef = new System.Windows.Forms.NumericUpDown();
            this.NUD_SizeWindow = new System.Windows.Forms.NumericUpDown();
            this.CB_BradleyRota = new System.Windows.Forms.CheckBox();
            this.CB_ChristianWolfe = new System.Windows.Forms.CheckBox();
            this.CB_Sauwolas = new System.Windows.Forms.CheckBox();
            this.CB_Nibleck = new System.Windows.Forms.CheckBox();
            this.CB_Otsu = new System.Windows.Forms.CheckBox();
            this.CB_Gavrilov = new System.Windows.Forms.CheckBox();
            this.B_Binarization = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PB_OrigImageBinar = new System.Windows.Forms.PictureBox();
            this.B_StartBinarization = new System.Windows.Forms.Button();
            this.SpatialFiltering = new System.Windows.Forms.TabPage();
            this.TC_SpatialFilter = new System.Windows.Forms.TabControl();
            this.LinearFilter = new System.Windows.Forms.TabPage();
            this.L_Spatial_MatrixSum = new System.Windows.Forms.Label();
            this.B_LinearFiltering = new System.Windows.Forms.Button();
            this.L_Spatial_Matrix = new System.Windows.Forms.Label();
            this.TB_SpatialMatrix = new System.Windows.Forms.TextBox();
            this.NUD_SpatialGausSigma = new System.Windows.Forms.NumericUpDown();
            this.CB_GaussFilter = new System.Windows.Forms.CheckBox();
            this.NUD_SpatialGausR = new System.Windows.Forms.NumericUpDown();
            this.L_Spatial_GausR = new System.Windows.Forms.Label();
            this.L_Spatial_GausSigma = new System.Windows.Forms.Label();
            this.MedianFilter = new System.Windows.Forms.TabPage();
            this.B_MedianFiltering = new System.Windows.Forms.Button();
            this.NUD_Spartial_Height = new System.Windows.Forms.NumericUpDown();
            this.NUD_Spartial_Width = new System.Windows.Forms.NumericUpDown();
            this.L_Spartial_Height = new System.Windows.Forms.Label();
            this.L_Spartial_Width = new System.Windows.Forms.Label();
            this.L_Spartial_SizeMatrix = new System.Windows.Forms.Label();
            this.B_StartSpatialF = new System.Windows.Forms.Button();
            this.PB_OrigImageSpatial = new System.Windows.Forms.PictureBox();
            this.FrequencyFiltering = new System.Windows.Forms.TabPage();
            this.L_Freq_NewSize = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.L_Freq_Size = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.B_FreqToMain = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.L_FreqY = new System.Windows.Forms.Label();
            this.L_FreqX = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CB_FreqFalse = new System.Windows.Forms.CheckBox();
            this.CB_FreqTrue = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB__Frequency_TextParam = new System.Windows.Forms.TextBox();
            this.L_Frequency_Fourier = new System.Windows.Forms.Label();
            this.B_FrequencyFilter = new System.Windows.Forms.Button();
            this.PB_FourierImage = new System.Windows.Forms.PictureBox();
            this.L_Frequency_Factor = new System.Windows.Forms.Label();
            this.L_Frequency_FilterArea = new System.Windows.Forms.Label();
            this.PB_OrigImageFrequency = new System.Windows.Forms.PictureBox();
            this.B_StartFrequencyF = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.ImageEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.GradationTran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.Binarization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Koef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SizeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_OrigImageBinar)).BeginInit();
            this.SpatialFiltering.SuspendLayout();
            this.TC_SpatialFilter.SuspendLayout();
            this.LinearFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpatialGausSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpatialGausR)).BeginInit();
            this.MedianFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Spartial_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Spartial_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_OrigImageSpatial)).BeginInit();
            this.FrequencyFiltering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FourierImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_OrigImageFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.L_Time);
            this.splitContainer1.Panel1.Controls.Add(this.L_SizeImage);
            this.splitContainer1.Panel1.Controls.Add(this.B_ApplyImage);
            this.splitContainer1.Panel1.Controls.Add(this.B_Save);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1386, 828);
            this.splitContainer1.SplitterDistance = 1011;
            this.splitContainer1.TabIndex = 0;
            // 
            // L_Time
            // 
            this.L_Time.AutoSize = true;
            this.L_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Time.Location = new System.Drawing.Point(22, 717);
            this.L_Time.Name = "L_Time";
            this.L_Time.Size = new System.Drawing.Size(332, 25);
            this.L_Time.TabIndex = 6;
            this.L_Time.Text = "Время обработки изображения:";
            // 
            // L_SizeImage
            // 
            this.L_SizeImage.AutoSize = true;
            this.L_SizeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_SizeImage.Location = new System.Drawing.Point(22, 677);
            this.L_SizeImage.Name = "L_SizeImage";
            this.L_SizeImage.Size = new System.Drawing.Size(233, 25);
            this.L_SizeImage.TabIndex = 5;
            this.L_SizeImage.Text = "Размер изображения:";
            // 
            // B_ApplyImage
            // 
            this.B_ApplyImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_ApplyImage.BackColor = System.Drawing.Color.LightGreen;
            this.B_ApplyImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_ApplyImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_ApplyImage.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_ApplyImage.Location = new System.Drawing.Point(938, 668);
            this.B_ApplyImage.Name = "B_ApplyImage";
            this.B_ApplyImage.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.B_ApplyImage.Size = new System.Drawing.Size(50, 46);
            this.B_ApplyImage.TabIndex = 4;
            this.B_ApplyImage.Text = "🠖";
            this.B_ApplyImage.UseVisualStyleBackColor = false;
            this.B_ApplyImage.Click += new System.EventHandler(this.button5_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.BackColor = System.Drawing.Color.LightGreen;
            this.B_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_Save.Location = new System.Drawing.Point(699, 668);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(233, 46);
            this.B_Save.TabIndex = 3;
            this.B_Save.Text = "Сохранить";
            this.B_Save.UseVisualStyleBackColor = false;
            this.B_Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(27, 637);
            this.progressBar1.MinimumSize = new System.Drawing.Size(961, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(961, 25);
            this.progressBar1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(961, 619);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.ImageEditor);
            this.TabControl1.Controls.Add(this.GradationTran);
            this.TabControl1.Controls.Add(this.Binarization);
            this.TabControl1.Controls.Add(this.SpatialFiltering);
            this.TabControl1.Controls.Add(this.FrequencyFiltering);
            this.TabControl1.Location = new System.Drawing.Point(13, 12);
            this.TabControl1.Multiline = true;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.ShowToolTips = true;
            this.TabControl1.Size = new System.Drawing.Size(355, 804);
            this.TabControl1.TabIndex = 0;
            // 
            // ImageEditor
            // 
            this.ImageEditor.Controls.Add(this.splitContainer3);
            this.ImageEditor.Location = new System.Drawing.Point(4, 40);
            this.ImageEditor.Name = "ImageEditor";
            this.ImageEditor.Padding = new System.Windows.Forms.Padding(3);
            this.ImageEditor.Size = new System.Drawing.Size(347, 760);
            this.ImageEditor.TabIndex = 3;
            this.ImageEditor.Text = "Редактор";
            this.ImageEditor.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.B_CollectImages);
            this.splitContainer3.Panel2.Controls.Add(this.B_AddImage);
            this.splitContainer3.Size = new System.Drawing.Size(341, 754);
            this.splitContainer3.SplitterDistance = 573;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(0, 590);
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 569);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // B_CollectImages
            // 
            this.B_CollectImages.BackColor = System.Drawing.Color.LightGreen;
            this.B_CollectImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_CollectImages.Location = new System.Drawing.Point(184, 15);
            this.B_CollectImages.Name = "B_CollectImages";
            this.B_CollectImages.Size = new System.Drawing.Size(121, 55);
            this.B_CollectImages.TabIndex = 3;
            this.B_CollectImages.Text = "Собрать ";
            this.B_CollectImages.UseVisualStyleBackColor = false;
            this.B_CollectImages.Click += new System.EventHandler(this.button3_Click);
            // 
            // B_AddImage
            // 
            this.B_AddImage.BackColor = System.Drawing.Color.LightGreen;
            this.B_AddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_AddImage.Location = new System.Drawing.Point(22, 15);
            this.B_AddImage.Name = "B_AddImage";
            this.B_AddImage.Size = new System.Drawing.Size(121, 55);
            this.B_AddImage.TabIndex = 2;
            this.B_AddImage.Text = "Добавить изображение";
            this.B_AddImage.UseVisualStyleBackColor = false;
            this.B_AddImage.Click += new System.EventHandler(this.button2_Click);
            // 
            // GradationTran
            // 
            this.GradationTran.Controls.Add(this.B_GradTransApply);
            this.GradationTran.Controls.Add(this.chart1);
            this.GradationTran.Controls.Add(this.B_GradTransReturnToOrig);
            this.GradationTran.Controls.Add(this.CB_GradTranInterpolation);
            this.GradationTran.Controls.Add(this.panel1);
            this.GradationTran.Location = new System.Drawing.Point(4, 40);
            this.GradationTran.Name = "GradationTran";
            this.GradationTran.Padding = new System.Windows.Forms.Padding(3);
            this.GradationTran.Size = new System.Drawing.Size(347, 760);
            this.GradationTran.TabIndex = 1;
            this.GradationTran.Text = "Градационные преобразования";
            this.GradationTran.UseVisualStyleBackColor = true;
            // 
            // B_GradTransApply
            // 
            this.B_GradTransApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_GradTransApply.BackColor = System.Drawing.Color.LightGreen;
            this.B_GradTransApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_GradTransApply.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_GradTransApply.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_GradTransApply.Location = new System.Drawing.Point(62, 616);
            this.B_GradTransApply.Name = "B_GradTransApply";
            this.B_GradTransApply.Size = new System.Drawing.Size(229, 46);
            this.B_GradTransApply.TabIndex = 4;
            this.B_GradTransApply.Text = "Применить";
            this.B_GradTransApply.UseVisualStyleBackColor = false;
            this.B_GradTransApply.Click += new System.EventHandler(this.button6_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(5, 412);
            this.chart1.Margin = new System.Windows.Forms.Padding(1);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.BorderColor = System.Drawing.Color.Black;
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.CustomProperties = "PointWidth=1";
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.LabelBorderColor = System.Drawing.Color.White;
            series2.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.LabelBorderWidth = 0;
            series2.Name = "Series1";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(342, 188);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Гистограмма";
            // 
            // B_GradTransReturnToOrig
            // 
            this.B_GradTransReturnToOrig.BackColor = System.Drawing.Color.LightGreen;
            this.B_GradTransReturnToOrig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_GradTransReturnToOrig.Location = new System.Drawing.Point(4, 381);
            this.B_GradTransReturnToOrig.Name = "B_GradTransReturnToOrig";
            this.B_GradTransReturnToOrig.Size = new System.Drawing.Size(342, 27);
            this.B_GradTransReturnToOrig.TabIndex = 2;
            this.B_GradTransReturnToOrig.Text = "Сбросить";
            this.B_GradTransReturnToOrig.UseVisualStyleBackColor = false;
            this.B_GradTransReturnToOrig.Click += new System.EventHandler(this.button4_Click);
            // 
            // CB_GradTranInterpolation
            // 
            this.CB_GradTranInterpolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_GradTranInterpolation.FormattingEnabled = true;
            this.CB_GradTranInterpolation.Location = new System.Drawing.Point(3, 351);
            this.CB_GradTranInterpolation.Name = "CB_GradTranInterpolation";
            this.CB_GradTranInterpolation.Size = new System.Drawing.Size(342, 24);
            this.CB_GradTranInterpolation.TabIndex = 1;
            this.CB_GradTranInterpolation.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 342);
            this.panel1.TabIndex = 0;
            // 
            // Binarization
            // 
            this.Binarization.Controls.Add(this.label8);
            this.Binarization.Controls.Add(this.label7);
            this.Binarization.Controls.Add(this.NUD_Koef);
            this.Binarization.Controls.Add(this.NUD_SizeWindow);
            this.Binarization.Controls.Add(this.CB_BradleyRota);
            this.Binarization.Controls.Add(this.CB_ChristianWolfe);
            this.Binarization.Controls.Add(this.CB_Sauwolas);
            this.Binarization.Controls.Add(this.CB_Nibleck);
            this.Binarization.Controls.Add(this.CB_Otsu);
            this.Binarization.Controls.Add(this.CB_Gavrilov);
            this.Binarization.Controls.Add(this.B_Binarization);
            this.Binarization.Controls.Add(this.label6);
            this.Binarization.Controls.Add(this.label5);
            this.Binarization.Controls.Add(this.label4);
            this.Binarization.Controls.Add(this.label3);
            this.Binarization.Controls.Add(this.label2);
            this.Binarization.Controls.Add(this.label1);
            this.Binarization.Controls.Add(this.PB_OrigImageBinar);
            this.Binarization.Controls.Add(this.B_StartBinarization);
            this.Binarization.Location = new System.Drawing.Point(4, 40);
            this.Binarization.Name = "Binarization";
            this.Binarization.Padding = new System.Windows.Forms.Padding(3);
            this.Binarization.Size = new System.Drawing.Size(347, 760);
            this.Binarization.TabIndex = 4;
            this.Binarization.Text = "Бинаризация";
            this.Binarization.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 634);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Чувствительность / усиление";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 634);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Размер окна";
            // 
            // NUD_Koef
            // 
            this.NUD_Koef.DecimalPlaces = 5;
            this.NUD_Koef.Enabled = false;
            this.NUD_Koef.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_Koef.Location = new System.Drawing.Point(228, 650);
            this.NUD_Koef.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Koef.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NUD_Koef.Name = "NUD_Koef";
            this.NUD_Koef.Size = new System.Drawing.Size(70, 20);
            this.NUD_Koef.TabIndex = 26;
            this.NUD_Koef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NUD_SizeWindow
            // 
            this.NUD_SizeWindow.Enabled = false;
            this.NUD_SizeWindow.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUD_SizeWindow.Location = new System.Drawing.Point(54, 650);
            this.NUD_SizeWindow.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_SizeWindow.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUD_SizeWindow.Name = "NUD_SizeWindow";
            this.NUD_SizeWindow.Size = new System.Drawing.Size(70, 20);
            this.NUD_SizeWindow.TabIndex = 25;
            this.NUD_SizeWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_SizeWindow.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // CB_BradleyRota
            // 
            this.CB_BradleyRota.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_BradleyRota.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CB_BradleyRota.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_BradleyRota.Enabled = false;
            this.CB_BradleyRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_BradleyRota.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_BradleyRota.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CB_BradleyRota.Location = new System.Drawing.Point(218, 507);
            this.CB_BradleyRota.Name = "CB_BradleyRota";
            this.CB_BradleyRota.Size = new System.Drawing.Size(90, 90);
            this.CB_BradleyRota.TabIndex = 24;
            this.CB_BradleyRota.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CB_BradleyRota.UseVisualStyleBackColor = true;
            // 
            // CB_ChristianWolfe
            // 
            this.CB_ChristianWolfe.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_ChristianWolfe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CB_ChristianWolfe.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_ChristianWolfe.Enabled = false;
            this.CB_ChristianWolfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_ChristianWolfe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_ChristianWolfe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CB_ChristianWolfe.Location = new System.Drawing.Point(41, 507);
            this.CB_ChristianWolfe.Name = "CB_ChristianWolfe";
            this.CB_ChristianWolfe.Size = new System.Drawing.Size(90, 90);
            this.CB_ChristianWolfe.TabIndex = 23;
            this.CB_ChristianWolfe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CB_ChristianWolfe.UseVisualStyleBackColor = true;
            // 
            // CB_Sauwolas
            // 
            this.CB_Sauwolas.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_Sauwolas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CB_Sauwolas.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_Sauwolas.Enabled = false;
            this.CB_Sauwolas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Sauwolas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Sauwolas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CB_Sauwolas.Location = new System.Drawing.Point(218, 389);
            this.CB_Sauwolas.Name = "CB_Sauwolas";
            this.CB_Sauwolas.Size = new System.Drawing.Size(90, 90);
            this.CB_Sauwolas.TabIndex = 22;
            this.CB_Sauwolas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CB_Sauwolas.UseVisualStyleBackColor = true;
            // 
            // CB_Nibleck
            // 
            this.CB_Nibleck.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_Nibleck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CB_Nibleck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_Nibleck.Enabled = false;
            this.CB_Nibleck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Nibleck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Nibleck.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CB_Nibleck.Location = new System.Drawing.Point(41, 389);
            this.CB_Nibleck.Name = "CB_Nibleck";
            this.CB_Nibleck.Size = new System.Drawing.Size(90, 90);
            this.CB_Nibleck.TabIndex = 21;
            this.CB_Nibleck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CB_Nibleck.UseVisualStyleBackColor = true;
            // 
            // CB_Otsu
            // 
            this.CB_Otsu.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_Otsu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CB_Otsu.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_Otsu.Enabled = false;
            this.CB_Otsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Otsu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Otsu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CB_Otsu.Location = new System.Drawing.Point(218, 271);
            this.CB_Otsu.Name = "CB_Otsu";
            this.CB_Otsu.Size = new System.Drawing.Size(90, 90);
            this.CB_Otsu.TabIndex = 20;
            this.CB_Otsu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CB_Otsu.UseVisualStyleBackColor = true;
            // 
            // CB_Gavrilov
            // 
            this.CB_Gavrilov.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_Gavrilov.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CB_Gavrilov.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_Gavrilov.Enabled = false;
            this.CB_Gavrilov.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Gavrilov.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Gavrilov.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CB_Gavrilov.Location = new System.Drawing.Point(41, 271);
            this.CB_Gavrilov.Name = "CB_Gavrilov";
            this.CB_Gavrilov.Size = new System.Drawing.Size(90, 90);
            this.CB_Gavrilov.TabIndex = 19;
            this.CB_Gavrilov.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CB_Gavrilov.UseVisualStyleBackColor = true;
            // 
            // B_Binarization
            // 
            this.B_Binarization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Binarization.BackColor = System.Drawing.Color.LightGreen;
            this.B_Binarization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Binarization.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_Binarization.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_Binarization.Location = new System.Drawing.Point(6, 716);
            this.B_Binarization.Name = "B_Binarization";
            this.B_Binarization.Size = new System.Drawing.Size(335, 38);
            this.B_Binarization.TabIndex = 18;
            this.B_Binarization.Text = "Бинаризировать";
            this.B_Binarization.UseVisualStyleBackColor = false;
            this.B_Binarization.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 600);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Критерий Брэдли-Рота";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 600);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Критерий Кристиана Вульфа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Критерий Сауволы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Критерий Ниблека";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Критерий Отсу";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Критерий Гаврилова";
            // 
            // PB_OrigImageBinar
            // 
            this.PB_OrigImageBinar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_OrigImageBinar.BackColor = System.Drawing.Color.LightGray;
            this.PB_OrigImageBinar.Enabled = false;
            this.PB_OrigImageBinar.Location = new System.Drawing.Point(6, 63);
            this.PB_OrigImageBinar.Name = "PB_OrigImageBinar";
            this.PB_OrigImageBinar.Size = new System.Drawing.Size(335, 184);
            this.PB_OrigImageBinar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_OrigImageBinar.TabIndex = 6;
            this.PB_OrigImageBinar.TabStop = false;
            // 
            // B_StartBinarization
            // 
            this.B_StartBinarization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_StartBinarization.BackColor = System.Drawing.Color.LightGreen;
            this.B_StartBinarization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_StartBinarization.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_StartBinarization.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_StartBinarization.Location = new System.Drawing.Point(54, 15);
            this.B_StartBinarization.Name = "B_StartBinarization";
            this.B_StartBinarization.Size = new System.Drawing.Size(229, 42);
            this.B_StartBinarization.TabIndex = 4;
            this.B_StartBinarization.Text = "Начать";
            this.B_StartBinarization.UseVisualStyleBackColor = false;
            this.B_StartBinarization.Click += new System.EventHandler(this.button7_Click);
            // 
            // SpatialFiltering
            // 
            this.SpatialFiltering.Controls.Add(this.TC_SpatialFilter);
            this.SpatialFiltering.Controls.Add(this.B_StartSpatialF);
            this.SpatialFiltering.Controls.Add(this.PB_OrigImageSpatial);
            this.SpatialFiltering.Location = new System.Drawing.Point(4, 40);
            this.SpatialFiltering.Name = "SpatialFiltering";
            this.SpatialFiltering.Padding = new System.Windows.Forms.Padding(3);
            this.SpatialFiltering.Size = new System.Drawing.Size(347, 760);
            this.SpatialFiltering.TabIndex = 5;
            this.SpatialFiltering.Text = "Пространственная фильтрация";
            this.SpatialFiltering.UseVisualStyleBackColor = true;
            // 
            // TC_SpatialFilter
            // 
            this.TC_SpatialFilter.Controls.Add(this.LinearFilter);
            this.TC_SpatialFilter.Controls.Add(this.MedianFilter);
            this.TC_SpatialFilter.Location = new System.Drawing.Point(8, 246);
            this.TC_SpatialFilter.Name = "TC_SpatialFilter";
            this.TC_SpatialFilter.SelectedIndex = 0;
            this.TC_SpatialFilter.Size = new System.Drawing.Size(334, 508);
            this.TC_SpatialFilter.TabIndex = 31;
            // 
            // LinearFilter
            // 
            this.LinearFilter.Controls.Add(this.L_Spatial_MatrixSum);
            this.LinearFilter.Controls.Add(this.B_LinearFiltering);
            this.LinearFilter.Controls.Add(this.L_Spatial_Matrix);
            this.LinearFilter.Controls.Add(this.TB_SpatialMatrix);
            this.LinearFilter.Controls.Add(this.NUD_SpatialGausSigma);
            this.LinearFilter.Controls.Add(this.CB_GaussFilter);
            this.LinearFilter.Controls.Add(this.NUD_SpatialGausR);
            this.LinearFilter.Controls.Add(this.L_Spatial_GausR);
            this.LinearFilter.Controls.Add(this.L_Spatial_GausSigma);
            this.LinearFilter.Location = new System.Drawing.Point(4, 22);
            this.LinearFilter.Name = "LinearFilter";
            this.LinearFilter.Padding = new System.Windows.Forms.Padding(3);
            this.LinearFilter.Size = new System.Drawing.Size(326, 482);
            this.LinearFilter.TabIndex = 0;
            this.LinearFilter.Text = "Линейная";
            this.LinearFilter.UseVisualStyleBackColor = true;
            // 
            // L_Spatial_MatrixSum
            // 
            this.L_Spatial_MatrixSum.AutoSize = true;
            this.L_Spatial_MatrixSum.Enabled = false;
            this.L_Spatial_MatrixSum.Location = new System.Drawing.Point(16, 317);
            this.L_Spatial_MatrixSum.Name = "L_Spatial_MatrixSum";
            this.L_Spatial_MatrixSum.Size = new System.Drawing.Size(92, 13);
            this.L_Spatial_MatrixSum.TabIndex = 30;
            this.L_Spatial_MatrixSum.Text = "Сумма матрицы:";
            // 
            // B_LinearFiltering
            // 
            this.B_LinearFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_LinearFiltering.BackColor = System.Drawing.Color.LightGreen;
            this.B_LinearFiltering.Enabled = false;
            this.B_LinearFiltering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_LinearFiltering.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_LinearFiltering.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_LinearFiltering.Location = new System.Drawing.Point(7, 438);
            this.B_LinearFiltering.Name = "B_LinearFiltering";
            this.B_LinearFiltering.Size = new System.Drawing.Size(312, 38);
            this.B_LinearFiltering.TabIndex = 29;
            this.B_LinearFiltering.Text = "Выполнить";
            this.B_LinearFiltering.UseVisualStyleBackColor = false;
            // 
            // L_Spatial_Matrix
            // 
            this.L_Spatial_Matrix.AutoSize = true;
            this.L_Spatial_Matrix.Enabled = false;
            this.L_Spatial_Matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Spatial_Matrix.Location = new System.Drawing.Point(89, 12);
            this.L_Spatial_Matrix.Name = "L_Spatial_Matrix";
            this.L_Spatial_Matrix.Size = new System.Drawing.Size(143, 20);
            this.L_Spatial_Matrix.TabIndex = 11;
            this.L_Spatial_Matrix.Text = "Задайте матрицу";
            // 
            // TB_SpatialMatrix
            // 
            this.TB_SpatialMatrix.AcceptsTab = true;
            this.TB_SpatialMatrix.Enabled = false;
            this.TB_SpatialMatrix.Location = new System.Drawing.Point(7, 43);
            this.TB_SpatialMatrix.Multiline = true;
            this.TB_SpatialMatrix.Name = "TB_SpatialMatrix";
            this.TB_SpatialMatrix.Size = new System.Drawing.Size(312, 190);
            this.TB_SpatialMatrix.TabIndex = 10;
            // 
            // NUD_SpatialGausSigma
            // 
            this.NUD_SpatialGausSigma.DecimalPlaces = 3;
            this.NUD_SpatialGausSigma.Enabled = false;
            this.NUD_SpatialGausSigma.Location = new System.Drawing.Point(187, 279);
            this.NUD_SpatialGausSigma.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_SpatialGausSigma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_SpatialGausSigma.Name = "NUD_SpatialGausSigma";
            this.NUD_SpatialGausSigma.Size = new System.Drawing.Size(70, 20);
            this.NUD_SpatialGausSigma.TabIndex = 27;
            this.NUD_SpatialGausSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_SpatialGausSigma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CB_GaussFilter
            // 
            this.CB_GaussFilter.AutoSize = true;
            this.CB_GaussFilter.Enabled = false;
            this.CB_GaussFilter.Location = new System.Drawing.Point(93, 239);
            this.CB_GaussFilter.Name = "CB_GaussFilter";
            this.CB_GaussFilter.Size = new System.Drawing.Size(131, 17);
            this.CB_GaussFilter.TabIndex = 12;
            this.CB_GaussFilter.Text = "Гауссовский фильтр";
            this.CB_GaussFilter.UseVisualStyleBackColor = true;
            // 
            // NUD_SpatialGausR
            // 
            this.NUD_SpatialGausR.Enabled = false;
            this.NUD_SpatialGausR.Location = new System.Drawing.Point(51, 279);
            this.NUD_SpatialGausR.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_SpatialGausR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_SpatialGausR.Name = "NUD_SpatialGausR";
            this.NUD_SpatialGausR.Size = new System.Drawing.Size(70, 20);
            this.NUD_SpatialGausR.TabIndex = 26;
            this.NUD_SpatialGausR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_SpatialGausR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // L_Spatial_GausR
            // 
            this.L_Spatial_GausR.AutoSize = true;
            this.L_Spatial_GausR.Enabled = false;
            this.L_Spatial_GausR.Location = new System.Drawing.Point(65, 263);
            this.L_Spatial_GausR.Name = "L_Spatial_GausR";
            this.L_Spatial_GausR.Size = new System.Drawing.Size(43, 13);
            this.L_Spatial_GausR.TabIndex = 13;
            this.L_Spatial_GausR.Text = "Радиус";
            // 
            // L_Spatial_GausSigma
            // 
            this.L_Spatial_GausSigma.AutoSize = true;
            this.L_Spatial_GausSigma.Enabled = false;
            this.L_Spatial_GausSigma.Location = new System.Drawing.Point(201, 263);
            this.L_Spatial_GausSigma.Name = "L_Spatial_GausSigma";
            this.L_Spatial_GausSigma.Size = new System.Drawing.Size(39, 13);
            this.L_Spatial_GausSigma.TabIndex = 14;
            this.L_Spatial_GausSigma.Text = "Сигма";
            // 
            // MedianFilter
            // 
            this.MedianFilter.Controls.Add(this.B_MedianFiltering);
            this.MedianFilter.Controls.Add(this.NUD_Spartial_Height);
            this.MedianFilter.Controls.Add(this.NUD_Spartial_Width);
            this.MedianFilter.Controls.Add(this.L_Spartial_Height);
            this.MedianFilter.Controls.Add(this.L_Spartial_Width);
            this.MedianFilter.Controls.Add(this.L_Spartial_SizeMatrix);
            this.MedianFilter.Location = new System.Drawing.Point(4, 22);
            this.MedianFilter.Name = "MedianFilter";
            this.MedianFilter.Padding = new System.Windows.Forms.Padding(3);
            this.MedianFilter.Size = new System.Drawing.Size(326, 482);
            this.MedianFilter.TabIndex = 1;
            this.MedianFilter.Text = "Медианная";
            this.MedianFilter.UseVisualStyleBackColor = true;
            // 
            // B_MedianFiltering
            // 
            this.B_MedianFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_MedianFiltering.BackColor = System.Drawing.Color.LightGreen;
            this.B_MedianFiltering.Enabled = false;
            this.B_MedianFiltering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_MedianFiltering.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_MedianFiltering.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_MedianFiltering.Location = new System.Drawing.Point(7, 109);
            this.B_MedianFiltering.Name = "B_MedianFiltering";
            this.B_MedianFiltering.Size = new System.Drawing.Size(312, 38);
            this.B_MedianFiltering.TabIndex = 30;
            this.B_MedianFiltering.Text = "Выполнить";
            this.B_MedianFiltering.UseVisualStyleBackColor = false;
            this.B_MedianFiltering.Click += new System.EventHandler(this.B_MedianFiltering_Click);
            // 
            // NUD_Spartial_Height
            // 
            this.NUD_Spartial_Height.Enabled = false;
            this.NUD_Spartial_Height.Location = new System.Drawing.Point(212, 73);
            this.NUD_Spartial_Height.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_Spartial_Height.Name = "NUD_Spartial_Height";
            this.NUD_Spartial_Height.Size = new System.Drawing.Size(70, 20);
            this.NUD_Spartial_Height.TabIndex = 28;
            this.NUD_Spartial_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NUD_Spartial_Width
            // 
            this.NUD_Spartial_Width.Enabled = false;
            this.NUD_Spartial_Width.Location = new System.Drawing.Point(48, 73);
            this.NUD_Spartial_Width.Maximum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.NUD_Spartial_Width.Name = "NUD_Spartial_Width";
            this.NUD_Spartial_Width.Size = new System.Drawing.Size(70, 20);
            this.NUD_Spartial_Width.TabIndex = 27;
            this.NUD_Spartial_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Spartial_Height
            // 
            this.L_Spartial_Height.AutoSize = true;
            this.L_Spartial_Height.Location = new System.Drawing.Point(203, 57);
            this.L_Spartial_Height.Name = "L_Spartial_Height";
            this.L_Spartial_Height.Size = new System.Drawing.Size(88, 13);
            this.L_Spartial_Height.TabIndex = 14;
            this.L_Spartial_Height.Text = "Шаг вверх/вниз";
            // 
            // L_Spartial_Width
            // 
            this.L_Spartial_Width.AutoSize = true;
            this.L_Spartial_Width.Location = new System.Drawing.Point(33, 57);
            this.L_Spartial_Width.Name = "L_Spartial_Width";
            this.L_Spartial_Width.Size = new System.Drawing.Size(101, 13);
            this.L_Spartial_Width.TabIndex = 13;
            this.L_Spartial_Width.Text = "Шаг влево/вправо";
            // 
            // L_Spartial_SizeMatrix
            // 
            this.L_Spartial_SizeMatrix.AutoSize = true;
            this.L_Spartial_SizeMatrix.Enabled = false;
            this.L_Spartial_SizeMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Spartial_SizeMatrix.Location = new System.Drawing.Point(63, 16);
            this.L_Spartial_SizeMatrix.Name = "L_Spartial_SizeMatrix";
            this.L_Spartial_SizeMatrix.Size = new System.Drawing.Size(206, 20);
            this.L_Spartial_SizeMatrix.TabIndex = 12;
            this.L_Spartial_SizeMatrix.Text = "Задайте размер матрицы";
            // 
            // B_StartSpatialF
            // 
            this.B_StartSpatialF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_StartSpatialF.BackColor = System.Drawing.Color.LightGreen;
            this.B_StartSpatialF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_StartSpatialF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_StartSpatialF.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_StartSpatialF.Location = new System.Drawing.Point(54, 8);
            this.B_StartSpatialF.Name = "B_StartSpatialF";
            this.B_StartSpatialF.Size = new System.Drawing.Size(229, 42);
            this.B_StartSpatialF.TabIndex = 8;
            this.B_StartSpatialF.Text = "Начать";
            this.B_StartSpatialF.UseVisualStyleBackColor = false;
            // 
            // PB_OrigImageSpatial
            // 
            this.PB_OrigImageSpatial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_OrigImageSpatial.BackColor = System.Drawing.Color.LightGray;
            this.PB_OrigImageSpatial.Enabled = false;
            this.PB_OrigImageSpatial.Location = new System.Drawing.Point(6, 56);
            this.PB_OrigImageSpatial.Name = "PB_OrigImageSpatial";
            this.PB_OrigImageSpatial.Size = new System.Drawing.Size(335, 184);
            this.PB_OrigImageSpatial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_OrigImageSpatial.TabIndex = 7;
            this.PB_OrigImageSpatial.TabStop = false;
            // 
            // FrequencyFiltering
            // 
            this.FrequencyFiltering.Controls.Add(this.L_Freq_NewSize);
            this.FrequencyFiltering.Controls.Add(this.label13);
            this.FrequencyFiltering.Controls.Add(this.L_Freq_Size);
            this.FrequencyFiltering.Controls.Add(this.label9);
            this.FrequencyFiltering.Controls.Add(this.B_FreqToMain);
            this.FrequencyFiltering.Controls.Add(this.label14);
            this.FrequencyFiltering.Controls.Add(this.L_FreqY);
            this.FrequencyFiltering.Controls.Add(this.L_FreqX);
            this.FrequencyFiltering.Controls.Add(this.label11);
            this.FrequencyFiltering.Controls.Add(this.CB_FreqFalse);
            this.FrequencyFiltering.Controls.Add(this.CB_FreqTrue);
            this.FrequencyFiltering.Controls.Add(this.label10);
            this.FrequencyFiltering.Controls.Add(this.TB__Frequency_TextParam);
            this.FrequencyFiltering.Controls.Add(this.L_Frequency_Fourier);
            this.FrequencyFiltering.Controls.Add(this.B_FrequencyFilter);
            this.FrequencyFiltering.Controls.Add(this.PB_FourierImage);
            this.FrequencyFiltering.Controls.Add(this.L_Frequency_Factor);
            this.FrequencyFiltering.Controls.Add(this.L_Frequency_FilterArea);
            this.FrequencyFiltering.Controls.Add(this.PB_OrigImageFrequency);
            this.FrequencyFiltering.Controls.Add(this.B_StartFrequencyF);
            this.FrequencyFiltering.Location = new System.Drawing.Point(4, 40);
            this.FrequencyFiltering.Name = "FrequencyFiltering";
            this.FrequencyFiltering.Padding = new System.Windows.Forms.Padding(3);
            this.FrequencyFiltering.Size = new System.Drawing.Size(347, 760);
            this.FrequencyFiltering.TabIndex = 6;
            this.FrequencyFiltering.Text = "Частотная фильтрация";
            this.FrequencyFiltering.UseVisualStyleBackColor = true;
            // 
            // L_Freq_NewSize
            // 
            this.L_Freq_NewSize.AutoSize = true;
            this.L_Freq_NewSize.Location = new System.Drawing.Point(15, 312);
            this.L_Freq_NewSize.Name = "L_Freq_NewSize";
            this.L_Freq_NewSize.Size = new System.Drawing.Size(77, 13);
            this.L_Freq_NewSize.TabIndex = 48;
            this.L_Freq_NewSize.Text = "Width x Height";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 299);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Размер для фильтрации";
            // 
            // L_Freq_Size
            // 
            this.L_Freq_Size.AutoSize = true;
            this.L_Freq_Size.Location = new System.Drawing.Point(15, 284);
            this.L_Freq_Size.Name = "L_Freq_Size";
            this.L_Freq_Size.Size = new System.Drawing.Size(77, 13);
            this.L_Freq_Size.TabIndex = 46;
            this.L_Freq_Size.Text = "Width x Height";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Исходный размер";
            // 
            // B_FreqToMain
            // 
            this.B_FreqToMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_FreqToMain.BackColor = System.Drawing.Color.LightGreen;
            this.B_FreqToMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_FreqToMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_FreqToMain.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_FreqToMain.Location = new System.Drawing.Point(287, 707);
            this.B_FreqToMain.Name = "B_FreqToMain";
            this.B_FreqToMain.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.B_FreqToMain.Size = new System.Drawing.Size(43, 38);
            this.B_FreqToMain.TabIndex = 44;
            this.B_FreqToMain.Text = "←";
            this.B_FreqToMain.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 329);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Центр картинки";
            // 
            // L_FreqY
            // 
            this.L_FreqY.AutoSize = true;
            this.L_FreqY.Location = new System.Drawing.Point(15, 357);
            this.L_FreqY.Name = "L_FreqY";
            this.L_FreqY.Size = new System.Drawing.Size(15, 13);
            this.L_FreqY.TabIndex = 42;
            this.L_FreqY.Text = "y:";
            // 
            // L_FreqX
            // 
            this.L_FreqX.AutoSize = true;
            this.L_FreqX.Location = new System.Drawing.Point(15, 342);
            this.L_FreqX.Name = "L_FreqX";
            this.L_FreqX.Size = new System.Drawing.Size(18, 13);
            this.L_FreqX.TabIndex = 41;
            this.L_FreqX.Text = "x: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(126, 439);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "true = 1, false = 0";
            // 
            // CB_FreqFalse
            // 
            this.CB_FreqFalse.AutoSize = true;
            this.CB_FreqFalse.Enabled = false;
            this.CB_FreqFalse.Location = new System.Drawing.Point(15, 419);
            this.CB_FreqFalse.Name = "CB_FreqFalse";
            this.CB_FreqFalse.Size = new System.Drawing.Size(210, 17);
            this.CB_FreqFalse.TabIndex = 39;
            this.CB_FreqFalse.Text = "Не удовлетворяет условию фильтра";
            this.CB_FreqFalse.UseVisualStyleBackColor = true;
            // 
            // CB_FreqTrue
            // 
            this.CB_FreqTrue.AutoSize = true;
            this.CB_FreqTrue.Enabled = false;
            this.CB_FreqTrue.Location = new System.Drawing.Point(15, 396);
            this.CB_FreqTrue.Name = "CB_FreqTrue";
            this.CB_FreqTrue.Size = new System.Drawing.Size(272, 17);
            this.CB_FreqTrue.TabIndex = 38;
            this.CB_FreqTrue.Text = "Удовлетворяет условию фильтра (r1 >= pix >= r2)";
            this.CB_FreqTrue.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Пример записи: x y r1 r2";
            // 
            // TB__Frequency_TextParam
            // 
            this.TB__Frequency_TextParam.AcceptsTab = true;
            this.TB__Frequency_TextParam.Enabled = false;
            this.TB__Frequency_TextParam.Location = new System.Drawing.Point(153, 268);
            this.TB__Frequency_TextParam.Multiline = true;
            this.TB__Frequency_TextParam.Name = "TB__Frequency_TextParam";
            this.TB__Frequency_TextParam.Size = new System.Drawing.Size(188, 86);
            this.TB__Frequency_TextParam.TabIndex = 33;
            // 
            // L_Frequency_Fourier
            // 
            this.L_Frequency_Fourier.AutoSize = true;
            this.L_Frequency_Fourier.Location = new System.Drawing.Point(128, 470);
            this.L_Frequency_Fourier.Name = "L_Frequency_Fourier";
            this.L_Frequency_Fourier.Size = new System.Drawing.Size(80, 13);
            this.L_Frequency_Fourier.TabIndex = 31;
            this.L_Frequency_Fourier.Text = "Фурье - образ";
            // 
            // B_FrequencyFilter
            // 
            this.B_FrequencyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_FrequencyFilter.BackColor = System.Drawing.Color.LightGreen;
            this.B_FrequencyFilter.Enabled = false;
            this.B_FrequencyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_FrequencyFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_FrequencyFilter.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_FrequencyFilter.Location = new System.Drawing.Point(18, 707);
            this.B_FrequencyFilter.Name = "B_FrequencyFilter";
            this.B_FrequencyFilter.Size = new System.Drawing.Size(263, 38);
            this.B_FrequencyFilter.TabIndex = 30;
            this.B_FrequencyFilter.Text = "Выполнить";
            this.B_FrequencyFilter.UseVisualStyleBackColor = false;
            // 
            // PB_FourierImage
            // 
            this.PB_FourierImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_FourierImage.BackColor = System.Drawing.Color.LightGray;
            this.PB_FourierImage.Enabled = false;
            this.PB_FourierImage.Location = new System.Drawing.Point(15, 490);
            this.PB_FourierImage.Name = "PB_FourierImage";
            this.PB_FourierImage.Size = new System.Drawing.Size(315, 211);
            this.PB_FourierImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_FourierImage.TabIndex = 17;
            this.PB_FourierImage.TabStop = false;
            // 
            // L_Frequency_Factor
            // 
            this.L_Frequency_Factor.AutoSize = true;
            this.L_Frequency_Factor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Frequency_Factor.Location = new System.Drawing.Point(121, 373);
            this.L_Frequency_Factor.Name = "L_Frequency_Factor";
            this.L_Frequency_Factor.Size = new System.Drawing.Size(97, 20);
            this.L_Frequency_Factor.TabIndex = 16;
            this.L_Frequency_Factor.Text = "Множители";
            // 
            // L_Frequency_FilterArea
            // 
            this.L_Frequency_FilterArea.AutoSize = true;
            this.L_Frequency_FilterArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Frequency_FilterArea.Location = new System.Drawing.Point(97, 245);
            this.L_Frequency_FilterArea.Name = "L_Frequency_FilterArea";
            this.L_Frequency_FilterArea.Size = new System.Drawing.Size(149, 20);
            this.L_Frequency_FilterArea.TabIndex = 15;
            this.L_Frequency_FilterArea.Text = "Области фильтра";
            // 
            // PB_OrigImageFrequency
            // 
            this.PB_OrigImageFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_OrigImageFrequency.BackColor = System.Drawing.Color.LightGray;
            this.PB_OrigImageFrequency.Enabled = false;
            this.PB_OrigImageFrequency.Location = new System.Drawing.Point(6, 58);
            this.PB_OrigImageFrequency.Name = "PB_OrigImageFrequency";
            this.PB_OrigImageFrequency.Size = new System.Drawing.Size(335, 184);
            this.PB_OrigImageFrequency.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_OrigImageFrequency.TabIndex = 10;
            this.PB_OrigImageFrequency.TabStop = false;
            // 
            // B_StartFrequencyF
            // 
            this.B_StartFrequencyF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_StartFrequencyF.BackColor = System.Drawing.Color.LightGreen;
            this.B_StartFrequencyF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_StartFrequencyF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_StartFrequencyF.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.B_StartFrequencyF.Location = new System.Drawing.Point(57, 10);
            this.B_StartFrequencyF.Name = "B_StartFrequencyF";
            this.B_StartFrequencyF.Size = new System.Drawing.Size(229, 42);
            this.B_StartFrequencyF.TabIndex = 9;
            this.B_StartFrequencyF.Text = "Начать";
            this.B_StartFrequencyF.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 828);
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(1402, 867);
            this.MinimumSize = new System.Drawing.Size(1402, 867);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.ImageEditor.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.GradationTran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Binarization.ResumeLayout(false);
            this.Binarization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Koef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SizeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_OrigImageBinar)).EndInit();
            this.SpatialFiltering.ResumeLayout(false);
            this.TC_SpatialFilter.ResumeLayout(false);
            this.LinearFilter.ResumeLayout(false);
            this.LinearFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpatialGausSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SpatialGausR)).EndInit();
            this.MedianFilter.ResumeLayout(false);
            this.MedianFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Spartial_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Spartial_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_OrigImageSpatial)).EndInit();
            this.FrequencyFiltering.ResumeLayout(false);
            this.FrequencyFiltering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FourierImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_OrigImageFrequency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button B_Save;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage GradationTran;
        private System.Windows.Forms.Button B_GradTransReturnToOrig;
        private System.Windows.Forms.ComboBox CB_GradTranInterpolation;
        private System.Windows.Forms.TabPage ImageEditor;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Button B_CollectImages;
        internal System.Windows.Forms.Button B_AddImage;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button B_GradTransApply;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage Binarization;
        private System.Windows.Forms.Button B_StartBinarization;
        internal System.Windows.Forms.Button B_ApplyImage;
        private System.Windows.Forms.Button B_Binarization;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.PictureBox PB_OrigImageBinar;
        public System.Windows.Forms.CheckBox CB_BradleyRota;
        public System.Windows.Forms.CheckBox CB_ChristianWolfe;
        public System.Windows.Forms.CheckBox CB_Sauwolas;
        public System.Windows.Forms.CheckBox CB_Nibleck;
        public System.Windows.Forms.CheckBox CB_Otsu;
        public System.Windows.Forms.CheckBox CB_Gavrilov;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown NUD_Koef;
        public System.Windows.Forms.NumericUpDown NUD_SizeWindow;
        internal System.Windows.Forms.Label L_Time;
        internal System.Windows.Forms.Label L_SizeImage;
        private System.Windows.Forms.TabPage SpatialFiltering;
        internal System.Windows.Forms.PictureBox PB_OrigImageSpatial;
        internal System.Windows.Forms.Button B_StartSpatialF;
        internal System.Windows.Forms.TextBox TB_SpatialMatrix;
        private System.Windows.Forms.Button B_LinearFiltering;
        internal System.Windows.Forms.NumericUpDown NUD_SpatialGausSigma;
        internal System.Windows.Forms.NumericUpDown NUD_SpatialGausR;
        internal System.Windows.Forms.CheckBox CB_GaussFilter;
        internal System.Windows.Forms.Label L_Spatial_Matrix;
        internal System.Windows.Forms.Label L_Spatial_GausSigma;
        internal System.Windows.Forms.Label L_Spatial_GausR;
        internal System.Windows.Forms.Label L_Spatial_MatrixSum;
        internal System.Windows.Forms.TabControl TC_SpatialFilter;
        private System.Windows.Forms.TabPage LinearFilter;
        private System.Windows.Forms.TabPage MedianFilter;
        internal System.Windows.Forms.Button B_MedianFiltering;
        internal System.Windows.Forms.NumericUpDown NUD_Spartial_Height;
        internal System.Windows.Forms.NumericUpDown NUD_Spartial_Width;
        internal System.Windows.Forms.Label L_Spartial_Height;
        internal System.Windows.Forms.Label L_Spartial_Width;
        internal System.Windows.Forms.Label L_Spartial_SizeMatrix;
        private System.Windows.Forms.TabPage FrequencyFiltering;
        internal System.Windows.Forms.PictureBox PB_OrigImageFrequency;
        internal System.Windows.Forms.Button B_StartFrequencyF;
        private System.Windows.Forms.Label L_Frequency_Fourier;
        private System.Windows.Forms.Button B_FrequencyFilter;
        internal System.Windows.Forms.PictureBox PB_FourierImage;
        internal System.Windows.Forms.Label L_Frequency_Factor;
        internal System.Windows.Forms.Label L_Frequency_FilterArea;
        internal System.Windows.Forms.TextBox TB__Frequency_TextParam;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.CheckBox CB_FreqFalse;
        internal System.Windows.Forms.CheckBox CB_FreqTrue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label L_FreqY;
        internal System.Windows.Forms.Label L_FreqX;
        internal System.Windows.Forms.Button B_FreqToMain;
        internal System.Windows.Forms.Label L_Freq_NewSize;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label L_Freq_Size;
        private System.Windows.Forms.Label label9;
    }
}

