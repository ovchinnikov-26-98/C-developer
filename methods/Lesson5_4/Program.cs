using System;
using System.Text.RegularExpressions;

namespace Lesson5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string colWords = Del(input);
            Console.WriteLine(colWords);
        }

        static string Del(string words)
        {
            int j = 0;

            for (int i = 0; i < words.Length - 1; i++)
            {

                for (j = i + 1; j < words.Length && words[i] == words[j]; j++) ;

                words = words.Substring(0, i + 1) + words.Substring(j);
            }
            return words;
        }
        
    }
}
