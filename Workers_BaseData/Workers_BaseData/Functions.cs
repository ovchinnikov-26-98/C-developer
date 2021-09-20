using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Workers_BaseData
{
    class Functions
    {
        /// <summary>
        /// Сортировка департамента по рабочим.
        /// </summary>
        /// <param name="Sort_Department">Передаваемый департамент.</param>
        /// <param name="sort">Ключ для сортировки.</param>
        /// <returns></returns>
        public static Department Sort_Workers(Department Sort_Department, string sort)
        {
            Worker Replace_Worker;
            for (int i = 0; i < Sort_Department.department_data_base.Count; i++)
            {
                for (int j = 0; j < Sort_Department.department_data_base.Count - i - 1; j++)
                {
                    switch (sort)
                    {
                        case "name":
                            if (Convert.ToInt32(Sort_Department.department_data_base[j].name[0]) >= Convert.ToInt32(Sort_Department.department_data_base[j + 1].name[0]))
                            {
                                Replace_Worker = Sort_Department.department_data_base[j];
                                Sort_Department.department_data_base[j] = Sort_Department.department_data_base[j + 1];
                                Sort_Department.department_data_base[j + 1] = Replace_Worker;
                            }
                            break;
                        case "lastname":
                            if (Convert.ToInt32(Sort_Department.department_data_base[j].last_name[0]) >= Convert.ToInt32(Sort_Department.department_data_base[j + 1].last_name[0]))
                            {
                                Replace_Worker = Sort_Department.department_data_base[j];
                                Sort_Department.department_data_base[j] = Sort_Department.department_data_base[j + 1];
                                Sort_Department.department_data_base[j + 1] = Replace_Worker;
                            }
                            break;
                        case "profession":
                            if (Convert.ToInt32(Sort_Department.department_data_base[j].profession[0]) >= Convert.ToInt32(Sort_Department.department_data_base[j + 1].profession[0]))
                            {
                                Replace_Worker = Sort_Department.department_data_base[j];
                                Sort_Department.department_data_base[j] = Sort_Department.department_data_base[j + 1];
                                Sort_Department.department_data_base[j + 1] = Replace_Worker;
                            }
                            break;
                        case "age":
                            if (Convert.ToDouble(Sort_Department.department_data_base[j].age) >= Convert.ToInt32(Sort_Department.department_data_base[j + 1].age))
                            {
                                Replace_Worker = Sort_Department.department_data_base[j];
                                Sort_Department.department_data_base[j] = Sort_Department.department_data_base[j + 1];
                                Sort_Department.department_data_base[j + 1] = Replace_Worker;
                            }
                            break;
                        case "salary":
                            if (Convert.ToDouble(Sort_Department.department_data_base[j].salary) >= Convert.ToInt32(Sort_Department.department_data_base[j + 1].salary))
                            {
                                Replace_Worker = Sort_Department.department_data_base[j];
                                Sort_Department.department_data_base[j] = Sort_Department.department_data_base[j + 1];
                                Sort_Department.department_data_base[j + 1] = Replace_Worker;
                            }
                            break;
                        case "count":
                            if (Convert.ToDouble(Sort_Department.department_data_base[j].count) >= Convert.ToInt32(Sort_Department.department_data_base[j + 1].count))
                            {
                                Replace_Worker = Sort_Department.department_data_base[j];
                                Sort_Department.department_data_base[j] = Sort_Department.department_data_base[j + 1];
                                Sort_Department.department_data_base[j + 1] = Replace_Worker;
                            }
                            break;
                    }
                }
            }

            return Sort_Department;
        }  
    }
}
