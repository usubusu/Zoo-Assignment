using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    internal class Capybara : Animal
    {
        public Capybara(int id)
        {
            GenerateAnimal();
            type = "Capybara";
            docile = true;
            ID = id;
        }
        public override void SetDiet()
        {
            foods.Add(Food.Orange);
            foods.Add(Food.Apple);
            if (rng.Next (0,2) == 0)
            {
                foods.Add(Food.Nuts);
            }
        }
    }
}
