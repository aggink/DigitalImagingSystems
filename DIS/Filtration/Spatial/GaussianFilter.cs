using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.SpatialFiltering
{
    public static class GaussianFilter
    {
        //Количество знаков после запятой для округления и занесения числа в text
        private static int Round = 5;
        public static int RoundNumber
        {
            get
            {
                return Round;
            }
            set
            {
                if(value > 0) Round = value;
                else Round = 5;
            }
        }

        //возвращает матрицу (Гауссовский фильтр)
        public static (double[,] matrix, double sum) MatrixGaussianFilter(int r, double sigma)
        {
            double[,] matrix = new double[r * 2 + 1, r * 2 + 1];
            double sum = 0;

            //Fgauss = 1 / 2 * pi * sigma^2 * exp(-1 * (i^2 + j^2) / (2 * sigma^2))
            double p1 = 2.0 * Math.PI * sigma * sigma;
            double p2 = 2.0 * sigma * sigma;

            for (int i = -r, i1 = 0; i <= r; ++i, ++i1)
            {
                for(int j = -r, j1 = 0; j <= r; ++j, ++j1)
                {
                    matrix[i1, j1] = 1.0 / p1 * Math.Exp(-1.0 * (i * i + j * j) / p2);
                    sum += matrix[i1, j1];
                }
            }

            return (matrix, sum);
        }
    }
}
