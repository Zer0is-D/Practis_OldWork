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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace Practis
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Client_auto : Window
    {
        public Client_auto()
        {
            InitializeComponent();            
        }       

        private void Client_auto_b(object sender, RoutedEventArgs e)
        {
            ForDB.connection.Open();
            string query = "Select * from [Clients] where FirstName ='" + First_name.Text + "' and MiddleName = '" + Middle_name.Text + "'";
            OleDbCommand command = new OleDbCommand(query, ForDB.connection);
            OleDbDataReader read = command.ExecuteReader();

            if (read.HasRows)
            {
                MessageBox.Show("Фамилия и имя верны");

                while (read.Read())
                {
                    App.ID = read.GetInt32(0);
                }
                ForDB.connection.Close();

                Client_menu client_menu = new Client_menu();
                client_menu.Show();
                this.Close();               
            }
            else
            {
                MessageBox.Show("Данного пользователя нет в системе!", "Oh no...");
            }
            ForDB.connection.Close();
        }
    }
}
