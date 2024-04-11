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
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public Sotrudniki()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Employees.ToList();
            Combo2.ItemsSource = yp.ServicesForPet.ToList();
            Combo2.SelectedValuePath = "ID_ServicesForPet";
            Combo2.DisplayMemberPath = "NameOfServices";
            var Logins = yp.LoginPassword.Where(login => login.Rolee_ID == 2).ToList();
            Combo3.ItemsSource = Logins;
            Combo3.SelectedValuePath = "ID_LoginPassword";
            Combo3.DisplayMemberPath = "Username";
        }
        private void ClearInputs()
        {
            ReadDannie.Text = null;
            ReadDannie1.Text = null;
            ReadDannie2.Text = null;
            Combo2.SelectedValue = null;
            Combo3.SelectedValue = null;
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Employees)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.EmploSurname.ToString();
                ReadDannie1.Text = proverka.EmploName.ToString();
                ReadDannie2.Text = proverka.PhoneNumber.ToString();
                Combo2.SelectedValue = proverka.ServicesForPet_ID.ToString();
                Combo3.SelectedValue = proverka.ID_LoginPassword.ToString();
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
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                LoginPassword selectedLogin = Combo3.SelectedItem as LoginPassword;
                if (yp.Employees.Any(client => client.PhoneNumber == ReadDannie2.Text))
                {
                    MessageBox.Show("Введите уникальный номер.");
                }
                else if (yp.Employees.Any(client => client.ID_LoginPassword == selectedLogin.ID_LoginPassword))
                {
                    MessageBox.Show("Выберите другой логин, данный логин уже используется");
                }
                else
                {
                    Employees cl = new Employees();
                    cl.EmploSurname = ReadDannie.Text;
                    cl.EmploName = ReadDannie1.Text;
                    cl.PhoneNumber = ReadDannie2.Text;
                    if (Combo2.SelectedItem != null)
                    {
                        var selectedRole = (ServicesForPet)Combo2.SelectedItem;
                        cl.ServicesForPet_ID = selectedRole.ID_ServicesForPet;
                    }
                    cl.ID_LoginPassword = selectedLogin.ID_LoginPassword;
                    yp.Employees.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Employees.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                if (TableSS.SelectedItem != null)
                {
                    var selectedClient = TableSS.SelectedItem as Employees;
                    LoginPassword selectedLogin = Combo3.SelectedItem as LoginPassword;

                    bool isPhoneNumberUnique = !yp.Employees.Any(client => client.PhoneNumber == ReadDannie2.Text && client.ID_Employees != selectedClient.ID_Employees);

                    if (!isPhoneNumberUnique)
                    {
                        MessageBox.Show("Номер телефона уже используется другим клиентом. Введите уникальный номер.");
                        return;
                    }

                    if (selectedClient.ID_LoginPassword == selectedLogin.ID_LoginPassword ||
                        !yp.Employees.Any(client => client.ID_LoginPassword == selectedLogin.ID_LoginPassword))
                    {
                        selectedClient.EmploSurname = ReadDannie.Text;
                        selectedClient.EmploName = ReadDannie1.Text;
                        selectedClient.PhoneNumber = ReadDannie2.Text;

                        if (Combo2.SelectedItem != null)
                        {
                            var selectedRole = (ServicesForPet)Combo2.SelectedItem;
                            selectedClient.ServicesForPet_ID = selectedRole.ID_ServicesForPet;
                        }
                        selectedClient.ID_LoginPassword = selectedLogin.ID_LoginPassword;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Employees.ToList();
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
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
        }
        private bool Deleted(Employees selectedFood)
        {
            if (yp.Orders.Any(entry => entry.Employees_ID == selectedFood.ID_Employees))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                if (!Deleted(TableSS.SelectedItem as Employees))
                    return;

                if (TableSS.SelectedItem != null)
                {
                    Employees lpa = TableSS.SelectedItem as Employees;
                    yp.Employees.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Employees.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
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

        private void ReadDannie_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 25)
            {
                textBox.Text = textBox.Text.Substring(0, 25);
                textBox.Select(textBox.Text.Length, 0);
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
    }
}
