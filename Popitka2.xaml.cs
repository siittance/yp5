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
using System.Windows.Shapes;

namespace YP5
{
    /// <summary>
    /// Логика взаимодействия для Popitka2.xaml
    /// </summary>
    public partial class Popitka2 : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public Popitka2()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Pets.ToList();
            Combo1.ItemsSource = yp.BreedOfPet.ToList();
            Combo1.SelectedValuePath = "ID_BreedOfPet";
            Combo1.DisplayMemberPath = "NameOfBreed";
            Combo2.ItemsSource = yp.Shelter.ToList();
            Combo2.SelectedValuePath = "ID_Shelter";
            Combo2.DisplayMemberPath = "TownOfShelter";
            Combo3.ItemsSource = yp.NaimenovaniePetsa.ToList();
            Combo3.SelectedValuePath = "ID_Naimenovanie";
            Combo3.DisplayMemberPath = "Naimenovanie";
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VtorayaRol vtorayaRol = new VtorayaRol();
            vtorayaRol.Show();
            Close();    
        }
    }
}
