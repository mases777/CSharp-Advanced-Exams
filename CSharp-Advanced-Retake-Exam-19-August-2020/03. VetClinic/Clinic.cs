using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;        
        private int capacity;        
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
        public Clinic(int capacity)
        {
            data = new List<Pet>();            
            this.Capacity = capacity;
        }
        public void Add(Pet pet)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name);
            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Pet GetOldestPet()
        {
            Pet pet = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return pet;
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return pet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");

            foreach (var item in data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
