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

namespace Kalkulator.Maly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string operacja;
        private static double liczba1;
        private static bool nastepnaLiczbaKasuje;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Clicker(object sender, RoutedEventArgs e)
        {
            if (nastepnaLiczbaKasuje == true)
            {
                ResultBox.Clear();
                nastepnaLiczbaKasuje = false;
            }
           
            switch (((Button)sender).Content.ToString())
            {
                case "0":
                    ResultBox.Text += "0";
                    break;
                case "1":
                    ResultBox.Text += "1";
                    break;
                case "2":
                    ResultBox.Text += "2";
                    break;
                case "3":
                    ResultBox.Text += "3";
                    break;
                case "4":
                    ResultBox.Text += "4";
                    break;
                case "5":
                    ResultBox.Text += "5";
                    break;
                case "6":
                    ResultBox.Text += "6";
                    break;
                case "7":
                    ResultBox.Text += "7";
                    break;
                case "8":
                    ResultBox.Text += "8";
                    break;
                case "9":
                    ResultBox.Text += "9";
                    break;
            }

        }

        private void Dzialania(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "+":
                    operacja = "+"; break;
                case "-":
                    operacja = "-"; break;
                case "*":
                    operacja = "*"; break;
                case "/":
                    operacja = "/"; break;

            }
            liczba1 = double.Parse(ResultBox.Text);
            nastepnaLiczbaKasuje = true;
        }

        private void button_Equals_Click(object sender, RoutedEventArgs e)
        {
            double liczba = double.Parse(ResultBox.Text);

            switch (operacja)
            {
                case "+":
                    liczba1 += liczba;
                case "-":
                    liczba1 -= liczba;
                case "/":
                    liczba1 /= liczba;
                case "*":
                    liczba1 *= liczba;
            }

            ResultBox.Clear();
            ResultBox.Text += liczba1;
        }
    }
}
