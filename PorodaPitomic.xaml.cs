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
    /// Логика взаимодействия для PorodaPitomic.xaml
    /// </summary>
    public partial class PorodaPitomic : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public PorodaPitomic()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.BreedOfPet.ToList();
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (BreedOfPet)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.NameOfBreed.ToString();
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
                if (yp.BreedOfPet.Any(r => r.NameOfBreed == ReadDannie.Text))
                {
                    MessageBox.Show("Такое наименование уже есть");
                    ReadDannie.Text = null;
                }
                else
                {
                    BreedOfPet cl = new BreedOfPet();
                    cl.NameOfBreed = ReadDannie.Text;
                    yp.BreedOfPet.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.BreedOfPet.ToList();
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
                    BreedOfPet lp = TableSS.SelectedItem as BreedOfPet;

                    if (yp.BreedOfPet.Any(r => r.NameOfBreed == ReadDannie.Text))
                    {
                        MessageBox.Show("Такое наименование уже есть");
                        ReadDannie.Text = null;
                    }
                    else
                    {
                        var selected = TableSS.SelectedItem as BreedOfPet;
                        selected.NameOfBreed = ReadDannie.Text;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.BreedOfPet.ToList();
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
        private bool Deleted(BreedOfPet selectedFood)
        {
            if (yp.Pets.Any(entry => entry.BreedOfPet_ID == selectedFood.ID_BreedOfPet))
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
                if (!Deleted(TableSS.SelectedItem as BreedOfPet))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    BreedOfPet cl = TableSS.SelectedItem as BreedOfPet;
                    yp.BreedOfPet.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.BreedOfPet.ToList();
                    ReadDannie.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
    }
}
