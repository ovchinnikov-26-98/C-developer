using System;
using System.IO;
using System.IO.Compression;


namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(File.ReadAllText("inNumber.txt"));
            DateTime date = DateTime.Now;
            Console.WriteLine("Введите вариант действия:" +
                "\n1 - рассчитать только количесвто групп и вывести на экран" +
                "\n2 - распределить числа и записать их в файл");
            string path = null;
            switch (Console.ReadLine())
            {
                case "1":
                    int count = NumberOfGroups(N);
                    Console.WriteLine($"Количество групп: {count}");
                    break;
                case "2":
                    Console.WriteLine("Укадите путь и имя файла для записи. Иначе файл создаться автоматически");
                    path = Console.ReadLine();
                    WritingOfNumbers(path, N);
                    Console.WriteLine("Поместиить файл в архив: \n1 - да \n2 -нет");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            CreatingAnArchive(/*path*/);
                            TimeSpan time = DateTime.Now.Subtract(date);
                            Console.WriteLine($"Время выполнения: {time.TotalMilliseconds}");
                            break;
                        case "2":
                            break;
                    }
                    break;
            }
            

            
            
            
        }

        static void WritingOfNumbers(string path, int N)
        {
            if (!File.Exists(path))
            {
                path = Directory.GetCurrentDirectory() + "\\outNumber.txt";
            }


            using (StreamWriter sw = new StreamWriter(path))
            {
                int c = NumberOfGroups(N);
                int k;
                sw.Write($"Группа 1: 1");
                sw.WriteLine();
                for (int i = 2; i <= c; i++)
                {
                    sw.Write($"Группа {i}:");
                    k = (int)Math.Pow(2, i - 1);
                    for (int j = k; j < k * 2 && j <= N; j++) sw.Write(j + " ");
                    sw.WriteLine();
                }
            }
        }

        static int NumberOfGroups(int N)
        {
            int count = 1;
            while (N > 1)
            {
                N = N / 2;
                count++;

            }
            return count;
        }

        static void CreatingAnArchive (/*string path*/)
        {
            string source = "outNumber.txt";
            string compressed = "outNumber.zip";
            using (FileStream ss = new FileStream(source, FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create(compressed))   
                {
                    
                    using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                    {
                        ss.CopyTo(cs); 
                        Console.WriteLine("Сжатие файла {0} завершено. Было: {1}  стало: {2}.",
                                          source,
                                          ss.Length,
                                          ts.Length);
                    }
                }
            }

            Console.ReadKey();
        }






    }
}
