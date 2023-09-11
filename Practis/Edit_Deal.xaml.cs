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
    /// Логика взаимодействия для Edit_Deal.xaml
    /// </summary>
    public partial class Edit_Deal : Window
    {
        string Kind;
        int Demand_realtor;
        int Supply_realtor;
        public Edit_Deal()
        {
            InitializeComponent();
            ForDB.Combobox_update($"Select * from [Deals] where [Demand_realtor] = {App.ID} or [Supply_realtor] = {App.ID}", Deal);
            Deal.SelectedIndex = 0;
        }
        private void Sell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = $"Select [AgentId] from [Supplies] where id = {Utility.Get_ID(Sell)}";
            command.Connection = ForDB.connection;
            ForDB.connection.Open();

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Supply_realtor = reader.GetInt32(0);
            }

            ForDB.connection.Close();
        }

        private void Buy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Buy.Items.Count != 0)
            {
                OleDbCommand command = new OleDbCommand();
                string query = $"select * from [{Kind.TrimEnd('s')}-demands] where id = { Utility.Get_ID(Buy)}";
                command.CommandText = query;
                command.Connection = ForDB.connection;

                ForDB.connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Demand_realtor = int.Parse(reader["AgentId"].ToString());
                    try { A_address_city.Text = "Город: " + reader["Address_City"].ToString(); } catch { };
                    try { A_address_street.Text = "Улица: " + reader["Address_Street"].ToString(); } catch { };
                    try { A_address_house.Text = "Номер дома: " + reader["Address_House"].ToString(); } catch { };

                    try { A_min_price.Text = reader["MinPrice"].ToString(); } catch { };
                    try { A_max_price.Text = reader["MaxPrice"].ToString(); } catch { };

                    try { A_min_area.Text = reader["MinArea"].ToString(); } catch { };
                    try { A_max_area.Text = reader["MaxArea"].ToString(); } catch { };

                    try { A_min_rooms.Text = reader["MinRooms"].ToString(); } catch { };
                    try { A_max_rooms.Text = reader["MaxRooms"].ToString(); } catch { };

                    try { A_min_floor.Text = reader["MinFloor"].ToString(); } catch { };
                    try { A_min_floor.Text = reader["MaxFloor"].ToString(); } catch { };
                   
                }
                ForDB.connection.Close();
            }

        }

        private void Deal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = ForDB.connection;
            command.CommandText = $"Select [Demand_type], [Demand_Id], [Supply_Id] from [Deals] where [Id] = {Utility.Get_ID(Deal)}";
            
            ForDB.connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Kind = reader.GetString(0);
                Demand_realtor = reader.GetInt32(1);
                Supply_realtor = reader.GetInt32(2);
            }

            ForDB.connection.Close();
            Sell.Items.Clear();
            Buy.Items.Clear();

            ForDB.Combobox_update($"Select * from [Supplies] where [Kind] = '{Kind}'", Sell);
            ForDB.Combobox_update($"Select * from [{Kind.TrimEnd('s')}-demands]", Buy);

            Set_element(Sell, Supply_realtor);
            Set_element(Buy, Demand_realtor);
        }

        private void Set_element(ComboBox combo_box, int id)
        {
            foreach (string item in combo_box.Items)
            {
                if (Utility.Get_ID(item) == id)
                {
                    combo_box.SelectedItem = item;
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = ForDB.connection;
            command.CommandText = $"Update [Deals] set [Demand_Id] = {Utility.Get_ID(Buy)}, [Demand_realtor] = {Demand_realtor}, [Supply_realtor] = {Supply_realtor}, [Supply_Id] = {Utility.Get_ID(Sell)} where [Id] = {Utility.Get_ID(Deal)}";
            
            ForDB.connection.Open();

            command.ExecuteNonQuery();

            ForDB.connection.Close();
        }
    }
}
