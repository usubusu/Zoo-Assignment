using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public static class Zoo
    {
        public static List<ZooKeeper> zooKeepers = new List<ZooKeeper>();
        public static List<Animal> allAnimals = new List<Animal>();
        public static List<AnimalPen> cages = new List<AnimalPen>();
        private static int IDCount;

        /// <summary>
        /// Prints a list of all animals, zookeepers and cages, for debugging in console.
        /// </summary>
        public static void PrintList()
        {
            foreach (Animal animal in allAnimals)
            {
                animal.GetName();
            }
            foreach (ZooKeeper keeper in zooKeepers)
            {
                Console.WriteLine(keeper.name);
            }
            foreach (AnimalPen cage in cages)
            {
                Console.WriteLine(cage.cageName);
            }
        }

        /// <summary>
        /// Creates a new animal and gives it an incrementing ID.
        /// </summary>
        /// <param name="type">The type of animal to generate.</param>
        public static void NewAnimal(AnimalType type)
        {
            IDCount++;
            if (type == AnimalType.Capybara)
            {
                allAnimals.Add(new Capybara(IDCount));
            }
            else if (type == AnimalType.Velociraptor)
            {
                allAnimals.Add(new Velociraptor(IDCount));
            }
            else
            {
                allAnimals.Add(new Worm(IDCount));
            }
        }
        public static void NewZooKeeper()
        {
            zooKeepers.Add(new ZooKeeper());
        }
        /// <summary>
        /// Creates a new cage.
        /// </summary>
        /// <param name="name">The name of the cage.</param>
        public static void NewCage(string name)
        {
            cages.Add(new AnimalPen(name));
        }
        /// <summary>
        /// Adds an animal to a cage if the specified animal is not already there.
        /// </summary>
        /// <param name="cage">The cage to add the animal to.</param>
        /// <param name="animal">The animal to add to the cage.</param>
        public static void AddToCage(AnimalPen cage, Animal animal)
        {
            if (!Zoo.CheckForAnimal(cage, animal))
            {
                cage.AddAnimal(animal);
            }
        }
        /// <summary>
        /// Calls for all animals to update their hunger, simulating time passage.
        /// </summary>
        public static void NextDay()
        {
            foreach (Animal animal in allAnimals)
            {
                animal.UpdateHunger();
            }
        }
        /// <summary>
        /// Checks if an animal exists in a given cage.
        /// </summary>
        /// <param name="cage">The cage to check.</param>
        /// <param name="animal">The animal to check for.</param>
        /// <returns></returns>
        public static bool CheckForAnimal(AnimalPen cage, Animal animal)
        {
            foreach (Animal checkAnimal in cage.animals)
            {
                if (checkAnimal == animal)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Removes a given animal from the zoo and all cages.
        /// </summary>
        /// <param name="animal">The animal to remove.</param>
        public static void RemoveAnimal(Animal animal)
        {
            Zoo.allAnimals.Remove(animal);
            foreach (AnimalPen cage in cages)
            {
                cage.RemoveAnimal(animal);
            }
        }
    }
}
