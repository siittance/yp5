using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YP5
{
    /// <summary>
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        public Avtorization()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.LoginPassword.ToList();
            ReadDannie2.ItemsSource = yp.Rolee.ToList();
            ReadDannie2.SelectedValuePath = "ID_Role";
            ReadDannie2.DisplayMemberPath = "NameOfRole";
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

        private void ReadDannie_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //символы могут быть все ок
        }

        private void ReadDannie1_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
            //символы могут быть все ок
        }
        public Rolee GetRoleByID(int roleId)
        {
            using (var dbContext = new PetShopYP5Entities1()) 
            {
                Rolee role = dbContext.Rolee.FirstOrDefault(r => r.ID_Role == roleId);
                return role;
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
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) && ReadDannie2.SelectedItem != null)
            {
                if (yp.LoginPassword.Any(r => r.Username == ReadDannie.Text))
                {
                    MessageBox.Show("Такой логин уже есть");
                    ReadDannie1.Text = null;
                    ReadDannie.Text = null;
                    ReadDannie2.Text = null;
                }
                else
                {
                    LoginPassword cl = new LoginPassword();
                    cl.Username = ReadDannie.Text;
                    cl.Passwordd = ReadDannie1.Text;
                    if (ReadDannie2.SelectedItem != null)
                    {
                        var selectedRole = (Rolee)ReadDannie2.SelectedItem;
                        cl.Rolee_ID = selectedRole.ID_Role;
                    }
                    yp.LoginPassword.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.LoginPassword.ToList();
                    ReadDannie1.Text = null;
                    ReadDannie.Text = null;
                    ReadDannie2.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) && ReadDannie2.SelectedItem != null)
            {
                LoginPassword lp = TableSS.SelectedItem as LoginPassword;
                if (yp.LoginPassword.Any(r => r.Username == ReadDannie.Text && r.Rolee_ID != lp.Rolee_ID))
                {
                    MessageBox.Show("Такой логин уже есть");
                    ReadDannie1.Text = null;
                    ReadDannie.Text = null;
                    ReadDannie2.Text = null;
                }
                else if (TableSS.SelectedItem != null)
                    {
                    var selected = TableSS.SelectedItem as LoginPassword;
                    selected.Passwordd = ReadDannie1.Text;
                    if (ReadDannie2.SelectedItem != null)
                    {
                        var selectedRole = (Rolee)ReadDannie2.SelectedItem;
                        selected.Rolee_ID = selectedRole.ID_Role;
                    }
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.LoginPassword.ToList();
                    ReadDannie1.Text = null;
                    ReadDannie.Text = null;
                    ReadDannie2.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }
        private bool Deleted(LoginPassword selectedFood)
        {
            if (yp.Clients.Any(entry => entry.ID_LoginPassword == selectedFood.ID_LoginPassword) ||
                yp.Employees.Any(entry => entry.ID_LoginPassword == selectedFood.ID_LoginPassword) ||
                yp.Cashiers.Any(entry => entry.ID_LoginPassword == selectedFood.ID_LoginPassword))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie.Text) && !string.IsNullOrEmpty(ReadDannie1.Text) && ReadDannie2.SelectedItem != null)
            {
                if (!Deleted(TableSS.SelectedItem as LoginPassword))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    LoginPassword lpa = TableSS.SelectedItem as LoginPassword;
                    yp.LoginPassword.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.LoginPassword.ToList();
                    ReadDannie1.Text = null;
                    ReadDannie.Text = null;
                    ReadDannie2.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (LoginPassword)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.Username.ToString();
                ReadDannie1.Text = proverka.Passwordd.ToString();
                ReadDannie2.SelectedValue = proverka.Rolee_ID;
            }
        }
    }
}
