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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Realtor_reg : Window
    {
        public Realtor_reg()
        {
            InitializeComponent();
        }

        private void Realtor_reg_b(object sender, RoutedEventArgs e)
        {
            bool cor_data = true;

            if (!Utility.Cor_name(First_name_reg.Text)) { MessageBox.Show("Фамилия введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Middle_name_reg.Text)) { MessageBox.Show("Имя введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Cor_name(Last_name_reg.Text)) { MessageBox.Show("Отчество введено некорректно!", "Некорректный ввод данных!"); cor_data = false; }
            if (!Utility.Corr_digit(Deal_Share_reg.Text)) { MessageBox.Show("Доля введена некорректно!", "Некорректный ввод данных!"); cor_data = false; }

            if(cor_data)
            {
                try
                {
                    ForDB.connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = ForDB.connection;
                    command.CommandText = "INSERT INTO [Agents] (FirstName,MiddleName,LastName,DealShare) VALUES('" + First_name_reg.Text + "','" + Middle_name_reg.Text + "','" + Last_name_reg.Text + "'," + Deal_Share_reg.Text + ")";

                    command.ExecuteNonQuery();
                    MessageBox.Show("Аккаунт создан! Авторизируйтесь!");
                    ForDB.connection.Close();

                    Realtor_auto realtor_auto = new Realtor_auto();
                    realtor_auto.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }
    }
}
