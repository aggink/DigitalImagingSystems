using DIS.SolveSystemEquations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Interpolation
{
    public class QuadSpline
    {
        private readonly List<Point> points;
        private readonly int Np;
        public List<Point> Points { get; private set; } = new List<Point>();
        private static int step = 1;
        public QuadSpline(List<Point> points)
        {
            this.points = points;
            this.Np = points.Count();
        }
        public List<int> Interpolation()
        {
            List<int> values = new List<int>();
            Points.Clear();

            float[,] abc = new float[Np - 1, 3];

            float h = points[1].X - points[0].X;
            float beta = (points[1].Y - points[0].Y) / h;
            for(int i = 0; i < Np - 1; i++)
            {
                h = points[i + 1].X - points[i].X;

                abc[i, 2] = (1.0f / (h * h)) * (points[i + 1].Y - points[i].Y) - 1 / h * beta;
                abc[i, 1] = beta - 2 * abc[i, 2] * points[i].X;
                abc[i, 0] = points[i].Y - beta * points[i].X + abc[i, 2] * points[i].X * points[i].X;

                beta = abc[i, 1] + 2 * abc[i, 2] * points[i + 1].X;
            }

            for (int i = 0; i < Np - 1; i++) {
                for (int x = points[i].X; x < points[i + 1].X; x += step)
                {
                    float y = abc[i, 0] + abc[i, 1] * x + abc[i, 2] * x * x;
                    values.Add((int)y);
                    Points.Add(new Point(x, (int)y));
                }
            }
            values.Add(points[Np - 1].Y);
            Points.Add(new Point(points[Np - 1].X, points[Np - 1].Y));
            return values;
        }
        public List<int> Interpolation2()
        {
            List<int> values = new List<int>();
            int row = (Np - 1) * 3;
            int col = row + 1;
            double[,] matrix = new double[row, col];

            //на каждом отрезке сплайн является многоччленом 2 степени y = a + b * x + c * x^2
            //в узлах x_i сплайн S_i(x) принимает значения y_i
            int i = 0;
            for (int j = 0, k = 0; k < Np - 1; i++, j+=3, k++)
            {
                matrix[i, j] = 1;
                matrix[i, j + 1] = points[k].X;
                matrix[i, j + 2] = points[k].X * points[k].X;
                matrix[i, row] = points[k].Y;

                if (i != 0)
                {
                    i = i + 1;
                    matrix[i, j] = 1;
                    matrix[i, j + 1] = points[k + 1].X;
                    matrix[i, j + 2] = points[k + 1].X * points[k + 1].X;
                    matrix[i, row] = points[k + 1].Y;
                }
            }

            //во внутренних узлах x_i, i = 1, ..., n-1 сплайн имеет непрерывную производную
            //то есть первые производные многочленов должны быть равны
            // (S_i(x_i))' = (S_i+1(x_i))'
            for (int j = 0, k = 1; k < Np - 1; k++, j += 3)
            {
                i = i + 1;
                matrix[i, j] = 0;
                matrix[i, j + 1] = 1;
                matrix[i, j + 2] = 2 * points[k].X;

                matrix[i, j + 3] = 0;
                matrix[i, j + 4] = -1;
                matrix[i, j + 5] = -2 * points[k].X;

                matrix[i, row] = 0;
            }

            //чтоб система имела решение добавляем еще одно условие
            //ЧТО_ТО НЕ ПОШЛО ИЗ_ЗА ЭТОГО
            int f = row - 1;
            matrix[f, 0] = 0;
            matrix[f, 1] = 1;
            matrix[f, 2] = 2 * points[0].X;
            matrix[f, row] = 1 + 2 * points[0].X;
            


            GaussianElimination gauss = new GaussianElimination(matrix, row, col);
            double[] result = gauss.Solution();

            for(int a = 0, t = 0; a < Np - 1; a++, t += 3)
            {
                for(int x = points[a].X; x < points[a + 1].X; x += step)
                {
                    int y = (int)(result[t] + result[t + 1] * x + result[t + 2] * x * x);
                    values.Add(y);
                    Points.Add(new Point(x, y));
                }
            }
            values.Add(points[points.Count() - 1].Y);
            Points.Add(new Point(points[Np - 1].X, points[Np - 1].Y));
            return values;
        }
    }
}
