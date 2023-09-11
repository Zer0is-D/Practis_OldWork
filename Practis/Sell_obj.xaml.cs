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
    /// Логика взаимодействия для Sell_obj.xaml
    /// </summary>
    public partial class Sell_obj : Window
    {
        string Table;
        public Sell_obj()
        {
            InitializeComponent();
            Table = "Apartments";
            Combobox_update($"Select * from [{Table}] where Owner = {App.ID}", Obj_list);

            Combobox_update($"Select [id], [FirstName], [MiddleName], [DealShare] from [Agents]", Realtor_list);
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

        public static int Get_ID(ComboBox value)
        {
            StringBuilder id = new StringBuilder("");

            for (int i = 0; char.IsDigit(value.Text[i]); i++)
                id.Append(value.Text[i]);

            return Convert.ToInt32(id.ToString());
        }

        private void RadioButton1_Click(object sender, RoutedEventArgs e)
        {
            Table = "Apartments";
            Obj_list.Items.Clear();
            Combobox_update($"Select * from [{Table}] where Owner = {App.ID}", Obj_list);
        }

        private void RadioButton2_Click(object sender, RoutedEventArgs e)
        {
            Table = "Houses";
            Obj_list.Items.Clear();
            Combobox_update($"Select * from [{Table}] where Owner = {App.ID}", Obj_list);
        }

        private void RadioButton3_Click(object sender, RoutedEventArgs e)
        {
            Table = "Lands";
            Obj_list.Items.Clear();
            Combobox_update($"Select * from [{Table}] where Owner = {App.ID}", Obj_list);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            bool cor_data = true;

            if (!Utility.Corr_digit(Price.Text)) { MessageBox.Show("Стоимость введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (cor_data)
            {

                OleDbCommand command = new OleDbCommand();
                command.Connection = ForDB.connection;
                command.CommandText = $"Insert into [Supplies] (Price,AgentId,ClientId,Obj_id,Kind) values ({Price.Text}, {Get_ID(Realtor_list)}, {App.ID}, {Get_ID(Obj_list)}, '{Table}')";
                ForDB.connection.Open();
                command.ExecuteNonQuery();
                ForDB.connection.Close();
            }
        }
    }
}
