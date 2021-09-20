using System;

namespace Lesson5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();

            //string[] result = Func(text);
            //foreach (var words in result)   // почему выдает ошибку Sysrem.String
            //{
            //    Console.WriteLine(result);
            //}

            string min_text = Func(text);
            Console.WriteLine($"Слово мин длинны: {min_text}");
            string max_text = MaxFunc(text);
            Console.WriteLine($"Слово макс длинны: {max_text}");
            
        }

        /// <summary>
        /// Нахождение минаимального слова
        /// </summary>
        /// <param name="text"></param>
        static string Func(string text)
        {
            
            
            string min_word = string.Empty;
            char[] chars = { ' ' };
            string[] words = text.Split(chars);
            int wordLen = words[0].Length;
            foreach (string word in words)
            {
                if (word.Length < wordLen)
                {
                    wordLen = word.Length;
                    min_word = word;
                }
            }
            return min_word;
        }


        static string MaxFunc(string text)
        {
            int wordLen = 0;
            string desired_word = string.Empty;
            char[] chars = { ' ' };
            string[] words = text.Split(chars);
            foreach (string word in words)
            {
                if (word.Length > wordLen)
                {
                    wordLen = word.Length;
                    desired_word = word;
                }
            }
            return desired_word;

        }
    }
}
