using System;
using System.Collections.Generic;




namespace Workers_BaseData
{
    /// <summary>
    /// Основная программа.
    /// </summary>
    class Program
    {  
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Department> Data_Base = new List<Department>(0);
            //Данные для генератора случайных работников:
            string ProfessionG;
            string[] Names = 
                { 
                    "Ксения","Светлана","Галина","Борис","Вадим","Виталий","Пётр","Тихон"
                    ,"Владислав","Татьяна","Дмитрий","Максим","Александр","Даниил","Иван"
                    ,"Матвей","Константин","Елизавета","Елена","Анжела","Полина","Ирина"
                    ,"Вячеслав","Наталья","Дарья", "Алина","Павел","Варвара","Андрей"
                };
            string[] Last_Names = 
                {
                "Смирнов(-a)","Иванов(-a)","Кузнецов(-a)","Соколов(-a)","Попов(-a)","Лебедев(-a)","Козлов(-a)","Новиков(-a)","Морозов(-a)"
                ,"Петров(-a)","Волков(-a)","Соловьёв(-a)","Васильев(-a)","Зайцев(-a)","Павлов(-a)","Семёнов(-a)","Голубев(-a)","Виноградов(-a)"
                ,"Богданов(-a)","Воробьёв(-a)","Фёдоров(-a)","Киселёв(-a)","Макаров(-a)","Андреев(-a)","Кузьмин(-a)","Кудрявцев(-a)"
                ,"Михайлов(-a)","Беляев(-a)","Тарасов(-a)","Белов(-a)","Комаров(-a)","Орлов(-a)","Ковалёв(-a)","Ильин(-a)","Гусев(-a)","Титов(-a)"
                };
            string[] Professions = 
                {
                    "Адвокат","Биолог","Бухгалтер","Фельдшер"
                    ,"Инженер-энергетик","Инженер","Радиотехник","Электрогазосварщик"
                    ,"Экономист","Эколог","Юрист","Хирург","Химик","Сварщик"
                    ,"Технолог пищевого производства","Медсестра","Менеджер по персоналу"
                };
            string[] Department_Names = 
                { 
                    "Документы",
                    "Инжиниринг",
                    "Медицина"
                };
            Worker New_Person;
            Random Random_Number = new Random();
            Department Generate_Department;
            //int Workers_Count = Random_Number.Next(3, 1_000_000);
            int Workers_Count;
            int Worker_Number_Base;
            //Генерирование изначальных данных:
            for (int j = 0; j < Department_Names.Length; j++)
            {
                Generate_Department = new Department(Department_Names[j]);
                Data_Base.Add(Generate_Department);
            }
            
            Workers_Count = (int)Random_Number.Next(3, 15) * 3;
            Worker_Number_Base = 0;
            for (int i = 0; i < Workers_Count; i++)
            {
                ProfessionG = Professions[(int)Random_Number.Next(0, Professions.Length)];
                New_Person = new Worker
                    (
                        Worker_Number_Base,
                        Names[(int)Random_Number.Next(0, Names.Length)],
                        Last_Names[(int)Random_Number.Next(0, Last_Names.Length)],
                        Random_Number.Next(18, 55),
                        ProfessionG,
                        Random_Number.Next(10_000, 60_000) + Random_Number.Next(0, 100) / 100
                    );
                if ((ProfessionG == "Адвокат") || (ProfessionG == "Бухгалтер") || (ProfessionG == "Экономист") || (ProfessionG == "Юрист") || (ProfessionG == "Менеджер по персоналу"))
                {
                    Data_Base[0].AddWorker(New_Person);
                    Worker_Number_Base++;
                }
            }

            Workers_Count = (int)Random_Number.Next(3, 15) * 3;
            Worker_Number_Base = 0;
            for (int i = 0; i < Workers_Count; i++)
            {
                ProfessionG = Professions[(int)Random_Number.Next(0, Professions.Length)];
                New_Person = new Worker
                    (
                        Worker_Number_Base,
                        Names[(int)Random_Number.Next(0, Names.Length)],
                        Last_Names[(int)Random_Number.Next(0, Last_Names.Length)],
                        Random_Number.Next(18, 55),
                        ProfessionG,
                        Random_Number.Next(10_000, 60_000) + Random_Number.Next(0, 100) / 100
                    );
                if ((ProfessionG == "Инженер-энергетик") || (ProfessionG == "Инженер") || (ProfessionG == "Радиотехник") || (ProfessionG == "Электрогазосварщик") || (ProfessionG == "Эколог") || (ProfessionG == "Сварщик") || (ProfessionG == "Технолог пищевого производства"))
                {
                    Data_Base[1].AddWorker(New_Person);
                    Worker_Number_Base++;
                }

            }
            
            Workers_Count = (int)Random_Number.Next(3, 15) * 3;
            Worker_Number_Base = 0;
            for (int i = 0; i < Workers_Count; i++)
            {
                ProfessionG = Professions[(int)Random_Number.Next(0, Professions.Length)];
                New_Person = new Worker
                    (
                        Worker_Number_Base,
                        Names[(int)Random_Number.Next(0, Names.Length)],
                        Last_Names[(int)Random_Number.Next(0, Last_Names.Length)],
                        Random_Number.Next(18, 55),
                        ProfessionG,
                        Random_Number.Next(10_000, 60_000) + Random_Number.Next(0, 100) / 100
                    );
                if ((ProfessionG == "Биолог") || (ProfessionG == "Фельдшер") || (ProfessionG == "Хирург") || (ProfessionG == "Химик") || (ProfessionG == "Медсестра"))
                {
                    Data_Base[2].AddWorker(New_Person);
                    Worker_Number_Base++;
                }
            }

            //Приложение:
            Menu.Render(Data_Base);
        }
    }
}
