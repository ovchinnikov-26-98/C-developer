using System;

namespace Lesson5
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количесвто строк");
            bool prof = int.TryParse(Console.ReadLine(), out int k);
            Console.WriteLine("Введите количесвто столбцов");
            bool profm = int.TryParse(Console.ReadLine(), out int m);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Исходная первая матрица");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int[,] matrix_1 = new int[k, m];
            matrix_1 = Matrix(k, m);
            PrintManrix(matrix_1,k, m);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Исходная вторая матрица");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int[,] matrix_2 = new int[k, m];
            matrix_2 = Matrix(k, m);
            PrintManrix(matrix_2, k, m);


            MultiplicationByNumbers_1(matrix_1, k, m);

            SumMatrix(matrix_1, matrix_2, k, m);
                        
            SubtractionMatrix(matrix_1, matrix_2, k, m);
           
            MultiplicationMatrix(matrix_1, matrix_2,k, m);
        }

            

        ///<summary>
        /// Создаем матрицу
        /// </summary>
        /// <param name = "k" ></ param >
        /// < param name="m"></param>
        /// <returns></returns>
        static int[,] Matrix(int k, int m)
        {

            Random r = new Random();
            int[,] matrix = new int[k, m];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = r.Next(1, 11);

                }

            }

            return matrix;
        }

           

        /// <summary>
        /// Вывод первой матрицы
        /// </summary>
        /// <param name = "k" ></ param >
        /// < param name="m"></param>
        static void PrintManrix(int[,] Matr, int k, int m)
        {

            
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(Matr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <param name="m"></param>
        static void MultiplicationByNumbers_1(int[,] Matr, int k, int m)
        {
            Console.WriteLine("Для умножение матрицы на число введите число:");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Умножение матрицы на числа");
            Console.ForegroundColor = ConsoleColor.White;


            int[,] matrixMult = new int[k, m];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    matrixMult[i, j] = Matr[i, j] * num;
                    Console.Write(matrixMult[i, j] + " ");
                }
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="k"></param>
        /// <param name="m"></param>
        static void SumMatrix(int[,] Matr_1, int[,] Matr_2, int k, int m)
        {

            int[,] matrixSum = new int[k, m];

            Console.WriteLine();
            Console.WriteLine("Сложение матриц");
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    matrixSum[i, j] = Matr_1[i, j] + Matr_2[i, j];
                    Console.Write(matrixSum[i, j] + " ");
                }
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Вычитание 
        /// </summary>
        /// <param name="k"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static void SubtractionMatrix(int[,] matr_1, int[,] matr_2, int k, int m)
        {
            Console.WriteLine();
            Console.WriteLine("Вычитание матриц");

            int[,] matrixSub = new int[k, m];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    matrixSub[i, j] = matr_2[i, j] - matr_1[i, j];
                    Console.Write(matrixSub[i, j] + " ");
                }
                Console.WriteLine();

            }
            
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="k"></param>
        /// <param name="m"></param>
        static void MultiplicationMatrix(int[,] Matr_1, int[,] Matr_2, int k, int m)
        {
            Console.WriteLine("Перемножение матриц");
            int[,] resMass = new int[k, m];
            if (Matr_1.GetLength(0) != Matr_2.GetLength(1))
            {
                Console.WriteLine("Матрицы нельзя перемножать");
            }
            else
            {

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < m; j++)
                    {

                        resMass[i, j] = 0;
                        for (int g = 0; g < m; g++)
                        {
                            resMass[i, j] += Matr_1[i, g] * Matr_2[g, j];

                        }

                        Console.Write(resMass[i, j] + " ");
                    }

                    Console.WriteLine();
                }
            }

        }


    }
}
