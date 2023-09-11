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
    /// Логика взаимодействия для Big_deal.xaml
    /// </summary>
    public partial class Big_deal : Window
    {
        string Kind;
        int Demand_realtor;
        int Supply_realtor;
        public Big_deal()
        {
            InitializeComponent();
            ForDB.Combobox_update($"Select * from [Supplies]", Sell);
        }

        private void Sell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = $"Select [Kind], [AgentId] from [Supplies] where id = {Utility.Get_ID(Sell)}";
            command.Connection = ForDB.connection;
            ForDB.connection.Open();

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Kind = reader.GetString(0); 
                Supply_realtor = reader.GetInt32(1);
            }

            ForDB.connection.Close();

            string query = "";
            switch (Kind)
            {
                case "Apartments":
                    query = "Select * from [Apartment-demands]";
                    break;

                case "Houses":
                    query = "Select * from [House-demands]";                    
                    break;

                case "Lands":
                    query = "Select * from [Land-demands]";                   
                    break;
            }

            Buy.IsEnabled = true;
            Buy.Items.Clear();
            ForDB.Combobox_update(query, Buy);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = $"INSERT INTO [Deals] (Demand_Id,Supply_Id,Demand_type,Demand_realtor,Supply_realtor) VALUES({Utility.Get_ID(Buy)}, {Utility.Get_ID(Sell)}, '{Kind}',{Demand_realtor}, {Supply_realtor})";
            command.Connection = ForDB.connection;
            ForDB.connection.Open();

            command.ExecuteNonQuery();

            ForDB.connection.Close();
            MessageBox.Show("Сделка оформлена!","Успех");
        }
    }
}
