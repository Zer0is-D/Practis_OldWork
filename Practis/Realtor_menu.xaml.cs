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
using System.Data.OleDb;

namespace Practis
{
    /// <summary>
    /// Логика взаимодействия для Realtor_menu.xaml
    /// </summary>
    public partial class Realtor_menu : Window
    {
        public Realtor_menu()   
        {
            InitializeComponent();
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = ForDB.connection;

                string query = $"select * from [Agents] where id = { App.ID }";
                command.CommandText = query;
                ForDB.connection.Close();

                ForDB.connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ID_name_menu.Text = "ID: " + reader["id"].ToString();
                    First_name_menu.Text = "Фамилия: " + reader["FirstName"].ToString();
                    Middle_name_menu.Text = "Имя: " + reader["MiddleName"].ToString();
                    Last_name_menu.Text = "Отчество: " + reader["LastName"].ToString();
                    Deal_menu.Text = "Доля: " + reader["DealShare"].ToString();
                }

                ForDB.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void Edit_deal(object sender, RoutedEventArgs e)
        {
            Edit_Deal edit_ = new Edit_Deal();
            edit_.Show();
            this.Close();
        }

        private void Edit_profile(object sender, RoutedEventArgs e)
        {
            Edit_realtor_data edit_ = new Edit_realtor_data();
            edit_.Show();
            this.Close();
        }

        private void Delete_data(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить учетную запись?", "", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM [Agents] WHERE Id = " + App.ID + "";
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
