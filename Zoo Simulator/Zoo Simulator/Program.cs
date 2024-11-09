using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    enum Food { Orange, Apple, Meat, Nuts, Leaves }
    enum Mood { Ecstatic, Happy, Satisfied, Neutral, Grumpy, Enraged }

    internal class Program
    {
        public Zoo zoo = new Zoo();
        public static List<Animal> allAnimals = new List<Animal>();

        static void Main(string[] args)
        {
            AnimalPen pen1 = new AnimalPen("pen1");
            pen1.AddAnimal(new Worm());
            pen1.AddAnimal(new Worm());
            pen1.AddAnimal(new Worm());
            AnimalPen pen2 = new AnimalPen("pen2");
            pen2.AddAnimal(new Worm());
            pen2.AddAnimal(new Worm());
            Console.WriteLine();

            ZooKeeper keeper1 = new ZooKeeper();
            keeper1.FeedCage(Food.Nuts, pen1);
            pen1.GetAnimals();


            // Currently missing:
            // allAnimals list in this file needs to be a part of the Zoo class, and every Animal needs to add itself Zoo's list when generating themselves.
            // Zoo needs to implement a NextDay() function to simulate the progression of time. This will call functions in all animals in its list.
            // Zoo also needs to add every ZooKeeper to its list.





            Console.ReadKey();
        }
    }
}
