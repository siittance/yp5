    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Pokupateli.xaml
    /// </summary>
    public partial class Pokupateli : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public Pokupateli()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Clients.ToList();
            Combo2.ItemsSource = yp.ClientCheck.ToList();
            Combo2.SelectedValuePath = "ID_ClientCheck";
            Combo2.DisplayMemberPath = "NameOfThecheck";
            var clientLogins = yp.LoginPassword.Where(login => login.Rolee_ID == 4).ToList();
            Combo3.ItemsSource = clientLogins;
            Combo3.SelectedValuePath = "ID_LoginPassword";
            Combo3.DisplayMemberPath = "Username";
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Clients)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.ClientSurname.ToString();
                ReadDannie1.Text = proverka.ClientName.ToString();
                ReadDannie2.Text = proverka.ClientMiddleName.ToString();
                ReadDannie3.Text = proverka.Email.ToString();
                ReadDannie4.Text = proverka.PhoneNumber.ToString();
                Combo2.SelectedValue = proverka.ClientCheck_ID.ToString();
                Combo3.SelectedValue = proverka.ID_LoginPassword.ToString();
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
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 25)
            {
                textBox.Text = textBox.Text.Substring(0, 25);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void ReadDannie2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 25)
            {
                textBox.Text = textBox.Text.Substring(0, 25);
                textBox.Select(textBox.Text.Length, 0);
            }
        }
        private bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            return false; 
        }
        private void ReadDannie3_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 100)
            {
                textBox.Text = textBox.Text.Substring(0, 100);
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        private void ReadDannie4_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Combo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReadDannie_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDannie1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDannie2_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDannie3_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }
        private void ClearInputs()
        {
            ReadDannie.Text = null;
            ReadDannie1.Text = null;
            ReadDannie2.Text = null;
            ReadDannie3.Text = null;
            ReadDannie4.Text = null;
            Combo2.SelectedValue = null;
            Combo3.SelectedValue = null;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
        !string.IsNullOrEmpty(ReadDannie2.Text) && !string.IsNullOrEmpty(ReadDannie3.Text) &&
        !string.IsNullOrEmpty(ReadDannie4.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                LoginPassword selectedLogin = Combo3.SelectedItem as LoginPassword;
                if (yp.Clients.Any(client => client.Email == ReadDannie3.Text))
                {
                    MessageBox.Show("Введите уникальную почту.");
                }
                else if (yp.Clients.Any(client => client.PhoneNumber == ReadDannie4.Text))
                {
                    MessageBox.Show("Введите уникальный номер.");
                }
                else if (yp.Clients.Any(client => client.ID_LoginPassword == selectedLogin.ID_LoginPassword))
                {
                    MessageBox.Show("Выберите другой логин, данный логин уже используется");
                }
                else
                {
                    Clients cl = new Clients();
                    cl.ClientSurname = ReadDannie.Text;
                    cl.ClientName = ReadDannie1.Text;
                    cl.ClientMiddleName = ReadDannie2.Text;
                    cl.Email = ReadDannie3.Text;
                    cl.PhoneNumber = ReadDannie4.Text;

                    if (Combo2.SelectedItem != null)
                    {
                        var selectedRole = (ClientCheck)Combo2.SelectedItem;
                        cl.ClientCheck_ID = selectedRole.ID_ClientCheck;
                    }

                    cl.ID_LoginPassword = selectedLogin.ID_LoginPassword;
                    yp.Clients.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Clients.ToList();
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
        !string.IsNullOrEmpty(ReadDannie2.Text) && !string.IsNullOrEmpty(ReadDannie3.Text) &&
        !string.IsNullOrEmpty(ReadDannie4.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                if (TableSS.SelectedItem != null)
                {
                    var selectedClient = TableSS.SelectedItem as Clients;
                    LoginPassword selectedLogin = Combo3.SelectedItem as LoginPassword;

                    bool isEmailUnique = !yp.Clients.Any(client => client.Email == ReadDannie3.Text && client.ID_Clients != selectedClient.ID_Clients);
                    bool isPhoneNumberUnique = !yp.Clients.Any(client => client.PhoneNumber == ReadDannie4.Text && client.ID_Clients != selectedClient.ID_Clients);

                    if (!isEmailUnique)
                    {
                        MessageBox.Show("Почта уже используется другим клиентом. Введите уникальную почту.");
                        return;
                    }

                    if (!isPhoneNumberUnique)
                    {
                        MessageBox.Show("Номер телефона уже используется другим клиентом. Введите уникальный номер.");
                        return;
                    }

                    if (selectedClient.ID_LoginPassword == selectedLogin.ID_LoginPassword ||
                        !yp.Clients.Any(client => client.ID_LoginPassword == selectedLogin.ID_LoginPassword))
                    {
                        selectedClient.ClientSurname = ReadDannie.Text;
                        selectedClient.ClientName = ReadDannie1.Text;
                        selectedClient.ClientMiddleName = ReadDannie2.Text;
                        selectedClient.Email = ReadDannie3.Text;
                        selectedClient.PhoneNumber = ReadDannie4.Text;

                        if (Combo2.SelectedItem != null)
                        {
                            var selectedRole = (ClientCheck)Combo2.SelectedItem;
                            selectedClient.ClientCheck_ID = selectedRole.ID_ClientCheck;
                        }

                        selectedClient.ID_LoginPassword = selectedLogin.ID_LoginPassword;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Clients.ToList();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Этот логин уже привязан к другому клиенту. Выберите другой логин.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
        }
        private bool Deleted(Clients selectedFood)
        {
            if (yp.Bill.Any(entry => entry.Client_ID == selectedFood.ID_Clients))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) &&
            !string.IsNullOrEmpty(ReadDannie2.Text) && !string.IsNullOrEmpty(ReadDannie3.Text) &&
            !string.IsNullOrEmpty(ReadDannie4.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                if (!Deleted(TableSS.SelectedItem as Clients))
                    return;

                if (TableSS.SelectedItem != null)
                {
                    Clients lpa = TableSS.SelectedItem as Clients;
                    yp.Clients.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Clients.ToList();
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
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void ReadDannie3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void ReadDannie4_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        
        private void ReadDannie4_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void ReadDannie3_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string email = textBox.Text;

            if (!IsEmailValid(email))
            {
                MessageBox.Show("Некорректный адрес электронной почты");
                textBox.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox.BorderBrush = Brushes.Black;
            }
        }
    }
}
