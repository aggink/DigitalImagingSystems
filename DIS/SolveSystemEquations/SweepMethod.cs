using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS.SolveSystemEquations
{
    public class SweepMethod
    {
		private double[,] matrix;
		private double[] result;
		private int number;
		private double[] y;
		private double[] alpha;
		private double[] beta;
		private double[] decision;
		public SweepMethod(double[,] matrix, double[] result, int number)
        {
			this.number = number;
			this.matrix = matrix;
			this.result = result;
			y = new double[number];
			alpha = new double[number];
			beta = new double[number];
			decision = new double[number];
		}
		public double[] Solution()
		{
			//прямая прогонка
			y[0] = matrix[0, 0];
			alpha[0] = -matrix[0, 1] / y[0];
			beta[0] = result[0] / y[0];
			for (int i = 1; i <= number - 2; i++)
			{
				y[i] = matrix[i, i] + matrix[i, i - 1] * alpha[i - 1];
				alpha[i] = (-1 * matrix[i, i + 1]) / y[i];
				beta[i] = (result[i] - matrix[i, i - 1] * beta[i - 1]) / y[i];

			}
			y[number - 1] = matrix[number - 1, number - 1] + matrix[number - 1, number - 2] * alpha[number - 2];
			beta[number - 1] = (result[number - 1] - matrix[number - 1, number - 2] * beta[number - 2]) / y[number - 1];
			//обратная прогонка
			decision[number - 1] = beta[number - 1];
			for (int i = number - 2; i >= 0; i--)
			{
				decision[i] = alpha[i] * decision[i + 1] + beta[i];
			}
			return decision;
		}
	}
}
