using DIS.Filtration.Frequency;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Manager.FormManager
{
    public static class ManagerFrequencyFilter
    {
        public static PictureBox PB_MainImage;
        public static PictureBox PB_FrequencyImage;
        public static PictureBox PB_FourierImage;
        public static Label L_SizeImage;
        public static Label L_Time;
        public static Label L_X;
        public static Label L_Y;
        public static Label L_SizeImageFilter;
        public static Label L_NewSizeImageFilter;
        public static Button B_Start;
        public static Button B_Execute;
        public static Button B_ToMainImage;
        public static TextBox TB_TextParam;
        public static CheckBox CB_filterTrue;
        public static CheckBox CB_filterFalse;

        private const string textTime = "Время обработки изображения: ";
        private const string textSizeImage = "Размер изображения: ";

        //действие при нажатии кнопки начать
        private static bool start = false;
        private static int StartWidth = 0;
        private static int StartHeight = 0;
        public static void Button_Start(object sender, EventArgs e)
        {
            if(PB_MainImage.Image == null)
            {
                ManagerError.ErrorOK("Добавьте картинку на главный экран!");
                return;
            }

            if (!start)
            {
                B_Start.Text = "Изменить";
                TB_TextParam.Enabled = true;
                CB_filterTrue.Enabled = true;
                CB_filterFalse.Enabled = true;
                CB_filterTrue.Checked = true;
                PB_FourierImage.Enabled = true;
                B_Execute.Enabled = true;
                start = true;
            }

            Button_ToMainOff();

            StartWidth = PB_MainImage.Image.Width;
            StartHeight = PB_MainImage.Image.Height;
            if (StartWidth % 2 != 0) ++StartWidth;
            if (StartHeight % 2 != 0) ++StartHeight;

            int w = (int)GeneralOperation.clp2(StartWidth);
            int h = (int)GeneralOperation.clp2(StartHeight);
            w = h = (new List<int>() { w, h }).Max();
            L_SizeImageFilter.Text = PB_MainImage.Image.Width.ToString() + " x " + PB_MainImage.Image.Height.ToString();
            L_NewSizeImageFilter.Text = w.ToString() + " x " + h.ToString();

            if (PB_FrequencyImage.Image != null) PB_FrequencyImage.Image.Dispose();
            PB_FrequencyImage.Image = new Bitmap(PB_MainImage.Image, new Size(w, h));
            L_X.Text = "x: " + (w / 2).ToString();
            L_Y.Text = "y: " + (h / 2).ToString();

            if (resultPicture != null) resultPicture.Dispose();
        }

        //действие при нажатии кнопки выполнить
        public static void Button_Execute(object sender, EventArgs e)
        {
            if (PB_FrequencyImage.Image == null) return;
            Button_ToMainOff();

            //считываем данные с поля
            var param = ReadText();
            if (param == null) return;

            //получаем размеры картинки
            int width = PB_FrequencyImage.Image.Width;
            int height = PB_FrequencyImage.Image.Height;

            //считываем другие данные
            int checkTrue = 0, checkFalse = 0;
            if (CB_filterTrue.Checked) checkTrue = 1;
            if (CB_filterFalse.Checked) checkFalse = 1;

            Image tmp = new Bitmap(PB_FrequencyImage.Image, new Size(width, height));

            //яркость пикселя в фурье-образе
            double Brightness = 1;
            //запуск таймера
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            (Image image, Image FourierImage) = FrequencyFilters.ApplyFilter(tmp, param, Brightness, checkTrue, checkFalse);

            //остановка таймера
            sWatch.Stop();

            //выводим результат
            if (PB_MainImage.Image != null) PB_MainImage.Image.Dispose();
            PB_MainImage.Image = new Bitmap(image, new Size(StartWidth, StartHeight));
            image.Dispose();

            if (PB_FourierImage.Image != null) PB_FourierImage.Image.Dispose();
            PB_FourierImage.Image = FourierImage;

            //выводим время обработки и размеры картинки
            L_SizeImage.Text = textSizeImage + StartWidth.ToString() + " x " + StartHeight.ToString();
            L_Time.Text = textTime + sWatch.ElapsedMilliseconds.ToString() + " мс.";
            L_Time.Visible = true;
            L_SizeImage.Visible = true;

            tmp.Dispose();
        }

        //вывод фурье образа на главный экран
        private static Image resultPicture = null;
        public static void Button_ToMain(object sender, EventArgs e)
        {
            if (resultPicture == null)
            {
                resultPicture = (Image)PB_MainImage.Image.Clone();
                if (PB_MainImage.Image != null) PB_MainImage.Image.Dispose();

                PB_MainImage.Image = (Image)PB_FourierImage.Image.Clone();

                B_ToMainImage.BackColor = Color.LimeGreen;
            }
            else
            {
                if (PB_MainImage.Image != null) PB_MainImage.Image.Dispose();
                PB_MainImage.Image = resultPicture;
                resultPicture = null;

                B_ToMainImage.BackColor = Color.LightGreen;
            }
        }
        private static void Button_ToMainOff()
        {
            if (resultPicture != null) resultPicture.Dispose();
            resultPicture = null;
            B_ToMainImage.BackColor = Color.LightGreen;
        }
        //считывание данных с текстового поля
        private static List<Filter> ReadText()
        {
            string text = TB_TextParam.Text;

            //удаляет повторяющиеся пробельные символы
            text = Regex.Replace(text, @" +", " ");
            //удаляет символы вначале и в конце строки
            text = text.Trim(new char[] { '\r', '\n', ' ' });

            //прокерка строки на содержание только определенных символов
            if (!Regex.IsMatch(text, "^[\n\r 0-9]*$"))
            {
                ManagerError.ErrorOK("В текстовом поле содержатся запрещенные символы!\n Доступны только символы: ' ', '0-9'");
                return null;
            }

            //делим строку на подстроки
            string[] TextRows = Regex.Split(text, "\r\n");
            List<Filter> param = new List<Filter>();

            try
            {
                for (int i = 0; i < TextRows.Length; ++i)
                {
                    TextRows[i] = TextRows[i].Trim(' ');
                    string[] digits = Regex.Split(TextRows[i], " ");
                    if (digits.Length > 5)
                    {
                        ManagerError.ErrorOK("Неверный формат строки!");
                        return null;
                    }

                    List<int> IntDigit = new List<int>();
                    for (int j = 0; j < digits.Length; ++j)
                    {
                        int number;
                        bool flag = Int32.TryParse(digits[j], out number);
                        if (!flag)
                        {
                            ManagerError.ErrorOK("Неверный формат строки!");
                            return null;
                        }
                        IntDigit.Add(number);
                    }

                    param.Add(new Filter(IntDigit[0], IntDigit[1], IntDigit[2], IntDigit[3]));
                }
            }
            catch
            {
                ManagerError.ErrorOK("Произошла ошибка при обработки текстового поля!");
                return null;
            }

            return param;
        }
    }
}
