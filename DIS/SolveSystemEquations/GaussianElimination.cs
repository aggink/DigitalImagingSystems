using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.SolveSystemEquations
{
    public class GaussianElimination
    {
		private double[,] a;
		private double[] y;
		private int n;
		public GaussianElimination(double[,] matrix, int row, int col)
        {
			this.n = row;
			this.a = new double[n, n];
			this.y = new double[n];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					a[i, j] = matrix[i, j];
				}
			}
			for (int i = 0; i < n; i++)
			{
				y[i] = matrix[i, col - 1];
			}
		}
		//метод гаусса. Алгоритм
		public double[] Solution()
		{
			double[] x;
			double max;
			int k, index;
			x = new double[n];
			k = 0;
			while (k < n)
			{
				// Поиск строки с максимальным a[i][k]
				max = Math.Abs(a[k, k]);
				index = k;
				for (int i = k + 1; i < n; i++)
				{
					if (Math.Abs(a[i, k]) > max)
					{
						max = Math.Abs(a[i, k]);
						index = i;
					}
				}
				// Перестановка строк
				if (max < 0)
				{
					return null;
				}
				double temp;
				for (int j = 0; j < n; j++)
				{
					temp = a[k, j];
					a[k, j] = a[index, j];
					a[index, j] = temp;
				}
				temp = y[k];
				y[k] = y[index];
				y[index] = temp;
				// Нормализация уравнений
				for (int i = k; i < n; i++)
				{
					temp = a[i, k];
					if (Math.Abs(temp) == 0)
					{
						continue; // для нулевого коэффициента пропустить
					}
					else
					{
						for (int j = 0; j < n; j++)
						{
							a[i, j] = a[i, j] / temp;
						}
					}
					y[i] = y[i] / temp;
					if (i == k)
					{
						continue; // уравнение не вычитать само из себя
					}
					else
					{
						for (int j = 0; j < n; j++)
						{
							a[i, j] = a[i, j] - a[k, j];
						}
						y[i] = y[i] - y[k];
					}
				}
				k++;
			}
			// обратная подстановка
			for (k = n - 1; k >= 0; k--)
			{
				x[k] = y[k];
				for (int i = 0; i < k; i++)
				{
					y[i] = y[i] - a[i, k] * x[k];
				}
			}
			return x;
		}
	}
}
