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
    /// Логика взаимодействия для VtorayaRol.xaml
    /// </summary>
    public partial class VtorayaRol : Window
    {
        List<string> list = new List<string>() {"Услуги", "Корм для питомцев", "Игрушки для питомцев", "Питомцы" };
        public VtorayaRol()
        {
            InitializeComponent();
            tableComboBox.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void TableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tableComboBox.SelectedItem == list[0])
            {
                VtorayaRolYslugi vtorayaRol = new VtorayaRolYslugi();
                vtorayaRol.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[1])
            {
                VtorayaRoleKorm vtorayaRoleKorm = new VtorayaRoleKorm();
                vtorayaRoleKorm.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[2])
            {
                VtorayaRoleIgrushi vtorayaRoleIgrushi = new VtorayaRoleIgrushi();
                vtorayaRoleIgrushi.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[3])
            {
                Popitka2 vtoryayRolPitomci = new Popitka2();
                vtoryayRolPitomci.Show();
                Close();
            }
        }
    }
}
