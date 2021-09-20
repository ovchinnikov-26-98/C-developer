using System;
using System.Collections.Generic;
using System.Text;

namespace Workers_BaseData
{
    /// <summary>
    /// Класс сотрудник.
    /// </summary>
    public class Worker
    {
        public int count;
        public string name;
        public string last_name;
        public int age;
        public string profession;
        public double salary;
        public Worker(int count, string name, string last_name, int age, string profession, double salary)
        {
            this.count = count;
            this.name = name;
            this.last_name = last_name;
            this.age = age;
            this.profession = profession;
            this.salary = salary;
        }
        public void Rewrite(string name, string last_name, int age, string profession, double salary)
        {
            this.name = name;
            this.last_name = last_name;
            this.age = age;
            this.profession = profession;
            this.salary = salary;
        }
        public string Print_Worker()
        {
            string OutWorker;
            OutWorker =
                Convert.ToString(this.count) + " " +
                this.name + " " +
                this.last_name + " " +
                Convert.ToString(this.age) + " " +
                this.profession + " " +
                Convert.ToString(this.salary);
            return OutWorker;
        }
    }
}
