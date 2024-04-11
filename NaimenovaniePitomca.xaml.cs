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
    /// Логика взаимодействия для NaimenovaniePitomca.xaml
    /// </summary>
    public partial class NaimenovaniePitomca : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public NaimenovaniePitomca()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.NaimenovaniePetsa.ToList();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin adm = new Admin();
            adm.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (yp.NaimenovaniePetsa.Any(r => r.Naimenovanie == ReadDannie.Text))
                {
                    MessageBox.Show("Такое наименование уже есть");
                    ReadDannie.Text = null;
                }
                else
                {
                    NaimenovaniePetsa cl = new NaimenovaniePetsa();
                    cl.Naimenovanie = ReadDannie.Text;
                    yp.NaimenovaniePetsa.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.NaimenovaniePetsa.ToList();
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
                    NaimenovaniePetsa lp = TableSS.SelectedItem as NaimenovaniePetsa;

                    if (yp.NaimenovaniePetsa.Any(r => r.Naimenovanie == ReadDannie.Text))
                    {
                        MessageBox.Show("Такое наименование уже есть");
                        ReadDannie.Text = null;
                    }
                    else
                    {
                        var selected = TableSS.SelectedItem as NaimenovaniePetsa;
                        selected.Naimenovanie = ReadDannie.Text;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.NaimenovaniePetsa.ToList();
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
        private bool Deleted(NaimenovaniePetsa selectedFood)
        {
            if (yp.Pets.Any(entry => entry.Naimenovanie_ID == selectedFood.ID_Naimenovanie))
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
                if (!Deleted(TableSS.SelectedItem as NaimenovaniePetsa))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    NaimenovaniePetsa cl = TableSS.SelectedItem as NaimenovaniePetsa;
                    yp.NaimenovaniePetsa.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.NaimenovaniePetsa.ToList();
                    ReadDannie.Text = null;

                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
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
            var proverka = (NaimenovaniePetsa)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.Naimenovanie.ToString();
            }
        }
    }
}
