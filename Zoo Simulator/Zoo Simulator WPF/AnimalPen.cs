using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public class AnimalPen
    {
        public List<Animal> animals = new List<Animal>();
        private bool docileStatus;
        public string cageName;

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
            //Console.WriteLine("Attempting to add " + animal + ". Current list count: " + animals.Count);
            if (animals.Count == 0)
            {
                animals.Add(animal);
                docileStatus = animal.docile;
                Console.WriteLine("Succesfully added " + animal + " to " + cageName + ". Now there are " + animals.Count + " animals in the cage.");
            }
            else if (animal.docile && docileStatus)
            {
                animals.Add(animal);
                Console.WriteLine("Succesfully added " + animal + " to " + cageName + ". Now there are " + animals.Count + " animals in the cage.");
            }
            else if (!animal.docile && !docileStatus)
            {
                animals.Add(animal);
                Console.WriteLine("Succesfully added " + animal + " to " + cageName + ". Now there are " + animals.Count + " animals in the cage.");
            }
            else
            {
                Console.WriteLine("Couldn't add " + animal + ". They would eat each other!");
            }
        }
        public void RemoveAnimal(int animalNum)
        {
            if (!(animalNum >= animals.Count))
            {
                animals.RemoveAt(animalNum);
            }
            else
            {
                Console.WriteLine("Failed to remove animal: Selection out of range.");
            }
        }
    }
}
