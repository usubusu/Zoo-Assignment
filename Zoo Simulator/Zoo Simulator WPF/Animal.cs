using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public abstract class Animal
    {
        #region Variables
        protected string name;
        protected int hunger;
        protected Mood mood;
        public HashSet<Food> foods = new HashSet<Food> { };
        protected string[] possibleNames = new string[] { "Heath", "Sven", "DaBaby", "Slungus", "Princess", "Kumala", "Gort", "Quandale Dingle", "Heinz Roasted Garlic Ketchup", "Vinegar", "Gimbus, the Destroyer of many" };
        public bool docile;
        protected static Random rng = new Random();
        protected string type;
        public int ID;
        #endregion

        public abstract void SetDiet();
        public void GenerateAnimal()
        {
            name = possibleNames[rng.Next(0, 11)];
            hunger = rng.Next(20, 100);
            SetDiet();
        }
        public string GetName()
        {
            return name;
        }
        public string GetAnimalType()
        {
            return type;
        }
        public int GetHunger()
        {
            Console.WriteLine("hunger: " + hunger);
            return hunger;
        }
        public void CalculateMood()
        {
            if (hunger >= 95)
            {
                mood = Mood.Ecstatic;
            }
            else if (hunger >= 80)
            {
                mood = Mood.Happy;
            }
            else if (hunger >= 60)
            {
                mood = Mood.Satisfied;
            }
            else if (hunger >= 40)
            {
                mood = Mood.Neutral;
            }
            else if (hunger >= 20)
            {
                mood = Mood.Grumpy;
            }
            else
            {
                mood = Mood.Enraged;
            }
            Console.WriteLine("Mood: " + mood);
        }
        public void UpdateHunger()
        {
            hunger -= rng.Next(10, 30);
            if (hunger <= 0)
            {
                hunger = 0;
            }
            Console.WriteLine(hunger);
            CalculateMood();
        }
        public void Eat()
        {
            hunger += rng.Next(30, 50);
            if (hunger > 100)
            {
                hunger = 100;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(name + " has eaten.");
            Console.ResetColor();
        }
        public override string ToString()
        {
            return $"{type} #{ID}; {name}";
        }
    }
}
