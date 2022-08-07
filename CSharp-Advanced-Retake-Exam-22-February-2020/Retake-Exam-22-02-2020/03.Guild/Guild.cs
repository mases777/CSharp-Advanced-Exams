using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>(capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;
        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = roster.Find(x => x.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PromotePlayer(string name)
        {
            if (roster.Find(x => x.Name == name) == null || roster.Find(x => x.Name == name).Rank == "Member")
                return;
            else
            {
                roster.Find(x => x.Name == name).Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            if (roster.Find(x => x.Name == name) == null || roster.Find(x => x.Name == name).Rank == "Trial")
                return;
            else
            {
                roster.Find(x => x.Name == name).Rank = "Trial";
            }

        }
        public Player[] KickPlayersByClass(string classText)
        {
            Player[] arr;
            arr = roster.Where(x => x.Class == classText).ToArray();
            roster = roster.Where(x => x.Class != classText).ToList();
            return arr;
        }
        public string Report()
        {

            string a = $"Players in the guild: {this.Name}";
            if (this.Count != 0)
                a += $"\n{String.Join("\n", roster)}";
            return a;
        }
    }
}
