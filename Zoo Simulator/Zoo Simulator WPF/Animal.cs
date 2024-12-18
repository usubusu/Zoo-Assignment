﻿using System;
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
            CalculateMood();
        }
        public string GetName()
        {
            return name;
        }
        public string GetAnimalType()
        {
            return type;
        }
        public string GetMood()
        {
            return mood.ToString();
        }
        public int GetHunger()
        {
            return hunger;
        }
        /// <summary>
        /// Calculates which mood the animal should have based on its hunger level.
        /// </summary>
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
        /// <summary>
        /// Reduces the animals hunger by 10-30 (more hungry) and calculates mood.
        /// </summary>
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
        /// <summary>
        /// Increases the animals hunger by 30-50 (less hungry) and calculates mood.
        /// </summary>
        public void Eat()
        {
            hunger += rng.Next(30, 50);
            if (hunger > 100)
            {
                hunger = 100;
            }
            CalculateMood();
        }
        public override string ToString()
        {
            return $"{type}: {name}";
        }
    }
}
