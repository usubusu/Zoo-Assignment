using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    public class ZooKeeper
    {
        public string name;
        private string[] possibleNames = new string[] { "Jørgen", "Garen from League of Legends", "Uncle farmer Ben", "Jarold", "Uffe", "Theis", "Jesus Christ the 2nd", "Jane", "Gwen", "Alex"};
        private static Random rng = new Random();

        public ZooKeeper()
        {
            name = possibleNames[rng.Next(0, 10)];
        }
        public void FeedCage(Food food, AnimalPen cage)
        {
            Console.WriteLine("Feeding " + food + " to " + cage.cageName);
            foreach (Animal cageAnimal in cage.animals)
            {
                if (cageAnimal.foods.Contains(food))
                {
                    cageAnimal.Eat();
                }
            }
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
