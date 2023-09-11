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
    /// Логика взаимодействия для Client_land.xaml
    /// </summary>
    public partial class Client_land : Window
    {
        public Client_land()
        {
            InitializeComponent();
        }

        private void Add_object(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Corr_digit(Address_number.Text)) { MessageBox.Show("Номер введен некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(Coordinate_latitude.Text)) { MessageBox.Show("Широта введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(Coordinate_longitude.Text)) { MessageBox.Show("Долгота введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(Total_area.Text)) { MessageBox.Show("Общая площадь введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (cor_data)
            {
                try
                {
                    ForDB.connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = ForDB.connection;
                    command.CommandText = "INSERT INTO [Lands] (Address_City,Address_Street,Address_House,Address_Number,Coordinate_latitude,Coordinate_longitude,TotalArea,Owner) values('" + Address_city.Text + "','" + Address_street.Text + "','" + Address_house.Text + "','" + Address_number.Text + "'," + Coordinate_latitude.Text + "," + Coordinate_longitude.Text + "," + Total_area.Text + "," + App.ID + ")";
                    command.ExecuteNonQuery();
                    ForDB.connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }
    }
}
