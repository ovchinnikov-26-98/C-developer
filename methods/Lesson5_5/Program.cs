using System;

namespace Lesson5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Akker(4, 5));
            Console.WriteLine(Akker(0, 2));
        }

        static int Akker(int n, int m)
        {
            
            if (n == 0) return m + 1;
            if (m == 0) return Akker(n - 1, m);
            return Akker(n - 1, Akker(n, m - 1));
        }
    }
}
