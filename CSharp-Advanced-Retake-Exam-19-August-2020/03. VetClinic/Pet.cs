using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        private string name;
        private int age;
        private string owner;
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
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public Pet(string name, int age, string owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }
        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
