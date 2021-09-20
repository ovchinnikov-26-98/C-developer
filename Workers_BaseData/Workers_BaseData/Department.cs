using System;
using System.Collections.Generic;
using System.Text;

namespace Workers_BaseData
{
    /// <summary>
    /// Класс департамент.
    /// </summary>
    public class Department
    {
        public string name;
        public DateTime time_of_creation;
        public List<Worker> department_data_base;

        public Department(string name)
        {
            this.name = name;
            this.time_of_creation = DateTime.Now;
            this.department_data_base = new List<Worker>(0);
        }
        public Department(string name_new, DateTime TimeNew)
        {
            this.name = name_new;
            this.time_of_creation = TimeNew;
            this.department_data_base = new List<Worker>(0);
        }
        public Department(string name_new, List<Worker> department_data_base_new)
        {
            this.name = name_new;
            this.time_of_creation = DateTime.Now;
            this.department_data_base = department_data_base_new;
        }
        public Department(string name, DateTime TimeNew, List<Worker> department_data_base)
        {
            this.name = name;
            this.time_of_creation = TimeNew;
            this.department_data_base = department_data_base;
        }
        public void AddWorker(Worker NewWorker)
        {
            this.department_data_base.Add(NewWorker);
        }
        public void DeleteWorker(int count)
        {
            department_data_base.RemoveAt(count);
        }
        public void Rewrite_Worker(int index, string name, string last_name, int age, string profession, double salary)
        {
            var data = this.department_data_base[index];
            data.Rewrite(name, last_name, age, profession, salary);
            this.department_data_base[index] = data;
        }
    }
}
