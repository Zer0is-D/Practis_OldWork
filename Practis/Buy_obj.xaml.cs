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
    /// Логика взаимодействия для Buy_obj.xaml
    /// </summary>
    public partial class Buy_obj : Window
    {
        public Buy_obj()
        {
            InitializeComponent();
            Combobox_update($"Select [id], [FirstName], [MiddleName], [DealShare] from [Agents]", Apart_realtor);
            Combobox_update($"Select [id], [FirstName], [MiddleName], [DealShare] from [Agents]", House_realtor);
            Combobox_update($"Select [id], [FirstName], [MiddleName], [DealShare] from [Agents]", Land_realtor);
        }

        public static int Get_ID(ComboBox value)
        {
            StringBuilder id = new StringBuilder("");

            for (int i = 0; char.IsDigit(value.Text[i]); i++)
                id.Append(value.Text[i]);

            return Convert.ToInt32(id.ToString());
        }

        public void Combobox_update(string query, ComboBox box)
        {
            ForDB.connection.Open();
            OleDbCommand command = new OleDbCommand(query, ForDB.connection);
            OleDbDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                string item_name = "";
                for (int i = 0; i < read.FieldCount; i++)
                {
                    item_name += read.GetValue(i) + " ";
                }
                box.Items.Add(item_name);
            }
            read.Close();

            ForDB.connection.Close();
        }

        private void Apartment_insert(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Corr_digit(A_min_price.Text)) { MessageBox.Show("Мин. стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(A_max_price.Text)) { MessageBox.Show("Макс. стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(A_min_area.Text)) { MessageBox.Show("Мин. комнат введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(A_max_area.Text)) { MessageBox.Show("Макс. комнат введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(A_min_rooms.Text)) { MessageBox.Show("Мин. площадь введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(A_max_rooms.Text)) { MessageBox.Show("Макс. площадь введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(A_min_floor.Text)) { MessageBox.Show("Мин. этаж введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(A_max_floor.Text)) { MessageBox.Show("Макс. этаж введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (cor_data)
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = ForDB.connection;
                command.CommandText = $"insert into [Apartment-demands] (Address_City, Address_Street, Address_House, MinPrice, MaxPrice, MinArea, MaxArea, MinRooms, MaxRooms, MinFloor, MaxFloor) values('" + A_address_city.Text + "','" + A_address_street.Text + "','" + A_address_house.Text + "'," + A_min_price.Text + "," + A_max_price.Text + "," + A_min_area.Text + "," + A_max_area.Text + "," + A_min_rooms.Text + "," + A_max_rooms.Text + "," + A_min_floor.Text + "," + A_max_floor.Text + ")";
                ForDB.connection.Open();
                command.ExecuteNonQuery();
                ForDB.connection.Close();
            }
        }

        private void House_insert(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Corr_digit(H_min_price.Text)) { MessageBox.Show("Мин. стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(H_max_price.Text)) { MessageBox.Show("Макс. стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(H_min_area.Text)) { MessageBox.Show("Мин. комнат введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(H_max_area.Text)) { MessageBox.Show("Макс. комнат введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(H_min_rooms.Text)) { MessageBox.Show("Мин. площадь введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(H_max_rooms.Text)) { MessageBox.Show("Макс. площадь введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(H_min_floors.Text)) { MessageBox.Show("Мин. этажей введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(H_max_floors.Text)) { MessageBox.Show("Макс. этажей введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (cor_data)
            {

                OleDbCommand command = new OleDbCommand();
                command.Connection = ForDB.connection;
                command.CommandText = $"insert into [House-demands] (Address_City, Address_Street, MinPrice, MaxPrice, MinArea, MaxArea, MinRooms, MaxRooms, MinFloors, MaxFloors) values('" + H_address_city.Text + "','" + H_address_street.Text + "'," + H_min_price.Text + "," + H_max_price.Text + "," + H_min_area.Text + "," + H_max_area.Text + "," + H_min_rooms.Text + "," + H_max_rooms.Text + "," + H_min_floors.Text + "," + H_max_floors.Text + ")";
                ForDB.connection.Open();
                command.ExecuteNonQuery();
                ForDB.connection.Close();
            }
        }

        private void Land_insert(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Corr_digit(L_min_price.Text)) { MessageBox.Show("Мин. стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(L_max_price.Text)) { MessageBox.Show("Макс. стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (!Utility.Corr_digit(L_min_area.Text)) { MessageBox.Show("Мин. комнат введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(L_max_area.Text)) { MessageBox.Show("Макс. комнат введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if (cor_data)
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = ForDB.connection;
                command.CommandText = $"insert into [Land-demands] (Address_City, Address_Street, MinPrice, MaxPrice, MinArea, MaxArea) values('" + L_address_city.Text + "','" + L_address_street.Text + "'," + L_min_price.Text + "," + L_max_price.Text + "," + L_min_area.Text + "," + L_max_area.Text + ")";
                ForDB.connection.Open();
                command.ExecuteNonQuery();
                ForDB.connection.Close();
            }
        }

    }
}
