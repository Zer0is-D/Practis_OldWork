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
    /// Логика взаимодействия для Edit_realtor_data.xaml
    /// </summary>
    public partial class Edit_realtor_data : Window
    {
        public Edit_realtor_data()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Cor_name(First_name.Text)) { MessageBox.Show("Фамилия введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Middle_name.Text)) { MessageBox.Show("Имя введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Last_name.Text)) { MessageBox.Show("Отчество введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(Deal.Text)) { MessageBox.Show("Доля введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }


            if (cor_data)
            {
                MessageBoxResult result = MessageBox.Show("Хотите изменить данные?", "", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        ForDB.connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = ForDB.connection;
                        string query = "update [Agents] set FirstName ='" + First_name.Text + "', MiddleName = '" + Middle_name.Text + "', LastName = '" + Last_name.Text + "', DealShare = '" + Deal.Text + "' where id=" + App.ID + "";
                        MessageBox.Show(query);
                        command.CommandText = query;

                        command.ExecuteNonQuery();
                        MessageBox.Show("Данные изменены!");
                        ForDB.connection.Close();

                        Realtor_menu realtor = new Realtor_menu();
                        realtor.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
                else
                {
                    Realtor_menu realtor = new Realtor_menu();
                    realtor.Show();
                    this.Close();
                }
            }              
        }
    }
}
