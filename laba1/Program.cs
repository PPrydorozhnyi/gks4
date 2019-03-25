using laba1.simplex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*double[,] table = { {2, 1, 0, 0,  1, 1},
                                {7, 0, 1, 0,  -1, 1},
                                {17,  0, 0, 1,  1, -1},
                                { 0, 0, 0, 0,  5, 7} };*/
            /*double[,] table = { {25, -3,  5},
                                {30, -2,  5},
                                {10,  1,  0},
                                { 6,  3, -8},
                                { 0, -6, -5} };*/
            /*double[,] table = { {17, 0.1, 0.3},
                                {11, 0.4,  0.1},
                                {13,  0.2,  0.2},
                                { 0, -6, -5} };*/
            /*double[,] table = { {-1, -2, 5,-9},
                                  {-2, -8, -3,-5},
                                  {2, 8, 3,5},
                                  {0.4, 1, 0,1},
                                  {0, 7, 4, -6} };

            double[] result = new double[5];
            double[,] table_result;
            Simplex S = new Simplex(table);
            table_result = S.Calculate(result);

            Console.WriteLine("Решенная симплекс-таблица:");
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                for (int j = 0; j < table_result.GetLength(1); j++)
                    Console.Write(table_result[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Решение:");
            Console.WriteLine("X[1] = " + result[0]);
            Console.WriteLine("X[2] = " + result[1]);
            Console.WriteLine("X[3] = " + result[2]);
            Console.WriteLine("X[4] = " + result[3]);
            Console.WriteLine("X[5] = " + result[4]);
            Console.ReadLine();*/
        }
    }
}
