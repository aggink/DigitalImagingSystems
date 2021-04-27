using DIS.Interpolation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DIS.Manager
{
    public class MyCanvas : Control
    {
        //Таймер для ее обновления
        private System.Windows.Forms.Timer timer;

        //битмапы на которых будем рисовать в 2 слоя.
        //На первом будет само содержаение
        //На втором курсор.
        private Bitmap layer1;
        private Bitmap layer2;

        //Графиксы для этих битмапов
        private Graphics g_layer1;
        private Graphics g_layer2;

        private bool painting_mode = false;

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);

        //<!--- мое --->

        //расчитать в привычном разрешении картинки
        private bool transform_сompleted = false;

        //создаем список, где будут храниться наши точки и задем двекрайние точки
        public List<Point> points = new List<Point>()
        {
            new Point(0, 0),
            new Point(255, 255)
        };
        //размер точки
        private readonly Size SizePoint = new Size(14, 14);
        //координаты точки, которую хотим передвинуть
        private Point PointMove;
        public Image Image { get; set; }
        //ссылка на контейнер с изображением
        public PictureBox pictureBox { get; set; }
        //ссылка на контейнер для выбор уравнения задания графика
        public ComboBox comboBox { get; set; }
        //ссылка на контейнер с гистограммой
        public Chart chart { get; set; }
        public Panel panel { get; set; }
        private readonly Color ColorPoint = Color.FromArgb(255, 145, 239, 145);
        private readonly Pen MyPen = new Pen(Color.FromArgb(255, 211, 211, 211), 2);

        //Параллельное выполнение задач может занимать много времени.
        //И иногда может возникнуть необходимость прервать выполняемую задачу.
        //Для этого .NET предоставляет класс CancellationToken
        //Для отмены операции нам надо создать и использовать токен. 
        //Вначале создается объект CancellationTokenSource:
        //static private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        //Затем из него получаем сам токен:
        //static private CancellationToken token = cancelTokenSource.Token;
        //Чтобы отменить операцию, необходимо вызвать метод Cancel() у объекта CancellationTokenSource
        //Если был вызван метод cancelTokenSource.Cancel(), то выражение token.IsCancellationRequested возвращает true.

        //public delegate void delegate_change(List<int> factorValues);
        //public event delegate_change change_event;
        public MyCanvas()
        {
            //Включаем режим двойной буферизации, чтобы рисовка не мерцала.
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            //Опеределяем в нашей канве события
            this.Paint += MyCanvas_Paint;
            this.MouseDown += MyCanvas_MouseDown;
            this.MouseUp += MyCanvas_MouseUp;
            this.MouseMove += MyCanvas_MouseMove;

            this.SizeChanged += MyCanvas_SizeChanged;

            //Запускаем таймер на перерисовку
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 25;
            timer.Tick += (s, a) => this.Refresh();
            timer.Start();
        }


        ~MyCanvas()
        {

            if (g_layer1 != null)
                layer1.Dispose();
            if (g_layer2 != null)
                layer2.Dispose();

            if (layer1 != null)
                layer1.Dispose();
            if (layer2 != null)
                layer2.Dispose();

            timer.Dispose();
            pen.Dispose();
        }

        private void MyCanvas_SizeChanged(object sender, EventArgs e)
        {
            var _sender = sender as MyCanvas;

            //При изменении размера у нас должны пересоздатся битмапы (так как нельзя изменить
            // размер битмапа во время работы)
            //По этому мы сначала создаем новые, если старые есть (при создании конвы их нет,
            //вот тут они и создадутся при первом отображении) - рисуем их содержимое на новых, удаляем старые.

            Bitmap new_layer1 = new Bitmap(_sender.Size.Width, _sender.Size.Height, PixelFormat.Format32bppArgb);
            Bitmap new_layer2 = new Bitmap(_sender.Size.Width, _sender.Size.Height, PixelFormat.Format32bppArgb);
            Graphics new_g_layer1 = Graphics.FromImage(new_layer1);
            Graphics new_g_layer2 = Graphics.FromImage(new_layer2);

            if (g_layer1 != null)
            {
                new_g_layer1.DrawImageUnscaled(layer1, 0, 0);
                layer1.Dispose();
            }
            if (layer1 != null)
                layer1.Dispose();


            if (g_layer2 != null)
                layer2.Dispose();
            if (layer2 != null)
                layer2.Dispose();

            layer1 = new_layer1;
            g_layer1 = new_g_layer1;
            layer2 = new_layer2;
            g_layer2 = new_g_layer2;

            //добавляем полоски с переходом цвета от 0 до 255
            LinearGradientBrush Vert = new LinearGradientBrush(
                new Point(0, this.Size.Height),
                new Point(this.Size.Width, this.Size.Height - 5),
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 255, 255, 255));

            LinearGradientBrush Gor = new LinearGradientBrush(
                new Point(0, this.Size.Height),
                new Point(5, 0),
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 255, 255, 255));

            g_layer1.FillRectangle(Vert, new Rectangle(0, this.Size.Height - 5, this.Size.Width, 5));
            g_layer1.FillRectangle(Gor, new Rectangle(0, 0, 5, this.Size.Height));
        }

        private void MyCanvas_Paint(object sender, PaintEventArgs e)
        {
            //Всегда рисуем зеленый кружок под мышкой, чтобы видеть как будет рисоватся линия.

            var mouse_pos = PointToClient(MousePosition);
            int r = 2;
            g_layer2.Clear(Color.FromArgb(0, 0, 0, 0));
            g_layer2.DrawEllipse(pen, mouse_pos.X - r / 2, mouse_pos.Y - r / 2, r, r);

            //для построяния графика произведем интерполяцию по заданным точкам
            List<int> factorValues = InterpolationAndDraw();

            //рисуем точки
            for (int i = 0; i < points.Count(); i++)
            {
                Point point = TransformCoordTo(points[i]);
                g_layer2.FillRectangle(new SolidBrush(ColorPoint), new Rectangle(new Point(point.X - SizePoint.Width / 2, point.Y - SizePoint.Height / 2), SizePoint));
            }

            e.Graphics.DrawImageUnscaled(layer1, 0, 0);
            e.Graphics.DrawImageUnscaled(layer2, 0, 0);

            //delegate_change changeEvent = this.change_event;
            //if (changeEvent == null) return;
            //changeEvent(factorValues);

            //обновляем контейнер с изображением, а также гистограмму
            if (painting_mode)
            {
                UpdateImgAndBarGraph(factorValues, 640, 480);
            }
            
            if(transform_сompleted)
            { 
                UpdateImgAndBarGraph(factorValues, Image.Width, Image.Height);
                transform_сompleted = false;
            }
        }

        private void MyCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            //при отпускании ЛКМ отключаем режим рисования
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                painting_mode = false;
                transform_сompleted = true;
            }
        }

        private void MyCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            //при нажании ЛКМ включаем режим рисования
            //добавляем точку
            if (e.Button == MouseButtons.Left)
            {
                painting_mode = true;

                //запрашиваем позицию мишы
                var mouse_pos = PointToClient(MousePosition);
                bool PointNotFound = true;
                //пробегаем по всем точкам
                for(int i = 0; i < points.Count(); i++)
                {
                    //ищем точки на совпадения с уже имеющимися 
                    if (CheckInteractionPoint(TransformCoordTo(points[i]), mouse_pos))
                    {
                        PointMove = points[i];
                        PointNotFound = false;
                        break;
                    }
                }
                //если не найдено совпадение, то добавляем точку
                if (PointNotFound)
                {
                    points.Add(TransformCoordFrom(mouse_pos));
                }
            }
            //при нажании ПКМ включаем режим рисования
            //удаляем точку
            if (e.Button == MouseButtons.Right)
            {
                painting_mode = true;

                //запрашиваем позицию мишы
                var mouse_pos = PointToClient(MousePosition);
                //пробешаем по всем точкам
                for(int i = 0; i < points.Count(); i++)
                {
                    //ищем точки на совпадения с уже имеющимися, если есть удаляем и выходим
                    if (CheckInteractionPoint(TransformCoordTo(points[i]), mouse_pos))
                    {
                        if (points[i].X != 0 && points[i].X != 255)
                        {
                            points.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Если есть режим рисования, то нарисовать красный круг под мышкой.
            //ф-ция вызывается при движении мыши по канве
            if (painting_mode && e.Button != MouseButtons.Right)
            {
                var mouse_pos = PointToClient(MousePosition);
                if (!CheckInteractionContainer(mouse_pos))
                {
                    return;
                }
                int index = points.IndexOf(PointMove);
                if (index == -1) return;
                if (index == 0 || index == points.Count() - 1)
                {
                    //крайние две точки расположенные по бокам контейнера двигаем только по вертикали
                    points[index] = new Point(points[index].X, TransformCoordFrom(mouse_pos).Y);
                }
                else
                {
                    //все остальные координаты двигаем как хотим
                    points[index] = TransformCoordFrom(mouse_pos);
                }
                //задаем новое положение передвинутой точки
                PointMove = points[index];
            }

        }
        //вернем начальные точки
        public void Clear()
        {
            this.points.Clear();
            this.points.Add(new Point(0, 0));
            this.points.Add(new Point(255, 255));

            if (pictureBox.Image != null && Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = (Image)Image.Clone();
            }

            //обновляем график
            List<int> factorValues = InterpolationAndDraw();

            //обновляем контейнер с изображением, а также гистограмму
            UpdateImgAndBarGraph(factorValues, Image.Width, Image.Height);
        }
        //преобразование координат блока (255, 255) к размерам контейнера
        private Point TransformCoordTo(Point point)
        {
            return new Point((int)(point.X  * this.Size.Width / 255.0), (int)(this.Size.Height - point.Y * this.Size.Height / 255.0));
        }
        //преобразование координат контейнера к блоку (255, 255)
        private Point TransformCoordFrom(Point point)
        {
            return new Point((int)(point.X * 255.0 / this.Size.Width), (int)((this.Size.Height - point.Y) * 255.0 / this.Size.Height));
        }
        //проверка на взаимодействие с точкой 
        private bool CheckInteractionPoint(Point point, Point click)
        {
            int x = SizePoint.Width / 2;
            int y = SizePoint.Height / 2;
            if (click.X < point.X + x && click.X > point.X - x && 
                click.Y < point.Y + y && click.Y > point.Y - y)
            {
                return true;
            }
            return false;
        }
        //проверка на попадание в область контейнера
        private bool CheckInteractionContainer(Point point)
        {
            int w = panel.Width / 2;
            int h = panel.Height / 2;
            if(point.X < 2 * w && point.X > 0 && point.Y < 2 * h && point.Y > 0)
            {
                return true;
            }
            return false;
        }

        //интерполяция и построение графика функции
        public List<int> InterpolationAndDraw()
        {
            List<int> factorValues = null;
            points = points.OrderBy(x => x.X).ToList();

            List<Point> PointsForCurve = new List<Point>();
            //выбираем операцию для рисования кривой
            switch (this.comboBox.SelectedIndex)
            {
                case 0:
                    //линейная
                    LinearInterpolation linear = new LinearInterpolation(points);
                    factorValues = linear.Interpolation();
                    PointsForCurve = linear.Points;
                    break;
                case 1:
                    //квадратичный сплайн
                    QuadSpline quad = new QuadSpline(points);
                    factorValues = quad.Interpolation();
                    PointsForCurve = quad.Points;
                    break;
                case 2:
                    //кубический сплайн
                    СubicSpline сubic = new СubicSpline(points);
                    factorValues = сubic.Interpolation();
                    PointsForCurve = сubic.Points;
                    break;
                case 3:
                    //полином Лагранжа
                    LagrangePolynomial lagrange = new LagrangePolynomial(points);
                    factorValues = lagrange.Interpolation();
                    PointsForCurve = lagrange.Points;
                    break;
                case 4:
                    //полином Ньютона
                    NewtonPolynomial newtonF = new NewtonPolynomial(points);
                    factorValues = newtonF.InterpolationFirst();
                    PointsForCurve = newtonF.Points;
                    break;
                case 5:
                    //кривая Безье
                    BezierCurve bezier = new BezierCurve(points);
                    factorValues = bezier.Interpolation();
                    PointsForCurve = bezier.Points;
                    break;
            }

            //рисуем нашу кривую
            DrawCurves(PointsForCurve);

            return factorValues;
        }

        //рисуем кривую по заданным точкам
        private void DrawCurves(List<Point> points)
        {
            for(int i = 0; i < points.Count() - 1; i++)
            {
                g_layer2.DrawLine(MyPen, TransformCoordTo(points[i]), TransformCoordTo(points[i + 1]));
            }
        }

        //изменяем изображение, а также гистограмму
        public void UpdateImgAndBarGraph(List<int> factorValues, int wigth, int heigth)
        {
            if (Image == null || pictureBox.Image == null) return;
            var image = (img: Image, width: wigth, heigth: heigth);
            //изменяем изображение, а также гистограмму
            (Image img, DataTable table) = WorkImage.GradationTransform(image, factorValues, chart.Series[0].XValueMember, chart.Series[0].YValueMembers);

            pictureBox.Image.Dispose();
            pictureBox.Image = img;

            chart.DataSource = table;
            chart.DataBind();
        }
    }
}
