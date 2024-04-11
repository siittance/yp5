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
    /// Логика взаимодействия для Roleeeee.xaml
    /// </summary>
    public partial class Roleeeee : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public Roleeeee()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Rolee.ToList ();
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
                if (yp.Rolee.Any(r => r.NameOfRole == ReadDannie.Text))
                {
                    MessageBox.Show("Такое наименование уже есть");
                    ReadDannie.Text = null;
                }
                else
                {
                    Rolee cl = new Rolee();
                    cl.NameOfRole = ReadDannie.Text;
                    yp.Rolee.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Rolee.ToList();
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
                    Rolee lp = TableSS.SelectedItem as Rolee;

                    if (yp.Rolee.Any(r => r.NameOfRole == ReadDannie.Text))
                    {
                        MessageBox.Show("Такое наименование уже есть");
                        ReadDannie.Text = null;
                    }
                    else
                    {
                        var selected = TableSS.SelectedItem as Rolee;
                        selected.NameOfRole = ReadDannie.Text;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Rolee.ToList();
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
        private bool Deleted(Rolee selectedFood)
        {
            if (yp.LoginPassword.Any(entry => entry.Rolee_ID == selectedFood.ID_Role))
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
                if (!Deleted(TableSS.SelectedItem as Rolee))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    Rolee cl = TableSS.SelectedItem as Rolee;
                    yp.Rolee.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Rolee.ToList();
                    ReadDannie.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Rolee)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.NameOfRole.ToString();
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

        private void ReadDannie_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 15)
            {
                textBox.Text = textBox.Text.Substring(0, 15);
                textBox.Select(textBox.Text.Length, 0);
            }
        }
    }
}
