using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace Practis
{
    /// <summary>
    /// Логика взаимодействия для Edit_client_data.xaml
    /// </summary>
    public partial class Edit_client_data : Window
    {
        public Edit_client_data()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Cor_name(First_name.Text)) { MessageBox.Show("Фамилия введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Middle_name.Text)) { MessageBox.Show("Имя введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Last_name.Text)) { MessageBox.Show("Отчество введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_email(Email.Text)) { MessageBox.Show("Почта введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_phone(Phone.Text)) { MessageBox.Show("Телефон введен некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (cor_data)
            {
                MessageBoxResult result = MessageBox.Show("Хотите изменить данные?", "", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        ForDB.connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = ForDB.connection;
                        string query = "update [Clients] set FirstName ='" + First_name.Text + "', MiddleName = '" + Middle_name.Text + "', LastName = '" + Last_name.Text + "', Email = " + Email.Text + ", Phone = '" + Phone.Text + "' where id=" + App.ID + "";
                        MessageBox.Show(query);
                        command.CommandText = query;

                        command.ExecuteNonQuery();
                        MessageBox.Show("Данные изменены!");
                        ForDB.connection.Close();

                        Client_menu client = new Client_menu();
                        client.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
                else
                {
                    Client_menu client = new Client_menu();
                    client.Show();
                    this.Close();
                }
            }
        }
    }
}
