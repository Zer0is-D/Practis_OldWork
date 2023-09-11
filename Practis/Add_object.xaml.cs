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
    /// Логика взаимодействия для Add_object.xaml
    /// </summary>
    public partial class Add_object : Window
    {
        public Add_object()
        {
            InitializeComponent();
        }

        private void Apartament(object sender, RoutedEventArgs e)
        {
            Client_apartament client_apartament = new Client_apartament();
            client_apartament.Show();
            this.Close();
        }

        private void House(object sender, RoutedEventArgs e)
        {
            Client_house client_house = new Client_house();
            client_house.Show();
            this.Close();
        }

        private void Land(object sender, RoutedEventArgs e)
        {        
            Client_land client_land = new Client_land();
            client_land.Show();
            this.Close();
        }
    }
}
