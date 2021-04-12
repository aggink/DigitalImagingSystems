using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Interpolation
{
    public class LagrangePolynomial
    {
        private readonly List<Point> points;
        private readonly int Np;
        private int step = 1;
        public List<Point> Points { get; private set; } = new List<Point>();

        public LagrangePolynomial(List<Point> points)
        {
            this.points = points;
            this.Np = points.Count();
        }
        public List<int> Interpolation()
        {
            List<int> values = new List<int>();
            Points.Clear();

            for(int x = points[0].X; x <= points[Np - 1].X; x += step)
            {
                double y = 0;
                for(int i = 0; i < Np; i = i+ 1)
                {
                    double k = 1;
                    for(int j = 0; j < Np; j = j + 1)
                    {
                        if(i != j)
                        {
                            k = k * (x - points[j].X) / (points[i].X - points[j].X);
                        }
                    }
                    y += points[i].Y * k;
                }
                y = Math.Round(y, 0);
                values.Add((int)y);
                Points.Add(new Point(x, (int)y));
            }
            return values;
        }
    }
}
