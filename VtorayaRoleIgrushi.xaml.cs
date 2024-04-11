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
    /// Логика взаимодействия для VtorayaRoleIgrushi.xaml
    /// </summary>
    public partial class VtorayaRoleIgrushi : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public VtorayaRoleIgrushi()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Toys.ToList ();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VtorayaRol vtorayaRol = new VtorayaRol();
            vtorayaRol.Show();
            Close();
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
