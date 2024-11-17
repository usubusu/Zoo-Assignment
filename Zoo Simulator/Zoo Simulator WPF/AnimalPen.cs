using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zoo_Simulator
{
    public class AnimalPen
    {
        public List<Animal> animals = new List<Animal>();
        private bool docileStatus;
        public string cageName;
        private List<Animal> animalsToAdd = new List<Animal>();

        public AnimalPen(string name)
        {
            cageName = name;
        }
        public void GetAnimals()
        {
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Animals in " + cageName + ":");
            if (docileStatus)
            {
                Console.WriteLine("The animals in this cage are docile.");
            }
            else
            {
                Console.WriteLine("The animals in this cage are not docile.");
            }
            Console.ResetColor();
            foreach (Animal animal in animals)
            {
                animal.GetName();
                animal.CalculateMood();
                animal.GetHunger();
                Console.WriteLine("---------------");
            }
        }
        public void AddAnimal(Animal animal)
        {
            if (animals.Count == 0)
            {
                animals.Add(animal);
                docileStatus = animal.docile;
            }
            else 
            {
                if (animal.docile && docileStatus)
                {
                    animals.Add(animal);
                }
                else if (!animal.docile && !docileStatus)
                {
                    animals.Add(animal);
                }
                else
                {
                    Console.WriteLine("Couldn't add " + animal + ". They would eat each other!");
                }
            }
        }
        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
        }
        public override string ToString()
        {
            return $"{cageName}";
        }
    }
}
