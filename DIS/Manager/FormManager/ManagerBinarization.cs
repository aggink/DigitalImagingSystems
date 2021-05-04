using DIS.Binarization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Manager
{
    public static class ManagerBinarization
    {
        public static bool start { get; private set; } = false;
        public static Button ButtonBinar = null;
        public static Button ButtonResult = null;
        public static ProgressBar ProgressBar = null;
        public static PictureBox ImageBinar = null;
        public static PictureBox MainImage = null;
        public static CheckBox CB_Gavrilov = null;
        public static CheckBox CB_Otsu = null;
        public static CheckBox CB_Nibleck = null;
        public static CheckBox CB_Sauwolas = null;
        public static CheckBox CB_ChristianWolfe = null;
        public static CheckBox CB_BradleyRota = null;
        public static NumericUpDown NUD_Size = null;
        public static NumericUpDown NUD_KorA = null;
        public static MyCanvas Canvas = null;

        private static Size SizeCheckBox = new Size(320, 240);
        private static Image Image = null;
        //0 - White, 255 - Black
        private static int CheckColor = 0;
        private class Param
        {
            public int size { get; } = 3;
            public decimal k { get; }
            public decimal min { get; }
            public decimal max { get; }
            public Param(decimal k, decimal min, decimal max)
            {
                this.k = k;
                this.min = min;
                this.max = max;
            }
        }
        //старторые параметры, а также их границы
        private static Param P_Nibleck = new Param(-0.2m, -10, 10);
        private static Param P_Sauwolas = new Param(0.2m, 0.2m, 0.5m);
        private static Param P_ChristianWolfe = new Param(0.5m, 0, 1);
        private static Param P_BradleyRote = new Param(0.15m, 0, 1);

        //начать или остановить бинаризацию
        public static void StartOrStopBinar()
        {
            if(MainImage.Image == null)
            {
                ManagerError.ErrorOK("Выведите изображение на главный экран!");
                return;
            }

            List<CheckBox> checks = new List<CheckBox>(){ CB_Gavrilov, CB_Otsu, CB_Nibleck, CB_Sauwolas, CB_ChristianWolfe, CB_BradleyRota };
            if (!start)
            {
                if (ImageBinar.Image != null) ImageBinar.Image.Dispose();
                ImageBinar.Image = WorkImage.ConvertToGrayscale(MainImage.Image);

                if (Image != null) Image.Dispose();
                Image = (Image)MainImage.Image.Clone();

                //выполняем все виды бинаризации
                UpdateBinar();

                //активируем бинаризацию
                foreach (var x in checks)
                {
                    x.Enabled = true;
                }

                ButtonBinar.Text = "Изменить";
                start = true;
            }
            else
            {
                if (ImageBinar.Image != null) ImageBinar.Image.Dispose();
                ImageBinar.Image = WorkImage.ConvertToGrayscale(MainImage.Image);

                if (Image != null) Image.Dispose();
                Image = (Image)MainImage.Image.Clone();

                //выполняем все виды бинаризации
                UpdateBinar();
            }
        }

        //применяем бинаризацию
        public static async void PerformBinar()
        { 
            ProgressBar.Value = 0;
            ButtonResult.Enabled = false;

            if (!ManagerBinarization.start)
            {
                ManagerError.ErrorOK("Нажмите кнопку 'начать' во вкладке 'Бинаризация' для актиавации бинаризации");
                return;
            }

            List<CheckBox> checks = new List<CheckBox>() { CB_Gavrilov, CB_Otsu, CB_Nibleck, CB_Sauwolas, CB_ChristianWolfe, CB_BradleyRota };
            CheckBox check = checks.FirstOrDefault(x => x.Checked);
            if (check == null)
            {
                ManagerError.ErrorOK("Не выбран критерий бинаризации");
                return;
            }

            Image image = null;
            Image tmp = new Bitmap(Image);
            switch (check.Name)
            {
                case "CB_Gavrilov":
                    image = await Task.Run(() => Gavrilov.Binarization(tmp, CheckColor));
                    break;
                case "CB_Otsu":
                    image = await Task.Run(() => Otsu.Binarization(tmp, CheckColor));
                    break;
                case "CB_Nibleck":
                    image = await Task.Run(() => Nibleck.Binarization(tmp, (int)NUD_Size.Value, (double)NUD_KorA.Value, CheckColor));
                    break;
                case "CB_Sauwolas":
                    image = await Task.Run(() => Sauwolas.Binarization(tmp, (int)NUD_Size.Value, (double)NUD_KorA.Value, CheckColor));
                    break;
                case "CB_ChristianWolfe":
                    image = await Task.Run(() => ChristianWolfe.Binarization(tmp, (int)NUD_Size.Value, (double)NUD_KorA.Value, CheckColor));
                    break;
                case "CB_BradleyRota":
                    image = await Task.Run(() => BradleyRota.Binarization(tmp, (int)NUD_Size.Value, (double)NUD_KorA.Value, CheckColor));
                    break;
            }

            if (image != null)
            {
                if (MainImage.Image != null) MainImage.Image.Dispose();
                MainImage.Image = (Image)image.Clone();

                if (Canvas.Image != null) Canvas.Image.Dispose();
                Canvas.Image = (Image)image.Clone();
                Canvas.Clear();

                image.Dispose();

                ButtonResult.Enabled = true;
            }

            tmp.Dispose();
            ProgressBar.Value = 100;
        }

        //выбираем нужный критерий бинаризации
        public static void CB_Checked(object sender, EventArgs e)
        {
            //получаем выбранный чекбокс
            var item = sender as CheckBox;
            if (!item.Checked) return;

            //настраиваем некоторые параметры для определенних критериев бинамиризации
            switch (item.Name)
            {
                case "CB_Gavrilov": 
                case "CB_Otsu":
                    NUD_Size.Enabled = false;
                    NUD_KorA.Enabled = false;
                    break;
                case "CB_Nibleck":
                    NUD_Size.Enabled = true;
                    NUD_KorA.Enabled = true;
                    NUD_Size.Value = P_Nibleck.size;
                    NUD_KorA.Maximum = P_Nibleck.max;
                    NUD_KorA.Minimum = P_Nibleck.min;
                    NUD_KorA.Value = P_Nibleck.k;
                    break;
                case "CB_Sauwolas":
                    NUD_Size.Enabled = true;
                    NUD_KorA.Enabled = true;
                    NUD_Size.Value = P_Sauwolas.size;
                    NUD_KorA.Maximum = P_Sauwolas.max;
                    NUD_KorA.Minimum = P_Sauwolas.min;
                    NUD_KorA.Value = P_Sauwolas.k;
                    break;
                case "CB_ChristianWolfe":
                    NUD_Size.Enabled = true;
                    NUD_KorA.Enabled = true;
                    NUD_Size.Value = P_ChristianWolfe.size;
                    NUD_KorA.Maximum = P_ChristianWolfe.max;
                    NUD_KorA.Minimum = P_ChristianWolfe.min;
                    NUD_KorA.Value = P_ChristianWolfe.k;
                    break;
                case "CB_BradleyRota":
                    NUD_Size.Enabled = true;
                    NUD_KorA.Enabled = true;
                    NUD_Size.Value = P_BradleyRote.size;
                    NUD_KorA.Maximum = P_BradleyRote.max;
                    NUD_KorA.Minimum = P_BradleyRote.min;
                    NUD_KorA.Value = P_BradleyRote.k;
                    break;
            }

            //проходим по всем чекбоксам, и отменяем все, кроме выбранного
            List<CheckBox> checks = new List<CheckBox>() { CB_Gavrilov, CB_Otsu, CB_Nibleck, CB_Sauwolas, CB_ChristianWolfe, CB_BradleyRota };
            foreach(var x in checks)
            {
                if (x.Name != item.Name)
                {
                    x.Checked = false;
                }
            }
        }

        //обновляем всю бинаризацию
        public async static void UpdateBinar()
        {
            NUD_KorA.Enabled = false;
            NUD_Size.Enabled = false;

            ButtonResult.Enabled = false;

            int width = (int)Math.Round(ImageBinar.Image.Width / (double)(ImageBinar.Image.Height / (SizeCheckBox.Height * 1.0)));
            int height = SizeCheckBox.Height;

            Image tmp = new Bitmap(Image, width, height);

            if (CB_Gavrilov.BackgroundImage != null) CB_Gavrilov.BackgroundImage.Dispose();
            CB_Gavrilov.BackgroundImage = await Task.Run(()=> Gavrilov.Binarization(tmp, CheckColor));

            if (CB_Otsu.BackgroundImage != null) CB_Otsu.BackgroundImage.Dispose();
            CB_Otsu.BackgroundImage = await Task.Run(() => Otsu.Binarization(tmp, CheckColor));

            if (CB_Nibleck.BackgroundImage != null) CB_Nibleck.BackgroundImage.Dispose();
            CB_Nibleck.BackgroundImage = await Task.Run(() => Nibleck.Binarization(tmp, (int)P_Nibleck.size, (double)P_Nibleck.k, CheckColor));

            if (CB_Sauwolas.BackgroundImage != null) CB_Sauwolas.BackgroundImage.Dispose();
            CB_Sauwolas.BackgroundImage = await Task.Run(() => Sauwolas.Binarization(tmp, (int)P_Sauwolas.size, (double)P_Sauwolas.k, CheckColor));

            if (CB_ChristianWolfe.BackgroundImage != null) CB_ChristianWolfe.BackgroundImage.Dispose();
            CB_ChristianWolfe.BackgroundImage = await Task.Run(() => ChristianWolfe.Binarization(tmp, (int)P_ChristianWolfe.size, (double)P_ChristianWolfe.k, CheckColor));

            if (CB_BradleyRota.BackgroundImage != null) CB_BradleyRota.BackgroundImage.Dispose();
            CB_BradleyRota.BackgroundImage = await Task.Run(() => BradleyRota.Binarization(tmp, P_BradleyRote.size, (double)P_BradleyRote.k, CheckColor));

            ButtonResult.Enabled = true;

            tmp.Dispose();
        }

        //действия при изменении размера окна или чувствительности
        public static void NUD_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)NUD_Size.Value;
            double k = (double)NUD_KorA.Value;

            int width = (int)Math.Round(ImageBinar.Image.Width / (double)(ImageBinar.Image.Height / (SizeCheckBox.Height * 1.0)));
            int height = SizeCheckBox.Height;

            Image tmp1 = new Bitmap(Image, width, height);
            Image tmp2 = new Bitmap(Image, width, height);
            Image tmp3 = new Bitmap(Image, width, height);
            Image tmp4 = new Bitmap(Image, width, height);

            Parallel.For(0, 4, i =>
            {
                switch (i)
                {
                    case 0:
                        if (CB_Nibleck.BackgroundImage != null) CB_Nibleck.BackgroundImage.Dispose();
                        CB_Nibleck.BackgroundImage = Nibleck.Binarization(tmp1, size, k, CheckColor);
                        break;
                    case 1:
                        if (CB_Sauwolas.BackgroundImage != null) CB_Sauwolas.BackgroundImage.Dispose();
                        CB_Sauwolas.BackgroundImage = Sauwolas.Binarization(tmp2, size, k, CheckColor);
                        break;
                    case 2:
                        if (CB_ChristianWolfe.BackgroundImage != null) CB_ChristianWolfe.BackgroundImage.Dispose();
                        CB_ChristianWolfe.BackgroundImage = ChristianWolfe.Binarization(tmp3, size, k, CheckColor);
                        break;
                    case 3:
                        if (CB_BradleyRota.BackgroundImage != null) CB_BradleyRota.BackgroundImage.Dispose();
                        CB_BradleyRota.BackgroundImage = BradleyRota.Binarization(tmp4, size, k, CheckColor);
                        break;
                }
            });

            tmp1.Dispose();
            tmp2.Dispose();
            tmp3.Dispose();
            tmp4.Dispose();
        }
    }
}
