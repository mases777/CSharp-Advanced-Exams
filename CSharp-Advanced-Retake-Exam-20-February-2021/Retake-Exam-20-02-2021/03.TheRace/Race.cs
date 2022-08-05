using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;        
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
        public Race(string name, int capacity)
        {
            data = new List<Racer>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public void Add(Racer racer)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);
            if (racer != null)
            {
                data.Remove(racer);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Racer GetOldestRacer()
        {
            Racer racer = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return racer;
        }
        public Racer GetRacer(string namer)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);
            return racer;
        }
        public Racer GetFastestRacer()
        {
            Racer racer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return racer;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
