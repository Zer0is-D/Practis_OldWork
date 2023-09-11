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
    /// Логика взаимодействия для Client_reg.xaml
    /// </summary>
    public partial class Client_reg : Window
    {
        public Client_reg()
        {
            InitializeComponent();
        }

        private void Client_reg_b(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Cor_name(First_name_reg.Text)) { MessageBox.Show("Фамилия введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Middle_name_reg.Text)) { MessageBox.Show("Имя введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Last_name_reg.Text)) { MessageBox.Show("Отчество введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_email(Email_reg.Text)) { MessageBox.Show("Почта введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_phone(Phone_reg.Text)) { MessageBox.Show("Телефон введен некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (cor_data)
            {
                try
                {
                    ForDB.connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = ForDB.connection;
                    command.CommandText = "INSERT INTO [Clients] (FirstName,MiddleName,LastName,Email,Phone) values('" + First_name_reg.Text + "','" + Middle_name_reg.Text + "','" + Last_name_reg.Text + "','" + Email_reg.Text + "','" + Phone_reg.Text + "')";

                    command.ExecuteNonQuery();
                    MessageBox.Show("Аккаунт создан! Авторизируйтесь!");
                    ForDB.connection.Close();

                    Client_auto client_auto = new Client_auto();
                    client_auto.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }
    }
}
