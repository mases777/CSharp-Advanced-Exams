using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }
        //•   Name: string
        //•   Capacity: int - the maximum allowed number of ingredients in the cocktail
        //•   MaxAlcoholLevel: int - the maximum allowed amount of alcohol in the cocktail
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        //•   Method Add(Ingredient ingredient) - adds the entity if there isn't an Ingredient with the same name and if there is enough space in terms of quantity and alcohol.
        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.Count < this.Capacity && this.MaxAlcoholLevel > ingredient.Alcohol &&
                this.Ingredients.Any(x => x.Name == ingredient.Name) == false)
            {
                this.Ingredients.Add(ingredient);
            }
        }
        //•   Method Remove(string name) - removes an Ingredient from the cocktail with the given name, if such exists and returns bool if the deletion is successful.
        public bool Remove(string name)
        {
            if (this.Ingredients.Any(x => x.Name == name))
            {
                this.Ingredients.Remove(this.Ingredients.First(x => x.Name == name));
                return true;
            }

            return false;
        }
        //•   Method FindIngredient(string name) - returns an Ingredient with the given name.If it doesn't exist, return null.
        public Ingredient FindIngredient(string name)
        {
            if (this.Ingredients.Any(x => x.Name == name))
            {
                return this.Ingredients.First(x => x.Name == name);
            }

            return null;
        }
        //•   Method GetMostAlcoholicIngredient() – returns the Ingredient with most Alcohol.
        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(x => x.Alcohol).First();
        }
        //•   Getter CurrentAlcoholLevel – returns the amount of alcohol currently in the cocktail.
        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        //    •   Method Report() - returns information about the Cocktail and the Ingredients inside it in the following format:
        //"Cocktail: {name} - Current Alcohol Level: {CurrentAlcoholLevel}
        //{Ingredient1
        //}
        //{Ingredient2
        //}
        //… "
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
