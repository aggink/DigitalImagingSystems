using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Interpolation
{
    public class BezierCurve
    {
        private readonly List<Point> points;
        private readonly int Np;
        private float step = 1.0f / 255f;
        public List<Point> Points { get; private set; } = new List<Point>();
        public BezierCurve(List<Point> points)
        {
            this.points = points;
            this.Np = points.Count();
        }
        public List<int> Interpolation()
        {
            List<int> values = new List<int>();
            Points.Clear();

            for (float t = 0; t <= 1; t += step)
            {
                double ytmp = 0;
                double xtmp = 0;
                for (int i = 0; i < Np; ++i)
                {
                    // вычисляем наш полином Бернштейна
                    float b = polinom(i, Np - 1, t); 
                    ytmp += points[i].Y * b;
                    xtmp += points[i].X * b;
                }
                Points.Add(new Point((int)Math.Round(xtmp), (int)Math.Round(ytmp, 0)));
            }

            Points = Points.OrderBy(x => x.X).ToList();
            Points.ForEach(x => values.Add(x.Y));
            return values;
        }
        //вычисление факториала
        private int fuctorial(int n) 
        {
            int res = 1;
            for (int i = 1; i <= n; ++i)
                res *= i;
            return res;
        }
        //вычисления полинома Бернштейна
        private float polinom(int i, int n, float t)
        {
            return fuctorial(n) / (fuctorial(i) * fuctorial(n - i)) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }
    }
}
