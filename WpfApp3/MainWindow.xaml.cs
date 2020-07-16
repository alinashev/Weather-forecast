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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            string[] result = selectedCity.SelectedItem.ToString().Split(" ");
            selection = result[1];
            Console.WriteLine(selection);
            cityName.Text = selection;

        }

        private void refreshData(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection();
            connection.Connect(selection);
            foreach (var info in connection.getRoot().data)
            {
                temp.Text = "Темература: " + Convert.ToString(info.temp);
                rh.Text = "Влажность: " + Convert.ToString(info.rh);
                wind_spd.Text = "Скорость ветра: " + Convert.ToString(info.wind_spd);
                uv.Text = "Ультрафиолетовый индекс: " + Convert.ToString(info.uv);
                if (info.clouds < 60)
                {
                    cloudIcon.Visibility = Visibility.Hidden;
                    sunIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    cloudIcon.Visibility = Visibility.Visible;
                    sunIcon.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}