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
using System.Xml.Linq;

namespace YP5
{
    /// <summary>
    /// Логика взаимодействия для Pitomci.xaml
    /// </summary>
    public partial class Pitomci : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public Pitomci()
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
        private void ClearInputs()
        {
            ReadDannie1.Text = null;
            ReadDannie.Text = null;
            ReadDannie2.Text = null;
            Combo1.SelectedItem = null;
            Combo2.SelectedItem = null;
            Combo3.SelectedItem = null;
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Pets)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.PetName.ToString();
                ReadDannie1.Text = proverka.Documents.ToString();
                ReadDannie2.Text = proverka.Price.ToString();
                Combo1.SelectedValue = proverka.BreedOfPet_ID;
                Combo2.SelectedValue = proverka.Shelter_ID;
                Combo3.SelectedValue = proverka.Naimenovanie_ID;
            }
        }

        private void ReadDannie_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 25)
            {
                textBox.Text = textBox.Text.Substring(0, 25);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void ReadDannie1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ReadDannie2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReadDannie_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void ReadDannie1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private bool IsDecimalInputValid(string input)
        {
            decimal result;
            bool isValid = decimal.TryParse(input, out result);
            if (isValid)
            {
                int commaCount = input.Count(c => c == ',');
                if (commaCount > 1)
                {
                    isValid = false;
                }
            }
            return isValid;


        }
        private void ReadDannie2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
                TextBox textBox = sender as TextBox;
                string text = textBox.Text.Insert(textBox.SelectionStart, e.Text);
                if (!IsDecimalInputValid(text))
                {
                    e.Handled = true;
                }
                if (e.Text == "-")
                {
                    e.Handled = true;
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        public BreedOfPet GetBreedByID(int roleId)
        {
            using (var dbContext = new PetShopYP5Entities1())
            {
                BreedOfPet role = dbContext.BreedOfPet.FirstOrDefault(r => r.ID_BreedOfPet == roleId);
                return role;
            }
        }

        public Shelter GetShelterByID(int roleId)
        {
            using (var dbContext = new PetShopYP5Entities1())
            {
                Shelter role = dbContext.Shelter.FirstOrDefault(r => r.ID_Shelter == roleId);
                return role;
            }
        }
        public NaimenovaniePetsa GetNaimByID(int roleId)
        {
            using (var dbContext = new PetShopYP5Entities1())
            {
                NaimenovaniePetsa role = dbContext.NaimenovaniePetsa.FirstOrDefault(r => r.ID_Naimenovanie == roleId);
                return role;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo1.SelectedItem != null && Combo2.SelectedItem
        != null && Combo3.SelectedItem != null)
            {
                    Pets cl = new Pets();
                    cl.PetName = ReadDannie.Text;
                    bool documents;
                    if (bool.TryParse(ReadDannie1.Text, out documents))
                    {
                        cl.Documents = documents;
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат данных для документов");
                        ClearInputs();
                        return; 
                    }
                    cl.Price = Convert.ToDecimal(ReadDannie2.Text);
                    if (Combo1.SelectedItem != null)
                    {
                        var selectedRole = (BreedOfPet)Combo1.SelectedItem;
                        cl.BreedOfPet_ID = selectedRole.ID_BreedOfPet;
                    }
                    if (Combo2.SelectedItem != null)
                    {
                        var selectedRole = (Shelter)Combo2.SelectedItem;
                        cl.Shelter_ID = selectedRole.ID_Shelter;
                    }
                    if (Combo3.SelectedItem != null)
                    {
                        var selectedRole = (NaimenovaniePetsa)Combo3.SelectedItem;
                        cl.Naimenovanie_ID = selectedRole.ID_Naimenovanie;
                    }
                    yp.Pets.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Pets.ToList();
                    ClearInputs();
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo1.SelectedItem != null && Combo2.SelectedItem
        != null && Combo3.SelectedItem != null)
            {
                if (TableSS.SelectedItem != null)
                {
                    var selected = TableSS.SelectedItem as Pets;
                    selected.PetName = ReadDannie.Text;
                    bool documents;
                    if (bool.TryParse(ReadDannie1.Text, out documents))
                    {
                        selected.Documents = documents;
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат данных для документов");
                        ClearInputs();
                        return;
                    }
                    selected.Price = Convert.ToDecimal(ReadDannie2.Text);
                    if (Combo1.SelectedItem != null)
                    {
                        var selectedRole = (BreedOfPet)Combo1.SelectedItem;
                        selected.BreedOfPet_ID = selectedRole.ID_BreedOfPet;
                    }
                    if (Combo2.SelectedItem != null)
                    {
                        var selectedRole = (Shelter)Combo2.SelectedItem;
                        selected.Shelter_ID = selectedRole.ID_Shelter;
                    }
                    if (Combo3.SelectedItem != null)
                    {
                        var selectedRole = (NaimenovaniePetsa)Combo3.SelectedItem;
                        selected.Naimenovanie_ID = selectedRole.ID_Naimenovanie;
                    }
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Pets.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
        private bool Deleted(Pets selectedFood)
        {
            if (yp.Orders.Any(entry => entry.Pets_ID == selectedFood.ID_Pets))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo1.SelectedItem != null && Combo2.SelectedItem
        != null && Combo3.SelectedItem != null)
            {
                if (!Deleted(TableSS.SelectedItem as Pets))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    Pets lpa = TableSS.SelectedItem as Pets;
                    yp.Pets.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Pets.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
    }
}
