using System;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace Split_Number
{
    class Program
    {
        /// <summary>
        /// Функция разбиения числа на все возможные множители, и сортирующая их в различные группы неделимости.
        /// </summary>
        /// <param name="N">Число,разбиваемое на множители.</param>
        /// <returns></returns>
        static string Substracting_Number(int N)
        {
            string Output_Strings = "";

            List<int> Nums_All = new List<int>();                                                                           //Динамический массив начальных чисел.
            List<int> Nums_Local = new List<int>();                                                                         //Динамический массив неделимых чисел, составленных из исходного массива.

            for (int i = 1; i < N; i++) { Nums_All.Add(i); }
            int group_number = 1;                                                                                           //Начальное значение номера групп.
            int Number_Key;                                                                                                 //Условие для проверки неделимости.
            while (Nums_All.Count != 0)
            {                                                                                   //Цикл, выполняющийся, пока кол-во элементов исходного массива не станет 0.
                Nums_Local.Add(Nums_All[0]);
                Nums_All.RemoveAt(0);
                for (int i = 0; i < Nums_All.Count; i++)                                                                    //Перебор начального массива.
                {
                    Number_Key = 0;
                    for (int j = 0; j < Nums_Local.Count; j++)                                                              //Перебор нового массива.
                    {
                        if (Nums_All[i] % Nums_Local[j] != 0) { Number_Key++; }                                              //Условие неделимости.
                    }
                    if (Number_Key == Nums_Local.Count)                                                                     //Заполнение нового массива,удаление элементов старого массива, если условие неделимости выполнено.
                    {
                        Nums_Local.Add(Nums_All[i]);
                        Nums_All.RemoveAt(i);
                    }
                }
                Output_Strings += "Группа № " + Convert.ToString(group_number) + ":";                                       //Запись в выходную строку полученного массива.
                for (int i = 0; i < Nums_Local.Count; i++) { Output_Strings += " " + Convert.ToString(Nums_Local[i]); }
                Output_Strings += "\r\n";

                Nums_Local.Clear();                                                                                         //Очистка массива.
                group_number++;

            }
            //Console.WriteLine(Output_Strings);
            return Output_Strings;
        }

        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string Files_Path = @"C:\Users\Kirill\Desktop";                                                     //Адрес хранения файлов.
            string Input_File_Name = "Input File.txt";                                                          //Имя входного файла.
            int N = Convert.ToInt32(File.ReadAllText(@$"{Files_Path}\{Input_File_Name}"));                      //Добавить исключение-проверку на наличие файла в папке.

            if (N > 1_000_000_000) { Console.WriteLine("Too long number!"); }
            else
            {
                string OutPut_File_Name = "OutPut File.txt";                                                    //Имя выходного файла.
                char Answer;
                bool AnswerKey = true;

                DateTime start = new DateTime();                                                                //Время(дата) начала работы приложения.
                string strings = Substracting_Number(N);                                                        //Получение результирующей строки групп неделимости.
                DateTime finish = new DateTime();                                                               //Время(дата) конца работы приложения.
                TimeSpan time = finish.Subtract(start);                                                         //Время работы приложения.
                Console.WriteLine($"time = {time.Milliseconds}");

                File.WriteAllText(@$"{Files_Path}\{OutPut_File_Name}", strings);
                Console.Write("Add results to the archive?(Y/N): ");
                Answer = Convert.ToChar(Console.ReadLine()[0]);
                while (AnswerKey == true)
                {
                    if ((Answer == 'N') || (Answer == 'Y')) { AnswerKey = false; }
                    else
                    {
                        Console.WriteLine("Incorrect form!");
                        Console.Write("Add results to the archive?(Y/N): ");
                        Answer = Convert.ToChar(Console.ReadLine()[0]);
                    }

                }
                //Архивация результатов.
                if (Answer == 'Y')
                {
                    string Output_File_Archive_Name = "Output_File_Archive.zip";
                    using (FileStream OutPut_Stream = new FileStream(@$"{Files_Path}\{OutPut_File_Name}", FileMode.OpenOrCreate))                      // Поток данных ,которые необходимо записать/архивировать.
                    {
                        using (FileStream New_Archive_Stream = File.Create(@$"{Files_Path}\{Output_File_Archive_Name}.zip"))                               // Поток - создание нового файла - архива.
                        {
                            using (GZipStream Archivating_Stream = new GZipStream(New_Archive_Stream, CompressionMode.Compress))    // Поток архивации данных потока создания нового файла(архива). 
                            {
                                OutPut_Stream.CopyTo(Archivating_Stream);                                                           // Копирование данных из входных данных(потока) в выходной.
                                Console.WriteLine("Archivating is over! Old Memory:{0} , New Memory:{1}.", OutPut_Stream.Length, New_Archive_Stream.Length);
                            }
                        }
                    }
                    Console.WriteLine("Enter to exit.");
                    Console.ReadKey();
                }
            }

        }
    }
}
