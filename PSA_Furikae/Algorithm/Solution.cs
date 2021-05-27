using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSA_Furikae.Algorithm
{
    public class Solution
    {
        private double furikae_Threshold;
        public Solution(double thresh = 0.01)
        {
            furikae_Threshold = thresh;
        }
        /// <summary>
        /// Get the FuriKae table
        /// </summary>
        /// <param name="raw">
        /// a table representing a r x 12 table, unit is million
        /// </param>
        /// <returns></returns>
        public double[][] GetFuriKaeData(double[][] raw)
        {
            int row = raw.Count();
            int col = raw[0].Count(); //should be 12;

            Console.WriteLine($" %%%%% GetFuriKaeData %%%% row={row},col={col}");


            double[][] result = new double[row][];
            // each result should be
            // 每月是否需要振替? 如果需要，显示金额。

            //振り替え规则：
            // 0 每次振替都清空滚动池。
            // 1 每月超过 0.01 当月振替，如果没有，则滚动累加
            // 2 三月六月九月十二月为特殊，该月份中，如果本月没有超过，则累加之后判断滚动池，滚动池超过时，振替
            // 3 其中9月更加特殊，该月份中，振替发生时，需要判断Q4是否可以累积达到振替值。

            for (int i = 0; i < row; i++)
            {
                result[i] = new double[col];
                double acc = 0;
                int last_acc_index = -1; //上一次超界位置
                for (int j = 0; j < col; j++)
                {
                    acc += raw[i][j];
                    Console.Write($"{acc}\t");
                    if (j.isNormalMonth() && raw[i][j] >= furikae_Threshold)
                    {
                        // 普通月单月超过振替界限，将累计直接输出到结果。
                        result[i][j] = acc;
                        acc = 0;
                    }
                    else if ((j == 2 || j == 5 || j == 8) && acc >= furikae_Threshold)
                    {
                        // 3，6，9月累计超过振替界限，将累计直接输出到结果。
                        result[i][j] = acc;
                        last_acc_index = j;
                        acc = 0;
                    }
                    else if (j == 11)
                    {
                        // 如果12月未满，那么寻找上一次acc位置，替换
                        if (acc > 0)
                        {
                            if (acc < furikae_Threshold && last_acc_index > -1)
                            {
                                result[i][j] = result[i][last_acc_index] + acc;
                                result[i][last_acc_index] = 0;
                                acc = 0;
                            }
                            else if (acc >= furikae_Threshold)
                            {
                                // acc 超界，直接输出
                                result[i][j] = acc;
                                acc = 0;
                            }

                        }
                    }

                    // 如果 j 是 2，5 那么判断累是否达到振替界限

                }

                Console.WriteLine();
            }

            return result;

        }

        
    }

    internal static class SolutionExtensions
    {
        internal static bool isNormalMonth(this int month)
        {
            int[] normalMonthes =
            {
                0, 1,
                3, 4,
                6, 7,
                9, 10
            };
            return normalMonthes.Contains(month);
        }
    }
}
