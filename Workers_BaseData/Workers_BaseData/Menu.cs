using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Workers_BaseData
{
    class Menu
    {
        /// <summary>
        /// Основная логика приложения.
        /// </summary>
        /// <param name="Data_Base"></param>
        public static void Render(List<Department> Data_Base)
        {
            Department New_Department;
            Worker New_Worker;
            string answer = "DataBase";
            bool key = false;
            string Path;
            //Данные ввода:
            int Department_Number = 0;
            int Worker_Number = 0;
            string Name = "";
            string Last_Name = "";
            int Age = 0;
            string Profession = "";
            double Salary = 0.0;
            while (answer != "exit")
            {
                if (answer == "DataBase")
                {
                    key = false;
                    Display.Render(Data_Base, "DataBase", 0);
                    while (key != true)
                    {
                        Console.Write("\nВведите необходимую операцию:");
                        answer = Console.ReadLine();
                        switch (answer)
                        {
                            case "1":
                                //Открыть департамент.
                                key = false;
                                while (key != true)
                                {
                                    Console.Write("Введите номер необходимого департамента:");
                                    try
                                    {
                                        key = true;
                                        Department_Number = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        key = false;
                                        Console.WriteLine("Некорректный ввод!");
                                    }
                                    finally
                                    {
                                        if (key == true)
                                        {
                                            if (Department_Number < Data_Base.Count)
                                            {
                                                answer = "Department";
                                            }
                                            else
                                            {
                                                key = false;
                                                Console.WriteLine("Некорректный ввод!");
                                                System.Threading.Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                }
                                break;

                            case "2":
                                //Добавить департамент.
                                Console.Write("Введите название нового департамента:");
                                New_Department = new Department(Console.ReadLine());
                                Data_Base.Add(New_Department);
                                answer = "DataBase";
                                key = true;
                                break;

                            case "3":
                                //Редактировать департамент.
                                key = false;
                                while (key != true)
                                {
                                    Console.Write("Введите номер необходимого департамента:");
                                    try
                                    {
                                        key = true;
                                        Department_Number = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        key = false;
                                        Console.WriteLine("Некорректный ввод!");
                                    }
                                    finally
                                    {
                                        if (key == true)
                                        {
                                            if (Department_Number < Data_Base.Count)
                                            {
                                                Console.Write("Введите новое имя департамента:");
                                                answer = Console.ReadLine();
                                                New_Department = new Department(answer, Data_Base[Department_Number].department_data_base);
                                                Data_Base[Department_Number] = New_Department;
                                            }
                                            else
                                            {
                                                key = false;
                                                Console.WriteLine("Некорректный ввод!");
                                                System.Threading.Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                }
                                answer = "DataBase";
                                break;

                            case "4":
                                //Удалить департамент.
                                key = false;
                                while (key != true)
                                {
                                    Console.Write("Введите номер удаляемого департамента:");
                                    try
                                    {
                                        key = true;
                                        Department_Number = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        key = false;
                                        Console.WriteLine("Некорректный ввод!");
                                    }
                                    finally
                                    {
                                        if (key == true)
                                        {
                                            if (Department_Number < Data_Base.Count)
                                            {
                                                Data_Base.RemoveAt(Department_Number);
                                            }
                                            else
                                            {
                                                key = false;
                                                Console.WriteLine("Некорректный ввод!");
                                                System.Threading.Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                }
                                answer = "DataBase";
                                break;

                            case "5":
                                //Импорт данных из файла.  
                                key = false;
                                while (key != true)
                                {
                                    Console.Write("Напишите необходимое расширение импорта(JSON/XML):");
                                    switch (Console.ReadLine().ToLower())
                                    {
                                        case "json":
                                            Path = "";
                                            Console.Write("Введите путь импорта(при пустом вводе автоматически импорт с диска С):");

                                            Path = Console.ReadLine();
                                            if (Path == "") { Path = "C:"; }
                                            Data_Base = JsonConvert.DeserializeObject<List<Department>>(File.ReadAllText(@Path + @"\DataBase.json"));
                                            Console.WriteLine("Выполнено.");

                                            System.Threading.Thread.Sleep(1000);
                                            key = true;
                                            break;

                                        case "xml":
                                            Path = "";
                                            Console.Write("Введите путь импорта(при пустом вводе автоматически импорт с диска С):");

                                            Path = Console.ReadLine();
                                            if (Path == "") { Path = "C:"; }
                                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));
                                            Stream DataBaseStream = new FileStream(@Path + @"\DataBase.xml", FileMode.Open, FileAccess.Read);
                                            Data_Base = xmlSerializer.Deserialize(DataBaseStream) as List<Department>;
                                            DataBaseStream.Close();
                                            Console.WriteLine("Выполнено.");

                                            System.Threading.Thread.Sleep(1000);
                                            key = true;
                                            break;

                                        default:
                                            Console.WriteLine("Некорректное расширение!");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                    }
                                }
                                answer = "DataBase";
                                break;

                            case "6":
                                //Экспорт данных в файл.
                                key = false;
                                while (key != true)
                                {
                                    Console.Write("Напишите необходимое расширение экспорта(JSON/XML):");
                                    switch (Console.ReadLine().ToLower())
                                    {
                                        case "json":
                                            Path = "";
                                            Console.Write("Введите путь экспорта(при пустом вводе автоматически экспорт на диск С):");
                                            Path = Console.ReadLine();
                                            if (Path == "") { Path = "C:"; }
                                            File.WriteAllText(@Path + @"\DataBase.json", JsonConvert.SerializeObject(Data_Base));
                                            Console.WriteLine("Выполнено.");
                                            System.Threading.Thread.Sleep(1000);
                                            key = true;
                                            break;

                                        case "xml":
                                            Path = "";
                                            Console.Write("Введите путь экспорта(при пустом вводе автоматически экспорт на диск С):");
                                            Path = Console.ReadLine();
                                            if (Path == "") { Path = "C:"; }
                                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));
                                            Stream DataBaseStream = new FileStream(@Path + @"\DataBase.xml", FileMode.OpenOrCreate, FileAccess.Write);
                                            xmlSerializer.Serialize(DataBaseStream, Data_Base);
                                            DataBaseStream.Close();
                                            Console.WriteLine("Выполнено.");
                                            System.Threading.Thread.Sleep(1000);
                                            key = true;
                                            break;

                                        default:
                                            Console.WriteLine("Некорректное расширение!");
                                            System.Threading.Thread.Sleep(1000);
                                            break;
                                    }
                                }
                                answer = "DataBase";
                                break;

                            case "7":
                                //Закрыть программу.
                                answer = "exit";
                                key = true;
                                break;

                            default:
                                Console.WriteLine("Некорректный ввод.");
                                key = false;
                                break;
                        }
                    }
                }
                if (answer == "Department")
                {
                    Display.Render(Data_Base, "Department", Department_Number);
                    Console.Write("\nВведите необходимую операцию:");
                    answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            //Добавить сотрудника.
                            key = false;
                            while (key != true)
                            {
                                try
                                {
                                    key = true;
                                    Console.Write("Введите имя нового сотрудника:");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите фамилию нового сотрудника:");
                                    Last_Name = Console.ReadLine();
                                    Console.Write("Введите возраст нового сотрудника:");
                                    Age = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Введите должность нового сотрудника:");
                                    Profession = Console.ReadLine();
                                    Console.Write("Введите зарплату нового сотрудника:");
                                    Salary = Convert.ToDouble(Console.ReadLine());
                                }
                                catch
                                {
                                    key = false;
                                    Console.WriteLine("Некорректный ввод!");
                                }
                                finally
                                {
                                    if (key == true)
                                    {
                                        if ((Age >= 18) && (Age <= 65))
                                        {
                                            New_Worker = new Worker(Data_Base[Department_Number].department_data_base.Count, Name, Last_Name, Age, Profession, Salary);
                                            Data_Base[Department_Number].AddWorker(New_Worker);
                                        }
                                        else
                                        {
                                            key = false;
                                            Console.WriteLine("Некорректный ввод!");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }
                            }
                            answer = "Department";
                            break;

                        case "2":
                            //Редактировать сотрудника.
                            key = false;
                            while (key != true)
                            {
                                Console.Write("Введите номер редактируемого сотрудника:");
                                try
                                {
                                    key = true;
                                    Worker_Number = Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    key = false;
                                    Console.WriteLine("Некорректный ввод!");
                                }
                                finally
                                {
                                    if (key == true)
                                    {
                                        if (Worker_Number >= Data_Base[Department_Number].department_data_base.Count)
                                        {
                                            key = false;
                                            Console.WriteLine("Некорректный ввод!");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }
                            }
                            key = false;
                            while (key != true)
                            {
                                try
                                {
                                    key = true;
                                    Console.Write("Введите новое имя сотрудника:");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите новую фамилию сотрудника:");
                                    Last_Name = Console.ReadLine();
                                    Console.Write("Введите новый возраст сотрудника:");
                                    Age = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Введите новую должность сотрудника:");
                                    Profession = Console.ReadLine();
                                    Console.Write("Введите новую зарплату сотрудника:");
                                    Salary = Convert.ToDouble(Console.ReadLine());
                                }
                                catch
                                {
                                    key = false;
                                    Console.WriteLine("Некорректный ввод!");
                                }
                                finally
                                {
                                    if (key == true)
                                    {
                                        if ((Age >= 18) && (Age <= 65))
                                        {
                                            Data_Base[Department_Number].Rewrite_Worker(Worker_Number, Name, Last_Name, Age, Profession, Salary);
                                        }
                                        else
                                        {
                                            key = false;
                                            Console.WriteLine("Некорректный ввод!");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }
                            }
                            answer = "Department";
                            break;

                        case "3":
                            //Удалить сотрудника.
                            key = false;
                            while (key != true)
                            {
                                Console.Write("Введите номер удаляемого сотрудника:");
                                try
                                {
                                    key = true;
                                    Worker_Number = Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    key = false;
                                    Console.WriteLine("Некорректный ввод!");
                                }
                                finally
                                {
                                    if (key == true)
                                    {
                                        if (Worker_Number < Data_Base[Department_Number].department_data_base.Count)
                                        {
                                            Data_Base[Department_Number].DeleteWorker(Worker_Number);
                                        }
                                        else
                                        {
                                            key = false;
                                            Console.WriteLine("Некорректный ввод!");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                    }
                                }
                            }
                            answer = "Department";
                            break;
                        case "4":
                            //Сортировка сотрудников.
                            Console.Write
                                (
                                "\nКлючи для сортировки по необходимому полю:\n" +
                                "1 - Номер сотрудника\n" +
                                "2 - Имя сотрудника\n" +
                                "3 - Фамилия сотрудника\n" +
                                "4 - Возраст сотрудника\n" +
                                "5 - Должность сотрудника\n" +
                                "6 - Зарплата сотрудника\n"
                                );
                            Console.Write("Введите необходимую операцию:");
                            answer = Console.ReadLine();
                            switch (answer)
                            {
                                case "1":
                                    Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "count");
                                    break;
                                case "2":
                                    Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "name");
                                    break;
                                case "3":
                                    Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "lastname");
                                    break;
                                case "4":
                                    Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "age");
                                    break;
                                case "5":
                                    Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "profession");
                                    break;
                                case "6":
                                    Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "salary");
                                    break;
                                default:
                                    Console.WriteLine("Некорректный ввод!");
                                    System.Threading.Thread.Sleep(1000);
                                    break;
                            }
                            answer = "Department";
                            break;
                        case "5":
                            //Закрыть департамент.
                            answer = "DataBase";
                            Data_Base[Department_Number] = Functions.Sort_Workers(Data_Base[Department_Number], "count");
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод!");
                            System.Threading.Thread.Sleep(1000);
                            answer = "Department";
                            break;

                    }
                }
            }
        }
    }
}
