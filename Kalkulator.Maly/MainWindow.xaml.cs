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
        private static Operacja operacja;
        private static double liczba1;
        private static double liczba2;
        private static double? memory = null;
        private static double wynik;
        private static bool sprawdzResultBox;
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
                    operacja = Operacja.Add; break;
                case "-":
                    operacja = Operacja.Substract; break;
                case "*":
                    operacja = Operacja.Multiply; break;
                case "/":
                    operacja = Operacja.Divide; break;

            }
            liczba1 = double.Parse(ResultBox.Text);
            nastepnaLiczbaKasuje = true;
        }

        private void button_Equals_Click(object sender, RoutedEventArgs e)
        {
            
            liczba2 = double.Parse(ResultBox.Text);

            switch (operacja)
            {
                case Operacja.Add:
                    wynik = liczba1 + liczba2; break;
                case Operacja.Substract:
                    wynik = liczba1 - liczba2; break;
                case Operacja.Divide:
                    wynik = liczba1 / liczba2; break;
                case Operacja.Multiply:
                    wynik = liczba1 * liczba2; break;
                default:
                    return;
            }
            
            ResultBox.Clear();
            ResultBox.Text += wynik;
            nastepnaLiczbaKasuje = true;
        }

        private void button_CE_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = "0";
        }

        private void button_procent_Click(object sender, RoutedEventArgs e)
        {
            if (liczba2 == 0)
            liczba2 = double.Parse(ResultBox.Text);
            wynik = (liczba1 / 100) * liczba2;

            ResultBox.Clear();
            ResultBox.Text += wynik;            // jakas funkcje pasowaloby zrobic zeby nie klepac tego ciagle
            nastepnaLiczbaKasuje = true;
        }

        private void button_sqrt_Click(object sender, RoutedEventArgs e)
        {
            liczba1 = double.Parse(ResultBox.Text);
            if (liczba1 == 0) return;
            wynik = Math.Sqrt(liczba1);
            ResultBox.Clear();
            ResultBox.Text += wynik;
            nastepnaLiczbaKasuje = true;

        }

        private void button_ulamek_Click(object sender, RoutedEventArgs e)
        {
            liczba1 = double.Parse(ResultBox.Text);
            if (liczba1 == 0) return;
            wynik = 1 / liczba1;
            ResultBox.Clear();
            ResultBox.Text += wynik;
            nastepnaLiczbaKasuje = true;
        }

        private void button_Negative_Click(object sender, RoutedEventArgs e)
        {
            double tmp = double.Parse(ResultBox.Text);

            if (tmp > 0)
            {
                ResultBox.Text = string.Concat("-", ResultBox.Text);
            }
            else if (tmp < 0)
            {
                ResultBox.Text = ResultBox.Text.Remove(0, 1);
            }
            else
            {
                return;
            }
        }

        private void button_MC_Click(object sender, RoutedEventArgs e)
        {
            memory = null;
            memorylabel.Content = "";

        }

        private void button_MR_Click(object sender, RoutedEventArgs e)
        {
            if (memory != null)
                ResultBox.Text = memory.ToString();
            nastepnaLiczbaKasuje = true;
        }

        private void button_MS_Click(object sender, RoutedEventArgs e)
        {
            liczba1 = double.Parse(ResultBox.Text);
            if (liczba1 != 0)
            {
                memory = liczba1;
                memorylabel.Content = "M";
                nastepnaLiczbaKasuje = true;
            }
        }

        private void button_MPlus_Click(object sender, RoutedEventArgs e)
        {
            //kosmos ziom
            //łaaaaaał!!!
            //zmianaaaaaa
            //aaaaaa
        }

        private void button_MMiuns_Click(object sender, RoutedEventArgs e)
        {
            //jak wyzej
        }
    }
}
