using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
using Newtonsoft.Json;

namespace YP5
{
    /// <summary>
    /// Логика взаимодействия для Back.xaml
    /// </summary>
    public partial class Back : Window
    {
        public Back()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var backupPath = @"C:\Users\Public\BackupYP5.bak";

            using (var dbContext = new PetShopYP5Entities1())
            {
                try
                {
                    var sqlCommand = $"BACKUP DATABASE {dbContext.Database.Connection.Database} TO DISK = '{backupPath}'";

                    dbContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCommand);
                    MessageBox.Show("Резервная копия базы данных успешно создана.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании резервной копии: {ex.Message}");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\Administrator\Desktop\lol.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файла не существует");
                return;
            }

            using (var dbContext = new PetShopYP5Entities1())
            {
                var json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<List<ClientCheck>>(json);
                var data1 = JsonConvert.DeserializeObject<List<Shelter>>(json);
                var data2 = JsonConvert.DeserializeObject<List<Rolee>>(json);

                foreach (var item in data)
                {
                    dbContext.ClientCheck.Add(item);
                }
                foreach (var item in data1)
                {
                    dbContext.Shelter.Add(item);
                }
                foreach (var item in data2)
                {
                    dbContext.Rolee.Add(item);
                }
                try
                {
                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно импортированы в таблицы (Проверка клиента, приюты, роль)");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Ошибка: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
        }
    }
}
 
