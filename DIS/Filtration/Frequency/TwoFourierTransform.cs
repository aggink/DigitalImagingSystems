using DIS.Algorithm;
using DIS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Filtration.Frequency
{
    public class TwoFourierTransform : CooleyTukeyAlgorithm
    {

        //Двумерное дискретное преобразование Фурье
        public static Complex[] DFT(double[] mas, int width, int height)
        {
            //преобразование в комплексное число
            Complex[] complex = new Complex[width * height];
            Parallel.For(0, height, y =>
            {
                Parallel.For(0, width, x =>
                {
                    complex[y * width + x] = new Complex(mas[y * width + x] * Math.Pow(-1, y + x), 0);
                });
            });

            //преобразование по строкам
            Parallel.For(0, height, y =>
            {
                Complex[] tmp = new Complex[width];
                Array.Copy(complex, y * width, tmp, 0, width);
                tmp = fft(tmp);
                Parallel.For(0, width, x =>
                {
                    complex[y * width + x] = tmp[x] / width;
                });
            });

            //преобразование по столбцам
            Parallel.For(0, width, x =>
            {
                Complex[] tmp = new Complex[height];
                Parallel.For(0, height, y =>
                {
                    tmp[y] = complex[y * width + x];
                });
                tmp = fft(tmp);
                Parallel.For(0, height, y =>
                {
                    complex[y * width + x] = tmp[y] / height;
                });
            });

            return complex;
        }

        //Обратное двумерное преобразование Фурье
        public static double[] DFT_Inverse(Complex[] fourierIn, int width, int height)
        {
            //по строкам
            Parallel.For(0, height, y =>
            {
                Complex[] tmp = new Complex[width];
                Parallel.For(0, width, x =>
                {
                    tmp[x] = new Complex(fourierIn[y * width + x].Real, -fourierIn[y * width + x].Imaginary);
                });
                tmp = fft(tmp);
                for(int x = 0; x < width; ++x)
                {
                    fourierIn[y * width + x] = tmp[x];
                }
            });

            //по столбцам
            Parallel.For(0, width, x =>
            {
                Complex[] tmp = new Complex[height];
                Parallel.For(0, height, y =>
                {
                    tmp[y] = new Complex(fourierIn[y * width + x].Real, -fourierIn[y * width + x].Imaginary);
                });
                tmp = fft(tmp);
                for(int y = 0; y < height; ++y)
                {
                    fourierIn[y * width + x] = tmp[y];
                    fourierIn[y * width + x] = fourierIn[y * width + x].Real * Math.Pow(-1, x + y);
                }
            });
            
            return fourierIn.Select(x => x.Real).ToArray();
        } 
    }
}
