using System;
using System.Text;
using System.Windows;

namespace Kalkulator.Maly
{
    public partial class MainWindow : Window
    {
        private void button_MC_Click(object sender, RoutedEventArgs e)
        {
            memory = null;
            MemoryLabel.Content = "";
        }

        private void button_MR_Click(object sender, RoutedEventArgs e)
        {
            if (memory != null)
                ResultBox.Text = memory.ToString();
            nextTimeErase = true;
        }

        private void button_MS_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(ResultBox.Text);
            if (number1 == 0)
                return;

            memory = number1;
            MemoryLabel.Content = "M";
            nextTimeErase = true;
        }

        private void button_MPlus_Click(object sender, RoutedEventArgs e)
        {
            double nowaPamiec = double.Parse(ResultBox.Text);
            if (nowaPamiec == 0)
                return;

            if (memory != null)
            {
                memory += nowaPamiec;
                nextTimeErase = true;
            }
            else
            {
                memory = 0 + nowaPamiec;
                MemoryLabel.Content = "M";
                nextTimeErase = true;
            }
        }

        private void button_MMiuns_Click(object sender, RoutedEventArgs e)
        {
            double nowaPamiec = double.Parse(ResultBox.Text);
            if (nowaPamiec == 0)
                return;
            if (memory != null)
            {
                memory -= nowaPamiec;
                nextTimeErase = true;
            }
            else
            {
                memory = 0 - nowaPamiec;
                MemoryLabel.Content = "M";
                nextTimeErase = true;
            }
        }
    }
}
