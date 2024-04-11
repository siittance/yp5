using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YP5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vxod = yp.LoginPassword.ToList();
            bool avtoriz = false;
            foreach (var v in vxod)
            {
                avtoriz = true;
                if (v.Username == LoginText.Text && v.Passwordd == PasswordText.Password && v.Rolee_ID == 1)
                {
                    Admin a = new Admin();
                    a.Show();
                    Close();
                }
                else if (v.Username == LoginText.Text && v.Passwordd == PasswordText.Password && v.Rolee_ID == 4)
                {
                    VtorayaRol vtorayaRol = new VtorayaRol();
                    vtorayaRol.Show();
                    Close();
                }
            }
            if (!avtoriz)
            {
                MessageBox.Show("Такого логина/пароля нет. Try again!)");
                LoginText.Text = null;
                PasswordText.Password = null;
            }
        }
    }
}
