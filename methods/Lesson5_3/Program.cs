using System;

namespace Lesson5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количесвто элесентов массива");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите массив. ");
            decimal[] mas = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = Convert.ToDecimal(Console.ReadLine());
            }
            Console.WriteLine("Исходный массив");
            for (int j = 0; j < n; j++)
            {
                Console.Write(mas[j] + " ");
            }
            Console.WriteLine();
            if (ArifProgression(n, mas) == true) Console.WriteLine("Арифметическая прогрессия");
            if (GeoProgression(n, mas) == true) Console.WriteLine("Геометрическая прогрессия");
            if (Progression(n, mas) == true) Console.WriteLine("Массив не являентся прогрессией");
        }

        


        /// <summary>
        /// арифметическая прогрессия
        /// </summary>
        /// <param name="n"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        static bool ArifProgression(int n, params decimal[] arr)
        {
            decimal b = arr[1] - arr[0];

            if (n > 2)
            {
                for (int i = 1; i < n - 1; i++)
                {
                    if (arr[i] - arr[i - 1] != b)
                    {
                        return false;
                    }

                }
            }
            else return false;
            return true;
        }

        /// <summary>
        /// геометрическая прогрессия
        /// </summary>
        /// <param name="n"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        static bool GeoProgression(int n, params decimal[] arr)
        {
            decimal b = arr[1] / arr[0];

            if (n > 2)
            {
                for (int i = 1; i < n - 1; i++)
                {
                    if (arr[i] / arr[i - 1] != b)
                    {
                        return false;
                    }

                }
            }
            else return false;
            return true;
        }


        static bool Progression(int n, params decimal[] arr)
        {
            if (arr.Length < 3) return true;
            if (ArifProgression(n, arr) == false && GeoProgression(n, arr) == false) return true;
            return false;
        }
    }
}
