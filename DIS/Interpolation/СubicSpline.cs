using DIS.SolveSystemEquations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Interpolation
{
    public class СubicSpline
    {
        private readonly List<Point> points;
        private readonly int Np;
        private int step = 1;
        public List<Point> Points { get; private set; } = new List<Point>();
        public СubicSpline(List<Point> points)
        {
            this.points = points;
            this.Np = points.Count();
        }
        public List<int> Interpolation()
        {
            List<int> values = new List<int>();
            Points.Clear();

            double[,] matrix = new double[this.Np, this.Np];
            double[] result = new double[this.Np];
            for (int i = 1; i < this.Np - 1; i++)
            {
                matrix[i, i - 1] = points[i].X - points[i - 1].X;
                matrix[i, i] = 2 * (points[i].X - points[i - 1].X + points[i + 1].X - points[i].X);
                matrix[i, i + 1] = points[i + 1].X - points[i].X;

                double k = points[i + 1].X - points[i].X;
                double y1 = 0;
                if (k != 0)
                {
                    y1 = (points[i + 1].Y - points[i].Y) / (points[i + 1].X - points[i].X);
                }

                k = (points[i].X - points[i - 1].X);
                double y2 = 0;
                if(k != 0)
                {
                    y2 = (points[i].Y - points[i - 1].Y) / (points[i].X - points[i - 1].X);
                }
                result[i] = 3 * (y1 - y2);
            }
            matrix[0, 0] = 1;
            matrix[this.Np - 1, this.Np - 1] = 1;
            result[0] = 0;
            result[this.Np - 1] = 0;

            SweepMethod sweep = new SweepMethod(matrix, result, this.Np);
            double[] decision = sweep.Solution();

            double[] a = new double[this.Np];
            double[] b = new double[this.Np];
            double[] c = new double[this.Np];
            double[] d = new double[this.Np];
            double[] h = new double[this.Np];

            for (int i = 1; i < this.Np; i++)
            {
                h[i] = points[i].X - points[i - 1].X;
            }
            for (int i = 1; i < this.Np; i++)
            {
                a[i] = points[i - 1].Y;
                c[i] = decision[i];
            }
            for (int i = 1; i < this.Np - 1; i++)
            {
                b[i] = ((points[i].Y - points[i - 1].Y) / h[i]) - ((h[i] * (c[i + 1] + 2 * c[i])) / 3);
            }
            b[Np - 1] = ((points[Np - 1].Y - points[Np - 2].Y) / (h[Np - 1])) - ((2 * h[Np - 1] * c[Np - 1]) / 3);
            for (int i = 1; i < Np - 1; i++)
            {
                d[i] = (c[i + 1] - c[i]) / (3 * h[i]);
            }
            d[Np - 1] = (0 - c[Np - 1]) / (3 * h[Np - 1]);

            for(int i = 1; i < Np; i++)
            {
                for(int x = points[i - 1].X; x < points[i].X; x += step)
                {
                    int y = (int)(a[i] + b[i] * (x - points[i - 1].X) + c[i] * Math.Pow((x - points[i - 1].X), 2) + d[i] * Math.Pow((x - points[i - 1].X), 3));
                    values.Add(y);
                    Points.Add(new Point(x, y));
                }
            }
            values.Add(points[Np - 1].Y);
            Points.Add(new Point(points[Np - 1].X, points[Np - 1].Y));
            return values;
        }
    }
}
