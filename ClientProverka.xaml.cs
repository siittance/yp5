﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ClientProverka.xaml
    /// </summary>
    public partial class ClientProverka : Window
    {
        PetShopYP5Entities1 yp = new PetShopYP5Entities1 ();
        public ClientProverka()
        {
            InitializeComponent();
            TableSS.ItemsSource = yp.ClientCheck.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin ();
            admin.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (yp.ClientCheck.Any(r => r.NameOfThecheck == ReadDannie.Text))
                {
                    MessageBox.Show("Такое наименование уже есть");
                    ReadDannie.Text = null;
                }
                else
                {
                    ClientCheck cl = new ClientCheck();
                    cl.NameOfThecheck = ReadDannie.Text;
                    yp.ClientCheck.Add(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.ClientCheck.ToList();
                    ReadDannie.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (TableSS.SelectedItem != null)
                {
                    ClientCheck lp = TableSS.SelectedItem as ClientCheck;

                    if (yp.NaimenovaniePetsa.Any(r => r.Naimenovanie == ReadDannie.Text))
                    {
                        MessageBox.Show("Такое наименование уже есть");
                        ReadDannie.Text = null;
                    }
                    else
                    {
                        var selected = TableSS.SelectedItem as ClientCheck;
                        selected.NameOfThecheck = ReadDannie.Text;
                        yp.SaveChanges();
                        TableSS.ItemsSource = yp.ClientCheck.ToList();
                        ReadDannie.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите элемент для редактирования");
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private bool Deleted(ClientCheck selectedFood)
        {
            if (yp.Clients.Any(entry => entry.ClientCheck_ID == selectedFood.ID_ClientCheck))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ReadDannie.Text != null && !string.IsNullOrWhiteSpace(ReadDannie.Text))
            {
                if (!Deleted(TableSS.SelectedItem as ClientCheck))
                    return;
                if (TableSS.SelectedItem != null)
                {
                    ClientCheck cl = TableSS.SelectedItem as ClientCheck;
                    yp.ClientCheck.Remove(cl);
                    yp.SaveChanges();
                    TableSS.ItemsSource = yp.ClientCheck.ToList();
                    ReadDannie.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void TableSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var proverka = (ClientCheck)TableSS.SelectedItem;
            if (proverka != null)
            {
                ReadDannie.Text = proverka.NameOfThecheck.ToString();
            }
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
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}