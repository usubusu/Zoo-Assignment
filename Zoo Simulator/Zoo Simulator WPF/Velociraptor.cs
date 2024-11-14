using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    internal class Velociraptor : Animal
    {
        public Velociraptor(int id)
        {
            GenerateAnimal();
            type = "Velociraptor";
            docile = false;
            ID = id;
        }
        public override void SetDiet()
        {
            foods.Add(Food.Meat);
            foods.Add(Food.Orange);
            if (rng.Next(0, 2) == 0)
            {
                foods.Add(Food.Leaves);
            }
            if (rng.Next(0, 2) == 0)
            {
                foods.Add(Food.Nuts);
            }
        }
    }
}
