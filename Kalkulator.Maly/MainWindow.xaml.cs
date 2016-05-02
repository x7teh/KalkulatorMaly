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
        private static double liczba2;
        private static bool sprawdzResultBox;
        private static bool nastepnaLiczbaKasuje;
        private static bool usedEqual; 
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
            if (usedEqual == true)
            {
                ResultBox.Clear();
                usedEqual = false;
            }
                switch (((Button)sender).Content.ToString())
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (ResultBox.Text.Equals("0") || sprawdzResultBox)
                    {
                        ResultBox.Text = "";
                    }
                    ResultBox.Text += ((Button)sender).Content.ToString();
                    break;
                case "0":
                    if (ResultBox.Text == "0") return;
                    if (sprawdzResultBox) ResultBox.Text = "0";
                    else
                        ResultBox.Text += "0";
                    break;
              }
            sprawdzResultBox = false;
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
            double liczba2 = double.Parse(ResultBox.Text);

            switch (operacja)
            {
                case "+":
                    liczba1 += liczba2; break;
                case "-":
                    liczba1 -= liczba2; break;
                case "/":
                    liczba1 /= liczba2; break;
                case "*":
                    liczba1 *= liczba2; break;
            }
            usedEqual = true;
            ResultBox.Clear();
            ResultBox.Text += liczba1;
        }

        private void button_procent_Click(object sender, RoutedEventArgs e)
        {
            liczba1 = double.Parse(ResultBox.Text);
            if (liczba1 == 0) return;
            else
            {
                liczba1 = liczba1 / 100;
                ResultBox.Clear();
                ResultBox.Text += liczba1;
            }
        }
    }
}
