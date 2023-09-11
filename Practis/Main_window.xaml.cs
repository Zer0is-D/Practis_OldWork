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

namespace Practis
{
    /// <summary>
    /// Логика взаимодействия для Main_window.xaml
    /// Добавить проверки полей
    /// Добавить стили
    /// </summary>
    public partial class Main_window : Window
    {
        public Main_window()
        {
            InitializeComponent();
        }

        //  АВТОРИЗАЦИЯ КЛИЕНТА
        private void Client_auto_b(object sender, RoutedEventArgs e)
        {
            Client_auto client_auto = new Client_auto();
            client_auto.Show();
            this.Close();
        }

        //  АВТОРИЗАЦИЯ РИЕЛТОРА
        private void Realtor_auto_b(object sender, RoutedEventArgs e)
        {
            Realtor_auto realtor_auto = new Realtor_auto();
            realtor_auto.Show();
            this.Close();
        }

        //  РЕГИСТРАЦИЯ КЛИЕНТА
        private void Client_reg_b(object sender, RoutedEventArgs e)
        {
            Client_reg client_reg = new Client_reg();
            client_reg.Show();
            this.Close();
        }

        //  РЕГИСТРАЦИЯ РИЕЛТОРА
        private void Realtor_reg_b(object sender, RoutedEventArgs e)
        {
            Realtor_reg realtor_reg = new Realtor_reg();
            realtor_reg.Show();
            this.Close();
        }
    }
}
