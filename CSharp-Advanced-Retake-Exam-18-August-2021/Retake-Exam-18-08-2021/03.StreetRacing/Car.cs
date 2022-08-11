using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        private string make;
        private string model;
        private string licensePlate;
        private int horsePower;
        private double weight;
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"License Plate: {LicensePlate}");
            sb.AppendLine($"Horse Power: {HorsePower}");
            sb.AppendLine($"Weight: {Weight}");
            return sb.ToString().TrimEnd();
        }
    }
}
