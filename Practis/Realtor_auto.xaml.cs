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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Realtor_auto : Window
    {
        public Realtor_auto()
        {
            InitializeComponent();
        }

        private void Realtor_auto_b(object sender, RoutedEventArgs e)
        {
            ForDB.connection.Open();
            string query = "Select * from [Agents] where FirstName ='" + First_name.Text + "' and MiddleName = '" + Middle_name.Text + "'";
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

                Realtor_menu realtor_menu = new Realtor_menu();
                realtor_menu.Show();
                this.Close();             
            }
            else
            {
                MessageBox.Show("Данного пользователя нет в системе!","Oh no...");
            }
            ForDB.connection.Close();
        }

        
    }
}
