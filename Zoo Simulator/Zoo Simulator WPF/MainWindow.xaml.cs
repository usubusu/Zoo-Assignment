﻿// Next Step
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
using System.Windows.Media.Animation;
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
            Foods.Items.Add(Food.Apple);
            Foods.Items.Add(Food.Orange);
            Foods.Items.Add(Food.Leaves);
            Foods.Items.Add(Food.Nuts);
            Foods.Items.Add(Food.Meat);
            InfoHeaders.Items.Add("Name:");
            InfoHeaders.Items.Add("Type:");
            InfoHeaders.Items.Add("Hunger:");
            InfoHeaders.Items.Add("Mood:");
            InfoHeaders.Items.Add("ID:");
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
        /// <summary>
        /// Updates the animal listbox to contain all animals in the zoo class.
        /// </summary>
        private void UpdateAnimalList()
        {
            All_Animals.Items.Clear();
            foreach (Animal item in Zoo.allAnimals)
            {
                All_Animals.Items.Add(item);
            }
        }
        /// <summary>
        /// Updates the cages listbox to contain all cages in the zoo class.
        /// </summary>
        private void UpdateCageList()
        {
            All_Cages.Items.Clear();
            foreach (AnimalPen cage in Zoo.cages)
            {
                All_Cages.Items.Add(cage);
            }
        }
        /// <summary>
        /// Checks if the selected item in All_Animals already exists in SelectionsList, and adds it if not.
        /// </summary>
        private void All_Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool check = false;
            if (SelectionsList.Items.Count != 0)
            {
                foreach (object obj in SelectionsList.Items)
                {
                    if (obj == All_Animals.SelectedItem)
                    {
                        check = true;
                    }
                }
                if (!check)
                {
                    SelectionsList.Items.Add((Animal)All_Animals.SelectedItem);
                }
                UpdateAnimalInfo();
            }
            else
            {
                SelectionsList.Items.Add((Animal)All_Animals.SelectedItem);
            }
        }
        /// <summary>
        /// Clears the selection list.
        /// </summary>
        private void ClearSelection_Click(object sender, RoutedEventArgs e)
        {
            SelectionsList.Items.Clear();
        }
        /// <summary>
        /// Calls for the zoo to create a new cage on click, using the inputbox text as the name.
        /// </summary>
        private void AddCage_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text != null && InputBox.Text != "")
            {
                Zoo.NewCage(InputBox.Text);
            }
            UpdateCageList();
        }
        /// <summary>
        /// Takes the currently selected cage and adds all selected animals to it. Then clears selection list.
        /// </summary>
        private void AddAnimalsToCage_Click(object sender, RoutedEventArgs e)
        {
            if (All_Cages.SelectedIndex != -1)
            {
                foreach (Animal animal in SelectionsList.Items)
                {
                    Zoo.AddToCage((AnimalPen)All_Cages.SelectedItem, animal);
                }
            }
            UpdateSelectedCage();
            SelectionsList.Items.Clear();
        }
        private void All_Cages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedCage();
        }
        /// <summary>
        /// Clears the cage animals listbox and adds all the ones in the currently selected cage.
        /// </summary>
        private void UpdateSelectedCage()
        {
            Cage_Animals.Items.Clear();
            if (All_Cages.SelectedIndex != -1)
            {
                foreach (Animal animal in (All_Cages.SelectedItem as AnimalPen).animals)
                {
                    Cage_Animals.Items.Add(animal);
                }
                Cage_Animals.Items.Refresh();
            }
        }

        private void NewZooKeeper_Click(object sender, RoutedEventArgs e)
        {
            Zoo.NewZooKeeper();
            UpdateZooKeeperList();
        }
        /// <summary>
        /// Adds all zookeepers to the zookeeper listbox.
        /// </summary>
        private void UpdateZooKeeperList()
        {
            ZooKeeperList.Items.Clear();
            foreach (ZooKeeper keeper in Zoo.zooKeepers)
            {
                ZooKeeperList.Items.Add(keeper);
            }
        }

        /// <summary>
        /// Takes the selected cage, selected zookeeper, and selected food type and passes it to the zookeeper to feed the animals.
        /// </summary>
        private void FeedCage_Click(object sender, RoutedEventArgs e)
        {
            if (All_Cages.SelectedIndex != -1)
            {
                if (ZooKeeperList.SelectedIndex != -1)
                {
                    if (Foods.SelectedIndex != -1)
                    {
                        ((ZooKeeper)ZooKeeperList.SelectedItem).FeedCage(((Food)Foods.SelectedItem), ((AnimalPen)All_Cages.SelectedItem));
                        UpdateCageList();
                        UpdateAnimalList();
                    }
                }
            }
           
        }
        /// <summary>
        /// Removes the selected animals from the zoo and all cages, and updates all relevant lists.
        /// </summary>
        private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> remove = new List<Animal>();
            foreach (object obj in SelectionsList.Items)
            {
                remove.Add((Animal)obj);
            }
            foreach (Animal animal in remove)
            {
                Zoo.RemoveAnimal((Animal)animal);
            }
            UpdateAnimalList();
            UpdateCageList();
            SelectionsList.Items.Clear();
        }
        /// <summary>
        /// Calls Zoo's NextDay function and updates lists.
        /// </summary>
        private void NextDay_Click(object sender, RoutedEventArgs e)
        {
            Zoo.NextDay();
            UpdateAnimalList();
            UpdateCageList();
            SelectionsList.Items.Clear();
        }
        /// <summary>
        /// Takes the last selected animal and displays info for it.
        /// </summary>
        private void UpdateAnimalInfo()
        {
            Info.Items.Clear();
            if (!(All_Animals.SelectedIndex == -1))
            {
                Info.Items.Add(((Animal)All_Animals.SelectedItem).GetName());
                Info.Items.Add(((Animal)All_Animals.SelectedItem).GetAnimalType());
                Info.Items.Add(((Animal)All_Animals.SelectedItem).GetHunger());
                Info.Items.Add(((Animal)All_Animals.SelectedItem).GetMood());
                Info.Items.Add(((Animal)All_Animals.SelectedItem).ID);
            }
        }
    }
}
