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
    /// Логика взаимодействия для Client_menu.xaml
    /// </summary>
    public partial class Client_menu : Window
    {
        public Client_menu()
        {
            InitializeComponent();
            try
            {
                ForDB.connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = ForDB.connection;

                string query = $"select * from [Clients] where id = { App.ID }";
                command.CommandText = query;

                //  Загрузка данных о пользователе 
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ID_name_menu.Text = "ID: " + reader["id"].ToString();
                    First_name_menu.Text = "Фамилия: " + reader["FirstName"].ToString();
                    Middle_name_menu.Text = "Имя: " + reader["MiddleName"].ToString();
                    Last_name_menu.Text = "Отчество: " + reader["LastName"].ToString();
                    Phone_menu.Text = "Телефон: " + reader["Phone"].ToString();
                    Email_menu.Text = "Почта: " + reader["Email"].ToString();
                }
                ForDB.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        //  Добавить объект
        private void Add_object(object sender, RoutedEventArgs e)
        {
            Add_object add_object = new Add_object();
            add_object.Show();
        }

        //  Покупка объекта
        private void Big_deal(object sender, RoutedEventArgs e)
        {
            Big_deal big = new Big_deal();
            big.Show();
        }

        //  Продажа объекта
        private void Sell_obj(object sender, RoutedEventArgs e)
        {
            Sell_obj sell = new Sell_obj();
            sell.Show();
        }

        //  Редактирования продажи
        private void Edit_sell(object sender, RoutedEventArgs e)
        {
        
        }

        //  Редактирования записи
        private void Edit_data(object sender, RoutedEventArgs e)
        {
            Edit_client_data edit_ = new Edit_client_data();
            edit_.Show();
            this.Close();
        }

        //  Удаление учет записи
        private void Delete_data(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить учетную запись?", "", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM [Clients] WHERE Id = " + App.ID + "";
                    ForDB.connection.Open();
                    OleDbCommand command = new OleDbCommand(query);
                    command.Connection = ForDB.connection;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data deleted!");
                    ForDB.connection.Close();

                    Main_window main_window = new Main_window();
                    main_window.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }
    }
}
