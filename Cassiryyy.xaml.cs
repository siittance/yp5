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
    /// Логика взаимодействия для Cassiryyy.xaml
    /// </summary>
    public partial class Cassiryyy : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public Cassiryyy()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Cashiers.ToList();
            var Logins = yp.LoginPassword.Where(login => login.Rolee_ID == 3).ToList();
            Combo2.ItemsSource = Logins;
            Combo2.SelectedValuePath = "ID_LoginPassword";
            Combo2.DisplayMemberPath = "Username";
        }
        private void ClearInputs()
        {
            ReadDannie.Text = null;
            ReadDannie1.Text = null;
            ReadDannie2.Text = null;
            Combo2.SelectedValue = null;
        }
        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Cashiers)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.CashSurname.ToString();
                ReadDannie1.Text = proverka.CashName.ToString();
                ReadDannie2.Text = proverka.PhoneNumber.ToString();
                Combo2.SelectedValue = proverka.ID_LoginPassword.ToString();
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
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
       !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null)
            {
                LoginPassword selectedLogin = Combo2.SelectedItem as LoginPassword;
                if (yp.Cashiers.Any(client => client.PhoneNumber == ReadDannie2.Text))
                {
                    MessageBox.Show("Введите уникальный номер");
                }
                else if (yp.Cashiers.Any(client => client.ID_LoginPassword == selectedLogin.ID_LoginPassword))
                {
                    MessageBox.Show("Выберите другой логин, данный привязан");
                }
                else
                {
                    Cashiers cl = new Cashiers();
                    cl.CashSurname = ReadDannie.Text;
                    cl.CashName = ReadDannie1.Text;
                    cl.PhoneNumber = ReadDannie2.Text;
                    cl.ID_LoginPassword = selectedLogin.ID_LoginPassword;
                    yp.Cashiers.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Cashiers.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null)
            {
                if (TableSS.SelectedItem != null)
                {
                    var selectedClient = TableSS.SelectedItem as Cashiers;
                    LoginPassword selectedLogin = Combo2.SelectedItem as LoginPassword;

                    bool isPhoneNumberUnique = !yp.Cashiers.Any(client => client.PhoneNumber == ReadDannie2.Text && client.ID_Cahiers != selectedClient.ID_Cahiers);

                    if (!isPhoneNumberUnique)
                    {
                        MessageBox.Show("Номер телефона уже используется другим клиентом. Введите уникальный номер.");
                        return;
                    }

                    if (selectedClient.ID_LoginPassword == selectedLogin.ID_LoginPassword ||
                        !yp.Cashiers.Any(client => client.ID_LoginPassword == selectedLogin.ID_LoginPassword))
                    {
                        selectedClient.CashSurname = ReadDannie.Text;
                        selectedClient.CashName = ReadDannie1.Text;
                        selectedClient.PhoneNumber = ReadDannie2.Text;
                        selectedClient.ID_LoginPassword = selectedLogin.ID_LoginPassword;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Cashiers.ToList();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Выберите другой логин, данный логин уже используется");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
        private bool Deleted(Cashiers selectedFood)
        {
            if (yp.Bill.Any(entry => entry.Cashiers_ID == selectedFood.ID_Cahiers))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
       !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null)
            {
                if (!Deleted(TableSS.SelectedItem as Cashiers))
                    return;

                if (TableSS.SelectedItem != null)
                {
                    Cashiers lpa = TableSS.SelectedItem as Cashiers;
                    yp.Cashiers.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Cashiers.ToList();
                    ClearInputs();
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

        private void ReadDannie_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 25)
            {
                textBox.Text = textBox.Text.Substring(0, 25);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void ReadDannie1_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void ReadDannie1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDannie1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 25)
            {
                textBox.Text = textBox.Text.Substring(0, 25);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void ReadDannie2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;

            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }

            if (newText.Length > 11)
            {
                e.Handled = true;
            }

            if (newText.Length == 1 && !(newText.StartsWith("7") || newText.StartsWith("8")))
            {
                e.Handled = true;
            }
        }

        private void ReadDannie2_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDannie2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 11)
            {
                textBox.Text = textBox.Text.Substring(0, 11);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
