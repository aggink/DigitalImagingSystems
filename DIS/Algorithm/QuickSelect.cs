using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.Algorithm
{
    public static class QuickSelect
    {
        // функция распределения аналогична быстрой сортировки
        // Считает последний элемент поворотным и добавляет
        // элементы с меньшим значением слева и
        // большим значением справа, а также изменение
        // положение поворота к соответствующей позиции
        //arr - массив, low - позиция первого элемента, high - позиция последнего элемента
        static private int partitions(int[] arr, int low, int high)
        {
            int pivot = arr[high], pivotloc = low, temp;
            for (int i = low; i <= high; i++)
            {
                // вставляем элементы с меньшим значением слева от точки поворота
                if (arr[i] < pivot)
                {
                    temp = arr[i];
                    arr[i] = arr[pivotloc];
                    arr[pivotloc] = temp;
                    pivotloc++;
                }
            }

            // изменение точки поворота
            temp = arr[high];
            arr[high] = arr[pivotloc];
            arr[pivotloc] = temp;

            return pivotloc;
        }

        // находит k-ю позицию (отсортированного массива)
        // в заданном несортированном массиве, т.е. в этой функции
        // можно использовать как k-е по величине, так и
        // k-й наименьший элемент в массиве.
        public static int kthSmallest(int[] arr, int low, int high, int k)
        {
            // находим разделение
            int partition = partitions(arr, low, high);

            // если значение раздела равно k-й позиции, возвращаем значение в k.
            if (partition == k) return arr[partition];

            // если значение раздела меньше k-й позиции, ещем в правой части массива.
            else if (partition < k) return kthSmallest(arr, partition + 1, high, k);

            // если значение раздела больше k-й позиции, ищем в левой части массива.
            else return kthSmallest(arr, low, partition - 1, k);
        }
    }
}
