﻿using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator.Maly
{
    public partial class MainWindow : Window
    {
        private void ClickNumber(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button) || ResultBox.Text.Length == ResultBox.MaxLength)
                return;

            if (nextTimeErase)
            {
                ResultBox.Clear();
                nextTimeErase = false;
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
                    if (ResultBox.Text.Equals("0") || checkResultBox)
                    {
                        ResultBox.Text = "";
                    }
                    ResultBox.Text += ((Button)sender).Content.ToString();
                    break;
                case "0":
                    if (ResultBox.Text == "0")
                        return;
                    if (checkResultBox)
                        ResultBox.Text = "0";
                    else
                        ResultBox.Text += "0";
                    break;
            }
            checkResultBox = false;
        }

        private void Operation(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "+":
                    operation = Maly.Operation.Add;
                    break;
                case "-":
                    operation = Maly.Operation.Substract;
                    break;
                case "*":
                    operation = Maly.Operation.Multiply;
                    break;
                case "/":
                    operation = Maly.Operation.Divide;
                    break;
            }
            number1 = double.Parse(ResultBox.Text);
            nextTimeErase = true;
        }

        private void button_Equals_Click(object sender, RoutedEventArgs e)
        {
            number2 = double.Parse(ResultBox.Text);

            switch (operation)
            {
                case Maly.Operation.Add:
                    result = number1 + number2;
                    break;
                case Maly.Operation.Substract:
                    result = number1 - number2;
                    break;
                case Maly.Operation.Divide:
                    result = number1 / number2;
                    break;
                case Maly.Operation.Multiply:
                    result = number1 * number2;
                    break;
                default:
                    return;
            }

            ResultBox.Clear();
            ResultBox.Text += result;
            nextTimeErase = true;
        }

        private void button_CE_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = "0";
        }

        private void button_procent_Click(object sender, RoutedEventArgs e)
        {
            if (operation != Maly.Operation.Multiply) return;
            number2 = double.Parse(ResultBox.Text);
            if (number2 == 0) return;  // tak?
            result = number1 * (number2 / 100);

            ResultBox.Text = result.ToString();
            nextTimeErase = true;
        }

        private void button_sqrt_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(ResultBox.Text);
            if (number1 == 0)
                return;

            result = Math.Sqrt(number1);
            ResultBox.Text = result.ToString();
            nextTimeErase = true;
        }

        private void button_ulamek_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(ResultBox.Text);
            if (number1 == 0)
                return;

            result = 1 / number1;
            ResultBox.Text = result.ToString();
            nextTimeErase = true;
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
        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = "0";
            nextTimeErase = false;
        }

        private void button_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == "0" || nextTimeErase)
                return;

            var tekstResultBox = new StringBuilder(ResultBox.Text);
            int znakiDoUsuniecia = 1;
            if (tekstResultBox.Length > 2)
            {
                if (tekstResultBox[tekstResultBox.Length - 2] == ',')
                    znakiDoUsuniecia = 2;
            }

            if (tekstResultBox.Length > 1)
                ResultBox.Text = tekstResultBox.Remove(tekstResultBox.Length - znakiDoUsuniecia, znakiDoUsuniecia).ToString();
            else
                ResultBox.Text = "0";
        }

        private void button_coma_Click(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text.Contains(",") || ResultBox.Text.Length == ResultBox.MaxLength)
                return;

            if (nextTimeErase)
                ResultBox.Text = "0,";
            else
                ResultBox.Text += ",";
        }
    }
}
