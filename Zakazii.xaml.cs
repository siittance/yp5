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
    /// Логика взаимодействия для Zakazii.xaml
    /// </summary>
    public partial class Zakazii : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();    
        public Zakazii()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Orders.ToList();
            Combo2.ItemsSource = yp.Pets.ToList();
            Combo2.SelectedValuePath = "ID_Pets";
            Combo2.DisplayMemberPath = "PetName";
            Combo3.ItemsSource = yp.Employees.ToList();
            Combo3.SelectedValuePath = "ID_Employees";
            Combo3.DisplayMemberPath = "EmploSurname";
            Combo4.ItemsSource = yp.Toys.ToList();
            Combo4.SelectedValuePath = "ID_Toys";
            Combo4.DisplayMemberPath = "NameOfTheToys";
            Combo5.ItemsSource = yp.Statuses.ToList();
            Combo5.SelectedValuePath = "ID_Statuses";
            Combo5.DisplayMemberPath = "NameOfStatus";
            Combo6.ItemsSource = yp.Bill.ToList();
            Combo6.SelectedValuePath = "ID_Bill";
            Combo6.DisplayMemberPath = "OrderNumber";
            Combo7.ItemsSource = yp.FoodForPets.ToList();
            Combo7.SelectedValuePath = "ID_FoodForPets";
            Combo7.DisplayMemberPath = "NameOfFood";
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Orders)TableSS.SelectedItem;
            if (proverka != null)
            {
                Combo1.SelectedDate = proverka.OrderDate;
                Combo2.SelectedValue = proverka.Pets_ID.ToString();
                Combo3.SelectedValue = proverka.Employees_ID.ToString();
                Combo4.SelectedValue = proverka.Toys_ID.ToString();
                Combo5.SelectedValue = proverka.Status_ID.ToString();
                Combo6.SelectedValue = proverka.Bill_ID.ToString();
                Combo7.SelectedValue = proverka.FoodForPets_ID.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }
        private void ClearInputs()
        {
            Combo1.Text = null;
            Combo2.SelectedValue = null;
            Combo3.SelectedValue = null;
            Combo4.SelectedValue = null;
            Combo5.SelectedValue = null;
            Combo6.SelectedValue = null;
            Combo7.SelectedValue = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Combo1.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null && Combo3.SelectedItem != null
                && Combo4.SelectedItem != null && Combo5.SelectedItem != null
                && Combo6.SelectedItem != null && Combo7.SelectedItem != null)
            {
                    Orders cl = new Orders();
                    cl.OrderDate = DateTime.Parse(Combo1.Text);

                    if (Combo2.SelectedItem != null)
                    {
                        var selectedRole = (Pets)Combo2.SelectedItem;
                        cl.Pets_ID = selectedRole.ID_Pets;
                    }
                    if (Combo3.SelectedItem != null)
                    {
                        var selectedRole = (Employees)Combo3.SelectedItem;
                        cl.Employees_ID = selectedRole.ID_Employees;
                    }
                    if (Combo4.SelectedItem != null)
                    {
                        var selectedRole = (Toys)Combo4.SelectedItem;
                        cl.Toys_ID = selectedRole.ID_Toys;
                    }
                    if (Combo5.SelectedItem != null)
                    {
                        var selectedRole = (Statuses)Combo5.SelectedItem;
                        cl.Status_ID = selectedRole.ID_Statuses;
                    }
                    if (Combo6.SelectedItem != null)
                    {
                        var selectedRole = (Bill)Combo6.SelectedItem;
                        cl.Bill_ID = selectedRole.ID_Bill;
                    }
                    if (Combo7.SelectedItem != null)
                    {
                        var selectedRole = (FoodForPets)Combo7.SelectedItem;
                        cl.FoodForPets_ID = selectedRole.ID_FoodForPets;
                    }
                    yp.Orders.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Orders.ToList();
                    ClearInputs();
            }
            else
            {
                MessageBox.Show("Нельзя оставлять пустые поля");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Combo1.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null && Combo3.SelectedItem != null
                && Combo4.SelectedItem != null && Combo5.SelectedItem != null
                && Combo6.SelectedItem != null && Combo7.SelectedItem != null)
            {
                var selected = TableSS.SelectedItem as Orders;
                selected.OrderDate = DateTime.Parse(Combo1.Text);

                if (Combo2.SelectedItem != null)
                {
                    var selectedRole = (Pets)Combo2.SelectedItem;
                    selected.Pets_ID = selectedRole.ID_Pets;
                }
                if (Combo3.SelectedItem != null)
                {
                    var selectedRole = (Employees)Combo3.SelectedItem;
                    selected.Employees_ID = selectedRole.ID_Employees;
                }
                if (Combo4.SelectedItem != null)
                {
                    var selectedRole = (Toys)Combo4.SelectedItem;
                    selected.Toys_ID = selectedRole.ID_Toys;
                }
                if (Combo5.SelectedItem != null)
                {
                    var selectedRole = (Statuses)Combo5.SelectedItem;
                    selected.Status_ID = selectedRole.ID_Statuses;
                }
                if (Combo6.SelectedItem != null)
                {
                    var selectedRole = (Bill)Combo6.SelectedItem;
                    selected.Bill_ID = selectedRole.ID_Bill;
                }
                if (Combo7.SelectedItem != null)
                {
                    var selectedRole = (FoodForPets)Combo7.SelectedItem;
                    selected.FoodForPets_ID = selectedRole.ID_FoodForPets;
                }
                yp.SaveChanges();
                TableSS.ItemsSource = yp.Orders.ToList();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Нельзя оставлять пустые поля");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Combo1.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null && Combo3.SelectedItem != null
                && Combo4.SelectedItem != null && Combo5.SelectedItem != null
                && Combo6.SelectedItem != null && Combo7.SelectedItem != null)
            {
                if (TableSS.SelectedItem != null)
                {
                    Orders lpa = TableSS.SelectedItem as Orders;
                    yp.Orders.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Orders.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Нельзя оставлять пустые поля");
            }
        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReadDannie2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
