using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> data;
        private string name;
        private int capacity;
        private double landingStrip;
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
        public double LandingStrip
        {
            get { return landingStrip; }
            set { landingStrip = value; }
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
            private set { }
        }
        public Airfield(string name, int capacity, double landingStrip)
        {
            data = new List<Drone>();
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
        }
        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Name == string.Empty
                || drone.Brand == null || drone.Brand == String.Empty
                || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (data.Count >= capacity)
            {
                return "Airfield is full.";
            }
            data.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            Drone drone = data.Find(x => x.Name == name);
            if (drone != null)
            {
                data.Remove(drone);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int countDroneRemoved = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Brand == brand)
                {
                    data.Remove(data[i]);
                    i--;
                    countDroneRemoved++;
                }
            }
            return countDroneRemoved;
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = data.Find(x => x.Name == name);
            if (drone != null)
            {
                drone.Available = false;
                return drone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();
            foreach (var item in data)
            {
                if (item.Range >= range && item.Available == true)
                {
                    item.Available = false;
                    drones.Add(item);
                }
            }
            return drones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in data)
            {
                if (item.Available == true)
                    sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
