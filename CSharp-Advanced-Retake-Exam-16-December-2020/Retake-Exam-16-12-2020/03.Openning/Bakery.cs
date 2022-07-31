using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Openning
{
    public class Bakery
    {
        private List<Employee> data;
        private string name;
        private int capacity;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
            private set { }

        }
        public Bakery(string name, int capacity)
        {
            data = new List<Employee>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public void Add(Employee employee)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            if (employee != null)
            {
                data.Remove(employee);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Employee GetOldestEmployee()
        {
            Employee employee = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return employee;
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            return employee;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
