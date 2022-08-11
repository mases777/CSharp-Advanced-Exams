using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> data;
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Laps
        {
            get { return laps; }
            set { laps = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int MaxHorsePower
        {
            get { return maxHorsePower; }
            set { maxHorsePower = value; }
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
            private set { }
        }
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            data = new List<Car>();
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public void Add(Car car)
        {
            if (data.Count + 1 <= Capacity && car.HorsePower <= MaxHorsePower)
            {
                data.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            Car car = data.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (car != null)
            {
                data.Remove(car);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car car = data.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return car;
        }
        public Car GetMostPowerfulCar()
        {
            Car car = data.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            return car;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
