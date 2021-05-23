using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Filtration.Frequency
{
    //одномерное фурье преобразование
    public class OneFourierTransform
    {
        //результат фурье преобразования
        protected Complex[] fourier;
        protected int N;
        public OneFourierTransform(byte[] massive)
        {
            //преобразуем входной массив в массив комплексных чисел с нулевой мнимой частью
            this.fourier = massive.Select(x => new Complex(x, 0)).ToArray();
            this.N = massive.Length;
        }

        //Фурье преобразование
        public Complex[] DFT()
        {
            return DFT(1.0 / N);
        }

        //Обратное Фурье преобразование
        public Complex[] DFT_Inverse(Complex[] furier)
        {
            this.fourier = furier.Select(x => new Complex(x.Real, -x.Imaginary)).ToArray();
            return DFT();
        }

        //Одномерное дискретное преобразование Фурье
        protected Complex[] DFT(double n = 1)
        {
            Complex[] G = new Complex[N];
            for(int u = 0; u < N; ++u)
            {
                for(int k = 0; k < N; ++k)
                {
                    double fi = -2.0 * Math.PI * u * k / N;
                    G[u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * fourier[k]);
                }
                G[u] = n * G[u]; //для умножения 1/N для прямого преобразования
            }
            return G;
        }
    }
}
