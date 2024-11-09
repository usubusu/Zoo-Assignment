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
        static void Main(string[] args)
        {
            AnimalPen cage1 = new AnimalPen("cage1");
            cage1.AddAnimal(new Worm());
            cage1.AddAnimal(new Capybara());
            cage1.AddAnimal(new Velociraptor());
            cage1.AddAnimal(new Worm());
            cage1.AddAnimal(new Velociraptor());
            cage1.GetAnimals();

            ZooKeeper keeper1 = new ZooKeeper();
            keeper1.FeedCage(Food.Nuts, cage1);





            Console.ReadKey();
        }
    }
}
