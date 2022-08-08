using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
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
        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public void Add(Ski ski)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski != null)
            {
                data.Remove(ski);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            Ski ski = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return ski;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return ski;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
