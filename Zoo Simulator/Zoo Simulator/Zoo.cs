using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Simulator
{
    internal class Zoo
    {
        public List<ZooKeeper> zooKeepers = new List<ZooKeeper>();
        private List<Animal> INSERTALLANIMALS = new List<Animal>();



        public void PrintList()
        {
            foreach (Animal animal in Program.allAnimals)
            {
                animal.GetName();
            }
        }
    }
}
