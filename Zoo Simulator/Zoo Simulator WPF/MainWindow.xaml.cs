// Next Step
// Find out how to get the correct data when selecting an animal, and put that data into the selected box.
// Also make sure the selected box doesn't already have that data, before adding.
// Use animal ID to locate the desired animal.

// Use the same logic for finding a cage and zookeeper, to then feed the animals in that cage using the zookeeper.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo_Simulator;

namespace Zoo_Simulator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Animal> selections = new List<Animal>();
        public MainWindow()
        {
            InitializeComponent();
            Zoo.NewAnimal(AnimalType.Capybara);
            UpdateAnimalList();
        }

        private void Button_Click_AddCapybara(object sender, RoutedEventArgs e)
        {
            Zoo.NewAnimal(AnimalType.Capybara);
            UpdateAnimalList();
        }

        private void Button_Click_AddVelociraptor(object sender, RoutedEventArgs e)
        {
            Zoo.NewAnimal(AnimalType.Velociraptor);
            UpdateAnimalList();
        }

        private void Button_Click_AddWorm(object sender, RoutedEventArgs e)
        {
            Zoo.NewAnimal(AnimalType.Worm);
            UpdateAnimalList();
        }
        
        private void UpdateAnimalList()
        {
            All_Animals.Items.Clear();
            foreach (Animal item in Zoo.allAnimals)
            {
                All_Animals.Items.Add(item.GetAnimalType() + " #" + item.ID + "; " + item.GetName());
            }
        }
        private void UpdateCageList()
        {
            All_Cages.Items.Clear();
            foreach (AnimalPen cage in Zoo.cages)
            {
                All_Cages.Items.Add(cage.cageName);
            }
        }

        private void All_Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionsList.Items.Add("placeholder");
        }

        private void ClearSelection_Click(object sender, RoutedEventArgs e)
        {
            SelectionsList.Items.Clear();
        }

        private void AddCage_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text != null && InputBox.Text != "")
            {
                Zoo.NewCage(InputBox.Text);
            }
            UpdateCageList();
        }
    }
}
