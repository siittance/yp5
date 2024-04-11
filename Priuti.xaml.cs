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
    /// Логика взаимодействия для Priuti.xaml
    /// </summary>
    public partial class Priuti : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public Priuti()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Shelter.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (yp.Shelter.Any(r => r.TownOfShelter == ReadDannie.Text))
                {
                    MessageBox.Show("Такой адрес уже есть");
                    ReadDannie.Text = null;
                }
                else
                {
                    Shelter cl = new Shelter();
                    cl.TownOfShelter = ReadDannie.Text;
                    yp.Shelter.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Shelter.ToList();
                    ReadDannie.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (TableSS.SelectedItem != null)
                {
                    Shelter lp = TableSS.SelectedItem as Shelter;

                    if (yp.Shelter.Any(r => r.TownOfShelter == ReadDannie.Text))
                    {
                        MessageBox.Show("Такое наименование уже есть");
                        ReadDannie.Text = null;
                    }
                    else
                    {
                        var selected = TableSS.SelectedItem as Shelter;
                        selected.TownOfShelter = ReadDannie.Text;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Shelter.ToList();
                        ReadDannie.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите элемент для редактирования");
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
        private bool Deleted(Shelter selectedFood)
        {
            if (yp.Pets.Any(entry => entry.Shelter_ID == selectedFood.ID_Shelter))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (!Deleted(TableSS.SelectedItem as Shelter))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    Shelter cl = TableSS.SelectedItem as Shelter;
                    yp.Shelter.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Shelter.ToList();
                    ReadDannie.Text = null;

                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void ReadDannie_TextChanged(object sender, TextChangedEventArgs e)
        {
                TextBox textBox = (TextBox)sender;

                if (textBox.Text.Length > 40)
                {
                    textBox.Text = textBox.Text.Substring(0, 40);
                    textBox.Select(textBox.Text.Length, 0);
                }
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

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Shelter)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.TownOfShelter.ToString();
            }
        }
    }
}
