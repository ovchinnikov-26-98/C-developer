using System;
using System.Collections.Generic;
using System.Text;

namespace Workers_BaseData
{
    class Display
    {
        /// <summary>
        /// Функция отображения информации на экране.
        /// </summary>
        /// <param name="Data_Base">База данных предприятия.</param>
        /// <param name="TypeOfRender">Тип отображаемой информации.</param>
        /// <param name="Department_Number">Номер необходимого департамента для отображения сотрудников.</param>
        public static void Render(List<Department> Data_Base, string TypeOfRender, int Department_Number)
        {
            string operations;
            string data;

            Console.Clear();
            Console.WindowWidth = 150;
            if (TypeOfRender == "DataBase")
            {
                operations =
                            "\n1-Открыть департамент" +
                            "\n2-Добавить департамент" +
                            "\n3-Редактировать департамент" +
                            "\n4-Удалить департамент" +
                            "\n5-Импортировать данные из файла" +
                            "\n6-Экспортировать данные в файл" +
                            "\n7-Закрыть базу данных";
                data =
                        "Номер департамента | " +
                        "Название департамента | " +
                        "Дата создания департамента | " +
                        "Количество сотрудников | ";

                Console.WriteLine(data);
                for (int i = 0; i < Data_Base.Count; i++)
                {
                    Console.WriteLine($"{i,18}" + $"{Data_Base[i].name,21}" + $"{Data_Base[i].time_of_creation,26}" + $"{Data_Base[i].department_data_base.Count,22}");
                }
                Console.WriteLine(operations);
                //Открыть/Добавить/Редактировать/Удалить/Импорт/Экспорт/Закрыть.
            }
            if (TypeOfRender == "Department")
            {
                operations =
                            "\n1-Добавить сотрудника" +
                            "\n2-Редактировать данные сотрудника" +
                            "\n3-Удалить сотрудника" +
                            "\n4-Сортировать сотрудников" +
                            "\n5-Закрыть департамент";
                data =
                        "Номер сотрудника | " +
                        "Имя сотрудника | " +
                        "Фамилия сотрудника | " +
                        "Возраст сотрудника | " +
                        "Должность сотрудника | " +
                        "Зарплата сотрудника | ";
                Console.WriteLine(data);
                for (int i = 0; i < Data_Base[Department_Number].department_data_base.Count; i++)
                {
                    Console.WriteLine
                        (
                        $"{Data_Base[Department_Number].department_data_base[i].count,15}" +
                        $"{Data_Base[Department_Number].department_data_base[i].name,15}" +
                        $"{Data_Base[Department_Number].department_data_base[i].last_name,18}" +
                        $"{Data_Base[Department_Number].department_data_base[i].age,18}" +
                        $"{Data_Base[Department_Number].department_data_base[i].profession,22}" +
                        $"{Data_Base[Department_Number].department_data_base[i].salary,19}"
                        );
                }
                Console.WriteLine(operations);
                //Добавить/Редактировать/Удалить/Сортировать/Закрыть - Сотрудника/Департамент(последнее).
            }
        }
    }
}
