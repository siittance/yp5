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
    /// Логика взаимодействия для StatusZakaza.xaml
    /// </summary>
    public partial class StatusZakaza : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public StatusZakaza()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Statuses.ToList();
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Statuses)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.NameOfStatus.ToString();
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
                if (yp.Statuses.Any(r => r.NameOfStatus == ReadDannie.Text))
                {
                    MessageBox.Show("Такое наименование уже есть");
                    ReadDannie.Text = null;
                }
                else
                {
                    Statuses cl = new Statuses();
                    cl.NameOfStatus = ReadDannie.Text;
                    yp.Statuses.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Statuses.ToList();
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
                    Statuses lp = TableSS.SelectedItem as Statuses;

                    if (yp.Statuses.Any(r => r.NameOfStatus == ReadDannie.Text))
                    {
                        MessageBox.Show("Такое наименование уже есть");
                        ReadDannie.Text = null;
                    }
                    else
                    {
                        var selected = TableSS.SelectedItem as Statuses;
                        selected.NameOfStatus = ReadDannie.Text;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Statuses.ToList();
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
        private bool Deleted(Statuses selectedFood)
        {
            if (yp.Orders.Any(entry => entry.Status_ID == selectedFood.ID_Statuses))
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
                if (!Deleted(TableSS.SelectedItem as Statuses))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    Statuses cl = TableSS.SelectedItem as Statuses;
                    yp.Statuses.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Statuses.ToList();
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
