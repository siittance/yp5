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
    /// Логика взаимодействия для IgrushkaPets.xaml
    /// </summary>
    public partial class IgrushkaPets : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public IgrushkaPets()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Toys.ToList();
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Toys)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.NameOfTheToys.ToString();
                ReadDannie1.Text = proverka.Price.ToString();
            }
        }

        private void ReadDannie_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 30)
            {
                textBox.Text = textBox.Text.Substring(0, 30);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void ReadDannie1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //decimal не требует проверки на символы
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ReadDannie.Text) && !string.IsNullOrWhiteSpace(ReadDannie1.Text))
            {
                decimal price;

                if (decimal.TryParse(ReadDannie1.Text, out price))
                {
                    if (yp.Toys.Any(r => r.NameOfTheToys == ReadDannie.Text))
                    {
                        MessageBox.Show("Такая игрушка уже есть");
                        ReadDannie.Text = null;
                        ReadDannie1.Text = null;
                    }
                    else
                    {
                        Toys cl = new Toys();
                        cl.NameOfTheToys = ReadDannie.Text;
                        cl.Price = price;
                        yp.Toys.Add(cl);
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Toys.ToList();
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
                    Toys lp = TableSS.SelectedItem as Toys;

                    if (yp.Toys.Any(r => r.NameOfTheToys == ReadDannie.Text && r.Price != lp.Price))
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
                                var selected = TableSS.SelectedItem as Toys;
                                selected.NameOfTheToys = ReadDannie.Text;
                                selected.Price = price;
                                yp.SaveChanges();
                                TableSS.ItemsSource = yp.Toys.ToList();
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
        private bool Deleted(Toys selectedFood)
        {
            if (yp.Orders.Any(entry => entry.Toys_ID == selectedFood.ID_Toys))
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
                if (!Deleted(TableSS.SelectedItem as Toys))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    Toys cl = TableSS.SelectedItem as Toys;
                    yp.Toys.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Toys.ToList();
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
