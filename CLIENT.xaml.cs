using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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
using System.Runtime.Remoting.Contexts;

namespace YP5
{
    /// <summary>
    /// Логика взаимодействия для CLIENT.xaml
    /// </summary>
    public partial class CLIENT : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1();
        private List<FoodForPets> selectedProducts = new List<FoodForPets>();
        List<FoodForPets> receiptProducts = new List<FoodForPets>();
        public CLIENT()
        {
            InitializeComponent();
            datagrid1.ItemsSource = yp.FoodForPets.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedProduct in selectedProducts)
            {
                receiptProducts.Add(selectedProduct);
            }

            CalculateTotalAmountAndShowReceipt();
        }
        private void CalculateTotalAmountAndShowReceipt()
        {
            decimal totalAmount = selectedProducts.Sum(p => p.Price);

            datagridITOG.ItemsSource = selectedProducts;
            cena.Text = $"Общая сумма: {totalAmount}";
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid1 != null)
            {
                DataGrid dataGrid = sender as DataGrid;
                FoodForPets selectedProduct = dataGrid.SelectedItem as FoodForPets;

                if (selectedProduct != null)
                {
                    selectedProducts.Add(selectedProduct);
                }
            }
        }
        private void ExportReceiptToFile(List<FoodForPets> selectedProducts, decimal totalAmount)
        {
            using (StreamWriter writer = new StreamWriter("Чек.txt"))
            {
                writer.WriteLine("КАССОВЫЙ ЧЕК");
                writer.WriteLine("---------------------");
                foreach (var product in selectedProducts)
                {
                    writer.WriteLine($"{product.NameOfFood} - Цена: {product.Price}");
                }
                writer.WriteLine("---------------------");
                writer.WriteLine($"Итог: {totalAmount}");
            }
        }
    }
}
