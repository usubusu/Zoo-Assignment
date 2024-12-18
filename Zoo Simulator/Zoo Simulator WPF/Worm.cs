﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    internal class Worm : Animal
    {
        public Worm(int id)
        {
            GenerateAnimal();
            type = "Worm";
            docile = true;
            ID = id;
        }
        public override void SetDiet()
        {
            foods.Add(Food.Leaves);
            if (rng.Next(0, 2) == 0)
            {
                foods.Add(Food.Nuts);
            }
        }
    }
}
