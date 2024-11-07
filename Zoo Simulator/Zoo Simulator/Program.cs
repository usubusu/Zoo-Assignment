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
            Capybara capy = new Capybara();
            capy.GetName();
            capy.GetHunger();
            capy.CalculateMood();
            Console.Write("eats: ");
            foreach (Food food in capy.foods)
            {
                Console.Write(food + " ");
            }

            Console.WriteLine(); Console.WriteLine();
            capy.UpdateHunger();
            Console.WriteLine();





            Console.ReadKey();
        }
    }
}
