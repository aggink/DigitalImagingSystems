using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Manager
{
    public class GeneralOperation
    {
        //проверка выхода радиуса за пределы картинки, центр - середина картинки
        protected static int СheckRadius(int R, int width, int height)
        {
            int min = width;
            if (min > height) min = height;
            if (2 * R > min) R = min / 2 - 1;
            return R;
        }
        protected static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        //поиск ближайшего числа к степени 2
        public static long clp2(long x)
        {
            long p2 = 1;
            while (true)
            {
                if (p2 >= x) return p2;
                p2 <<= 1;
            }
        }
        //преобразование координат блока A к размерам контейнера B (от маленького к большому)

        protected static (int x, int y) CoordTo((int x, int y) A, (int width, int height) sizeA, (int width, int height) sizeB)
        {
            int x = A.x * sizeB.width / sizeA.width;
            int y = sizeB.height - A.y * sizeB.height / sizeA.height;
            return (x, y);
        }
        //преобразование координат контейнера B к блоку A (от большого к маленькому)
        protected static (int x, int y) CoordFrom((int x, int y) B, (int width, int height) sizeB, (int width, int height) sizeA)
        {
            int x = B.x * sizeA.width / sizeB.width;
            int y = (sizeB.height - B.y) * sizeA.height / sizeB.height;
            return (x, y);
        }
    }
}
