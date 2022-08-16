using System;
using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available;        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Range
        {
            get { return range; }
            set { range = value; }
        }
        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");
            return sb.ToString().TrimEnd();
        }
    }
}
