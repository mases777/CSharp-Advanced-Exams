using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {        
        private string name;
        private int age;
        private string country;
        private Car car;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public Racer(string name, int age, string country, Car car)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
            this.Car = car;
        }

        public override string ToString()
        {
            return $"Racer: {Name}, {Age} ({Country})";
        }
    }
}
