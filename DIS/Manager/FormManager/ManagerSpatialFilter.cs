using DIS.SpatialFiltering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Manager.FormManager
{
    public static class ManagerSpatialFilter
    {
        //<!-- общие -->

        //контейнер с главной картинкой
        public static PictureBox PB_MainImage = null;
        //контейнер для начальной картинки
        public static PictureBox PB_OriginImage = null;
        //прогресс бар
        public static ProgressBar PrB_ProgressBar = null;
        //для изменение картинки в градационных преобразованиях
        public static MyCanvas Canvas = null;
        //label для вывода информации о затраченом времени
        public static Label L_Time = null;
        //label для вывода информации о размере изображения
        public static Label L_SizeImage = null;
        //кнопка начать/изменить 
        public static Button B_StartChange = null;

        //<!-- для линейной фильтрации -->

        //текстовое поле для задания матрицы
        public static TextBox TB_Matrix = null;
        //чекбокс для заполнение матрицы Гауссовским фильтром
        public static CheckBox CB_CheckGauss = null;
        //изменение радиуса для задания матрицы для Гауссова фильтра
        public static NumericUpDown NUD_Сhange_R = null;
        //изменение sigma для Гауссова фильтра
        public static NumericUpDown NUD_Change_Sigma = null;
        //кнопка для выполнения фильтрации
        public static Button B_LinearFilter = null;
        //label 
        public static Label L_TextSigma = null;
        public static Label L_TextR = null;
        public static Label L_TextMatrix = null;
        public static Label L_TextSumMatrix = null;

        //<!-- для медианной фильтрации -->

        //кнопка для выполнения фильтрации
        public static Button B_MedianFilter = null;
        //изменение ширины и высоты матрицы
        public static NumericUpDown NUD_Change_Width = null;
        public static NumericUpDown NUD_Change_Height = null;
        //label
        public static Label L_TextMatrixSize = null;
        public static Label L_TextWidth = null;
        public static Label L_TextHeight = null;

        //матрица с распределением по Гауссу
        private static double[,] GaussMatrix = null;
        private const string textSum = "Сумма матрицы: ";
        private const string textTime = "Время обработки изображения: ";
        private const string textSizeImage = "Размер изображения: ";

        //классик для упрощения работы с данными полученными при чтении матрицы
        private class ResultReadMatrix
        {
            public double[,] matrix { get; private set; }
            public int row { get; private set; }
            public int col { get; private set; }
            public string text { get; private set; }
            public bool status { get; private set; }

            public ResultReadMatrix(double[,] matrix, int row, int col)
            {
                this.matrix = matrix;
                this.row = row;
                this.col = col;
                this.status = true;
                text = "Все хорошо!";
            }
            public ResultReadMatrix(string error)
            {
                this.matrix = null;
                this.row = 0;
                this.col = 0;
                this.status = false;
                this.text = error;
            }
        }

        private static bool active = false;
        //активирует выполнение фильтрации, а в последствии изменяет стартовую картинку
        public static void Button_Start(object sender, EventArgs e)
        {
            //проверка на пустоту стартовой картинки
            if (PB_MainImage.Image == null)
            {
                ManagerError.ErrorOK("Нет начальной картинки! Выведите изображение на главный экран!");
                return;
            }

            //изменяем картинку
            if (PB_OriginImage.Image != null) PB_OriginImage.Image.Dispose();
            PB_OriginImage.Image = (Image)PB_MainImage.Image.Clone();

            //действие при первом нажатии
            if (!active)
            {
                active = true;

                //<!-- линейная фильтрация -->
                TB_Matrix.Enabled = true;
                CB_CheckGauss.Enabled = true;
                B_LinearFilter.Enabled = true;
                L_TextMatrix.Enabled = true;

                //<!-- медианная фильтрация -->
                B_MedianFilter.Enabled = true;
                L_TextMatrixSize.Enabled = true;
                L_TextWidth.Enabled = true;
                L_TextHeight.Enabled = true;
                NUD_Change_Width.Enabled = true;
                NUD_Change_Height.Enabled = true;

                B_StartChange.Text = "Изменить";
                return;
            }
        }

        //выполняется при изменении чекбокса для активации Гауссова фильтра
        public static void CheckBox_ChacngeActive(object sender, EventArgs e)
        {
            if (CB_CheckGauss.Checked)
            {
                NUD_Сhange_R.Enabled = true;
                NUD_Change_Sigma.Enabled = true;
                L_TextR.Enabled = true;
                L_TextSigma.Enabled = true;
                L_TextSumMatrix.Enabled = true;

                NUD_Сhange_R.Value = 1;
                NUD_Change_Sigma.Value = 1;

                int R = (int)NUD_Сhange_R.Value;
                double sigma = (double)NUD_Change_Sigma.Value;

                //заполнить матрицу распределением по Гауссу
                var result = GaussianFilter.MatrixGaussianFilter(R, sigma);
                GaussMatrix = result.matrix;
                L_TextSumMatrix.Text = textSum + Math.Round(result.sum, GaussianFilter.RoundNumber).ToString();
                //заполняем textBox с матрицей
                WriteTextToMatrix(result.matrix, R * 2 + 1, R * 2 + 1);
                return;
            }

            L_TextR.Enabled = false;
            L_TextSigma.Enabled = false;
            NUD_Сhange_R.Enabled = false;
            NUD_Change_Sigma.Enabled = false;
            L_TextSumMatrix.Enabled = false;
            L_TextSumMatrix.Text = textSum;

            //убираем ссылку на матрицу
            GaussMatrix = null;
        }

        //выполняется при изменении радиуса или sigma
        public static void NUD_ValueChanged(object sender, EventArgs e)
        {
            int R = (int)NUD_Сhange_R.Value;
            double sigma = (double)NUD_Change_Sigma.Value;

            //заполнить матрицу распределением по Гауссу
            var result = GaussianFilter.MatrixGaussianFilter(R, sigma);
            GaussMatrix = result.matrix;
            L_TextSumMatrix.Text = textSum + Math.Round(result.sum, GaussianFilter.RoundNumber).ToString();
            //заполняем textBox с матрицей
            WriteTextToMatrix(result.matrix, R * 2 + 1, R * 2 + 1);
        }

        //заполняем textBox с матрицей
        private static void WriteTextToMatrix(double[,] matrix, int row, int col)
        {
            TB_Matrix.Clear();
            for(int i = 0; i < row; ++i)
            {
                for(int j = 0; j < col; ++j)
                {
                    TB_Matrix.AppendText(matrix[i, j].ToString("F" + GaussianFilter.RoundNumber.ToString()) + " ");
                }
                TB_Matrix.AppendText(Environment.NewLine);
            }
        }

        //выполнить линейную фильтрацию
        public static void Button_ExecuteLinearFilter(object sender, EventArgs e)
        {
            double[,] matrix;
            int row, col;
            //проверка, активирован ли Гаусс
            if (CB_CheckGauss.Checked)
            {
                int r = (int)NUD_Сhange_R.Value;
                matrix = GaussMatrix;
                row = col = r * 2 + 1;

                if (row % 2 == 0)
                {
                    ManagerError.ErrorOK("Длина и ширина матрицы должна быть нечетным числом!");
                    return;
                }
            }
            else
            {
                var result = ReadTextForMatrix();
                if (!result.status)
                {
                    ManagerError.ErrorOK(result.text);
                    return;
                }

                //проверка числе на нечетность
                if (result.row % 2 == 0 || result.col % 2 == 0)
                {
                    ManagerError.ErrorOK("Длина и ширина матрицы должна быть нечетным числом!");
                    return;
                }

                matrix = result.matrix;
                col = result.col;
                row = result.row;
            }

            //если все хорошо, то выполняем обработку картинки
            if(PB_OriginImage.Image == null)
            {
                ManagerError.ErrorOK("Картинка не добавлена!");
                return;
            }

            //блокируем кнопку
            B_LinearFilter.Enabled = false;

            Image tmp = new Bitmap(PB_OriginImage.Image);
            (Image bmp, double time) = LinearFiltering.ApplyFilter(tmp, matrix, row, col);

            if (PB_MainImage.Image != null) PB_MainImage.Image.Dispose();
            PB_MainImage.Image = bmp;

            L_SizeImage.Text = textSizeImage + tmp.Width.ToString() + " x " + tmp.Height.ToString();
            L_Time.Text = textTime + time + " мс.";
            L_Time.Visible = true;
            L_SizeImage.Visible = true;

            B_LinearFilter.Enabled = true;
            tmp.Dispose();
        }

        //выполнить медианную фильтрацию
        public static void Button_ExecuteMedianFilter(object sender, EventArgs e)
        {
            int wigth = (int)NUD_Change_Width.Value * 2 + 1;
            int heigth = (int)NUD_Change_Height.Value * 2 + 1;

            //проверка числе на нечетность
            if (wigth % 2 == 0 || heigth % 2 == 0)
            {
                ManagerError.ErrorOK("Длина и ширина матрицы должна быть нечетным числом!");
                return;
            }

            //если все хорошо, то выполняем обработку картинки
            if (PB_OriginImage.Image == null)
            {
                ManagerError.ErrorOK("Картинка не добавлена!");
                return;
            }

            //блокируем кнопку
            B_MedianFilter.Enabled = false;

            Image tmp = new Bitmap(PB_OriginImage.Image);
            (Image bmp, double time) = MedianFiltering.ApplyFilter(tmp, heigth, wigth);

            if (PB_MainImage.Image != null) PB_MainImage.Image.Dispose();
            PB_MainImage.Image = bmp;

            L_SizeImage.Text = textSizeImage + tmp.Width.ToString() + " x " + tmp.Height.ToString();
            L_Time.Text = textTime + time + " мс.";
            L_Time.Visible = true;
            L_SizeImage.Visible = true;

            B_MedianFilter.Enabled = true;
            tmp.Dispose();
        }

        //считывание данных и заполнение матрицы
        private static ResultReadMatrix ReadTextForMatrix()
        {
            try
            {
                string text = TB_Matrix.Text;
                //меняем все точки на запятые
                text = text.Replace(".", ",");
                //удаляет повторяющиеся пробельные символы
                text = Regex.Replace(text, @" +", " ");
                //удаляет символы вначале и в конце строки
                text = text.Trim(new char[] { '\r', '\n', ' ' });

                //прокерка строки на содержание только определенных символов
                if (!Regex.IsMatch(text, "^[-/.,\n\r 0-9]*$"))
                {
                    return new ResultReadMatrix("В матрице содержаться запрещенные символы!\n Доступны только символы: ' ', ',', '.', '/', '0-9'");
                }

                //делим строку на подстроки
                string[] TextRows = Regex.Split(text, "\r\n");
                List<List<double>> MatrixDigits = new List<List<double>>();

                for (int i = 0; i < TextRows.Count(); ++i)
                {
                    TextRows[i] = TextRows[i].Trim(' ');
                    string[] digits = Regex.Split(TextRows[i], " ");
                    List<double> RowDigits = new List<double>();

                    for (int j = 0; j < digits.Count(); ++j)
                    {
                        //проверка на запись числа через дробь
                        if (digits[j].Contains('/'))
                        {
                            string[] TwoDigits = Regex.Split(digits[j], "/");
                            double one, two;
                            bool flag1 = Double.TryParse(TwoDigits[0], out one);
                            bool flag2 = Double.TryParse(TwoDigits[1], out two);
                            //проверка на ошибку
                            if (!flag1 || !flag2 || two == 0)
                            {
                                return new ResultReadMatrix("Произошла ошибка при обработки числа записанного через дробь в матрице!");
                            }
                            RowDigits.Add(one / two);
                        }
                        else
                        {
                            double digit;
                            bool flag = Double.TryParse(digits[j], out digit);
                            //проверка на ошибку
                            if (!flag) return new ResultReadMatrix("Произошла ошибка при обработки чисел в матрице!");
                            RowDigits.Add(digit);
                        }
                    }

                    MatrixDigits.Add(RowDigits);
                }

                //переносим данные в массив
                List<int> col = new List<int>();
                for (int i = 0; i < MatrixDigits.Count(); ++i)
                {
                    col.Add(MatrixDigits[i].Count());
                }
                int max = col.Max();
                int min = col.Min();
                if (max != min) return new ResultReadMatrix("Криво записана матрица!");

                double[,] matrix = new double[MatrixDigits.Count(), max];
                for (int i = 0; i < MatrixDigits.Count(); ++i)
                {
                    for(int j = 0; j < max; ++j)
                    {
                        matrix[i, j] = MatrixDigits[i][j];
                    }
                }
                
                return new ResultReadMatrix(matrix, MatrixDigits.Count(), max);
            }
            catch
            {
                return new ResultReadMatrix("В результате оработки матрицы произошла непредвиденная ошибка!");
            }
        }
    }
}
