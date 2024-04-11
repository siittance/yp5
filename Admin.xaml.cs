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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        List<string> list = new List<string> { "Проверка клиента", "Роли", "Авторизация", "Приют", "Корм", "Наименование питомца", "Игрушки для питомцев", "Породы питомцев", "Статус заказа", "Услуги магазина", "Питомцы", "Клиенты", "Сотрудники", "Кассиры", "Чеки", "Заказы" };
        public Admin()
        {
            InitializeComponent();
            tableComboBox.ItemsSource = list;
        }

        private void TableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tableComboBox.SelectedItem == list[0])
            {
                ClientProverka client = new ClientProverka();
                client.Show();
                Close();
            }
            if(tableComboBox.SelectedItem == list[1])
            {
                Roleeeee rl = new Roleeeee();
                rl.Show();
                Close();
            }
            if(tableComboBox.SelectedItem == list[2])
            {
                Avtorization rl = new Avtorization();
                rl.Show();
                Close();
            }
            if(tableComboBox.SelectedItem == list[3])
            {
                Priuti priuti = new Priuti();
                priuti.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[4])
            {
                EdaForPets edaForPets = new EdaForPets();
                edaForPets.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[5])
            {
                NaimenovaniePitomca naimenovaniePitomca = new NaimenovaniePitomca();
                naimenovaniePitomca.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[6])
            {
                IgrushkaPets igrushkaPets = new IgrushkaPets();
                igrushkaPets.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[7])
            {
                PorodaPitomic porodaPitomic = new PorodaPitomic();
                porodaPitomic.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[8])
            {
                StatusZakaza statusZakaza = new StatusZakaza();
                statusZakaza.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[9])
            {
                YslugiDlyaPetov yslugiDlyaPetov = new YslugiDlyaPetov();
                yslugiDlyaPetov.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[10])
            {
                Pitomci pitomci = new Pitomci();
                pitomci.Show(); 
                Close();
            }
            if (tableComboBox.SelectedItem == list[11])
            {
                Pokupateli pokupateli = new Pokupateli();
                pokupateli.Show(); 
                Close();
            }
            if (tableComboBox.SelectedItem == list[12])
            {
                Sotrudniki sotrudniki = new Sotrudniki();
                sotrudniki.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[13])
            {
                Cassiryyy cassiryyy = new Cassiryyy();
                cassiryyy.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[14])
            {
                Chekiiiii chekiiiii = new Chekiiiii();
                chekiiiii.Show();
                Close();
            }
            if (tableComboBox.SelectedItem == list[15])
            {
                Zakazii zakazii = new Zakazii();
                zakazii.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Back back = new Back();
            back.Show();
            Close();
        }
    }
}
