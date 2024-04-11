using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Chekiiiii.xaml
    /// ААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА
    /// АААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА
    /// ОСТАЛАСЬ ОДНА АААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА
    /// </summary>
    public partial class Chekiiiii : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public Chekiiiii()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.Bill.ToList();
            Combo2.ItemsSource = yp.Cashiers.ToList();
            Combo2.SelectedValuePath = "ID_Cahiers";
            Combo2.DisplayMemberPath = "CashSurname";
            Combo3.ItemsSource = yp.Clients.ToList();
            Combo3.SelectedValuePath = "ID_Clients";
            Combo3.DisplayMemberPath = "Email";
        }
        private void ClearInputs()
        {
            ReadDannie1.Text = null;
            ReadDannie2.Text = null;
            Combo2.SelectedValue = null;
            Combo3.SelectedValue = null;
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (Bill)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie1.Text = proverka.OrderNumber.ToString();
                ReadDannie2.SelectedDate = proverka.DateOrder;
                Combo2.SelectedValue = proverka.Cashiers_ID.ToString();
                Combo3.SelectedValue = proverka.Client_ID.ToString();
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
            if (!string.IsNullOrEmpty(ReadDannie1.Text) && !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null && Combo3.SelectedItem != null)
            {
                if (yp.Bill.Any(bill => bill.OrderNumber.ToString() == ReadDannie1.Text))
                {
                    MessageBox.Show("Номер заказа должен быть уникальным");
                }
                else
                {
                    Bill cl = new Bill();
                    if (int.TryParse(ReadDannie1.Text, out int orderNumber))
                    {
                        cl.OrderNumber = orderNumber;
                        cl.DateOrder = DateTime.Parse(ReadDannie2.Text);
                        if (Combo2.SelectedItem != null)
                        {
                            var selectedCashier = (Cashiers)Combo2.SelectedItem;
                            cl.Cashiers_ID = selectedCashier.ID_Cahiers;
                        }
                        if (Combo3.SelectedItem != null)
                        {
                            var selectedCashier = (Clients)Combo3.SelectedItem;
                            cl.Client_ID = selectedCashier.ID_Clients;
                        }
                        yp.Bill.Add(cl);
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.Bill.ToList();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Номер заказа введен неправильно");
                    }
                }
            }
            else
            {
                MessageBox.Show("Нельзя оставлять пустые места");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie1.Text) && !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null)
            {
                if (TableSS.SelectedItem != null)
                {
                    var selectedBill = TableSS.SelectedItem as Bill;
                    if (!string.IsNullOrEmpty(ReadDannie1.Text) && !int.TryParse(ReadDannie1.Text, out _))
                    {
                        MessageBox.Show("Номер заказа введен неправильно");
                        return;
                    }

                    if (!string.IsNullOrEmpty(ReadDannie1.Text))
                    {
                        int orderNumber = int.Parse(ReadDannie1.Text);
                        if (yp.Bill.Any(bill => bill.OrderNumber == orderNumber && bill.ID_Bill != selectedBill.ID_Bill))
                        {
                            MessageBox.Show("Номер заказа должен быть уникальным");
                            return;
                        }

                        selectedBill.OrderNumber = orderNumber;
                    }

                    selectedBill.DateOrder = DateTime.Parse(ReadDannie2.Text);

                    if (Combo2.SelectedItem != null)
                    {
                        var selectedCashier = (Cashiers)Combo2.SelectedItem;
                        selectedBill.Cashiers_ID = selectedCashier.ID_Cahiers;
                    }

                    if (Combo3.SelectedItem != null)
                    {
                        var selectedClient = (Clients)Combo3.SelectedItem;
                        selectedBill.Client_ID = selectedClient.ID_Clients;
                    }

                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Bill.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Нельзя оставлять пустые места");
            }
        }
        private bool Deleted(Bill selectedFood)
        {
            if (yp.Orders.Any(entry => entry.Bill_ID == selectedFood.ID_Bill))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReadDannie1.Text) && !string.IsNullOrEmpty(ReadDannie2.Text) && Combo2.SelectedItem != null)
            {
                if (!Deleted(TableSS.SelectedItem as Bill))
                    return;

                if (TableSS.SelectedItem != null)
                {
                    Bill lpa = TableSS.SelectedItem as Bill;
                    yp.Bill.Remove(lpa);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.Bill.ToList();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void ReadDannie1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 3)
            {
                textBox.Text = textBox.Text.Substring(0, 3); 
            }
            else if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Нужен хотя бы 1 символ");
            }
        }

        private void ReadDannie1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ReadDannie1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!Char.IsDigit(ch))
                {
                    e.Handled = true; 
                    break;
                }
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\Administrator\Desktop\FormatCheka.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (var dbContext = new PetShopYP5Entities1())
                {
                    var data = dbContext.Bill.ToList();

                    foreach (var item in data)
                    {
                        writer.WriteLine($"ID: {item.ID_Bill}, Номер заказа: {item.OrderNumber}, Дата формирования: {item.DateOrder}, ID клиента: {item.Client_ID}, ID кассира: {item.Cashiers_ID}");
                    }
                }
            }

            MessageBox.Show("Данные успешно экспортированы в TXT файл.");
        }
    }
}
