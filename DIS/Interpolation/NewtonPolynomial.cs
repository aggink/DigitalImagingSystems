using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Interpolation
{
    public class NewtonPolynomial
    {
        private readonly List<Point> points;
        private readonly int Np;
        private static int step = 1;
        public List<Point> Points { get; private set; } = new List<Point>();
        public NewtonPolynomial(List<Point> points)
        {
            this.points = points;
            this.Np = points.Count();
        }
        public List<int> InterpolationFirst()
        {
            List<int> values = new List<int>();
            Points.Clear();

            for (int x = points[0].X; x <= points[Np - 1].X; x += step)
            {
                double sum = points[0].Y;
                for (int i = 1; i < Np; ++i)
                {

                    double F = 0;
                    for (int j = 0; j <= i; ++j)
                    {

                        double den = 1;
                        for (int k = 0; k <= i; ++k)
                            if (k != j)
                                den *= (points[j].X - points[k].X);

                        F += points[j].Y / den;
                    }
                    for (int k = 0; k < i; ++k)
                        F *= (x - points[k].X);
                    sum += F;
                }
                values.Add((int)sum);
                Points.Add(new Point(x, (int)sum));
            }
            return values;
        }
    }
}
