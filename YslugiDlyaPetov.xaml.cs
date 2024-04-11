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
    /// Логика взаимодействия для YslugiDlyaPetov.xaml
    /// </summary>
    public partial class YslugiDlyaPetov : Window
    {
       PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public YslugiDlyaPetov()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.ServicesForPet.ToList ();
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (ServicesForPet)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.NameOfServices.ToString();
                ReadDannie1.Text = proverka.Price.ToString();
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
        private void ReadDannie1_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
            Admin adm = new Admin ();
            adm.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ReadDannie.Text) && !string.IsNullOrWhiteSpace(ReadDannie1.Text))
            {
                decimal price;

                if (decimal.TryParse(ReadDannie1.Text, out price))
                {
                    if (yp.ServicesForPet.Any(r => r.NameOfServices == ReadDannie.Text))
                    {
                        MessageBox.Show("Такая еда уже есть");
                        ReadDannie.Text = null;
                        ReadDannie1.Text = null;
                    }
                    else
                    {
                        ServicesForPet cl = new ServicesForPet();
                        cl.NameOfServices = ReadDannie.Text;
                        cl.Price = price;
                        yp.ServicesForPet.Add(cl);
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.ServicesForPet.ToList();
                        ReadDannie.Text = null;
                        ReadDannie1.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Цена введена в некорректном формате");
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ReadDannie.Text) && !string.IsNullOrWhiteSpace(ReadDannie1.Text))
            {
                if (TableSS.SelectedItem != null)
                {
                    ServicesForPet lp = TableSS.SelectedItem as ServicesForPet;

                    if (yp.ServicesForPet.Any(r => r.NameOfServices == ReadDannie.Text && r.Price != lp.Price))
                    {
                        MessageBox.Show("Такая еда уже есть");
                        ReadDannie.Text = null;
                        ReadDannie1.Text = null;
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(ReadDannie.Text) && !string.IsNullOrWhiteSpace(ReadDannie1.Text))
                        {
                            if (decimal.TryParse(ReadDannie1.Text, out decimal price))
                            {
                                var selected = TableSS.SelectedItem as ServicesForPet;
                                selected.NameOfServices = ReadDannie.Text;
                                selected.Price = price;
                                yp.SaveChanges();
                                TableSS.ItemsSource = yp.ServicesForPet.ToList();
                                ReadDannie.Text = null;
                                ReadDannie1.Text = null;
                            }
                            else
                            {
                                MessageBox.Show("Цена введена в некорректном формате");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Поля Название еды и Цена не могут быть пустыми");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран элемент для редактирования");
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private bool Deleted(ServicesForPet selectedFood)
        {
            if (yp.Employees.Any(entry => entry.ServicesForPet_ID == selectedFood.ID_ServicesForPet))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ReadDannie.Text) && !string.IsNullOrWhiteSpace(ReadDannie1.Text))
            {
                if (!Deleted(TableSS.SelectedItem as ServicesForPet))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    ServicesForPet cl = TableSS.SelectedItem as ServicesForPet;
                    yp.ServicesForPet.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.ServicesForPet.ToList();
                    ReadDannie.Text = null;
                    ReadDannie1.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
    }
}
