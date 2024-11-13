using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public static class Zoo
    {

        private static List<ZooKeeper> zooKeepers = new List<ZooKeeper>();
        private static List<Animal> allAnimals = new List<Animal>();
        private static List<AnimalPen> cages = new List<AnimalPen>();

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
        public static void NewAnimal(AnimalType type)
        {
            if (type == AnimalType.Capybara)
            {
                allAnimals.Add(new Capybara());
            }
            else if (type == AnimalType.Velociraptor)
            {
                allAnimals.Add(new Velociraptor());
            }
            else
            {
                allAnimals.Add(new Worm());
            }
        }
        public static void NewZooKeeper()
        {
            zooKeepers.Add(new ZooKeeper());
        }
        public static void NewCage(string name)
        {
            cages.Add(new AnimalPen(name));
        }
        public static void AddToCage(AnimalPen cage, Animal animal)
        {
            cage.AddAnimal(animal);
        }
        public static void NextDay()
        {
            foreach (Animal animal in allAnimals)
            {
                animal.UpdateHunger();
            }
        }
    }
}
