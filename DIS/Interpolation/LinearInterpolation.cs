using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Interpolation
{
    public class LinearInterpolation
    {
        private readonly List<Point> points;
        public List<Point> Points { get; private set; } = new List<Point>();
        private int Np;
        private int step = 1;
        public LinearInterpolation(List<Point> points)
        {
            this.Np = points.Count();
            this.points = points;
        }
        public List<int> Interpolation()
        {
            List<int> values = new List<int>();
            Points.Clear();

            for (int i = 0; i < points.Count() - 1; i++)
            {
                double f = (double)(points[i + 1].Y - points[i].Y) / (points[i + 1].X - points[i].X);
                for(int x = points[i].X; x < points[i + 1].X; x += step)
                {
                    int y = points[i].Y + (int)(f * (x - points[i].X));
                    Points.Add(new Point(x, y));
                    values.Add(y);
                }
            }
            Points.Add(new Point(points[Np - 1].X, points[Np - 1].Y));
            values.Add(points[Np - 1].Y);

            return values;
        }
    }
}
