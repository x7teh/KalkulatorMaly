using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalkulator.Maly
{
    public partial class MainWindow : Window
    {
        private static Operation operation;
        private static double number1;
        private static double number2;
        private static double? memory = null;
        private static double result;
        private static bool checkResultBox;
        private static bool nextTimeErase;

        public MainWindow()
        {
            InitializeComponent();
        }

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
        private void Window_TextInput(object sender, TextCompositionEventArgs e)
        {
            Button button = new Button();

            switch (e.Text)
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
                case "0":
                    button.Content = e.Text;
                    ClickNumber(button, null);
                    break;
                case "%":
                    button_procent_Click(null, null);
                    break;
                case ",":
                case ".":
                    button_coma_Click(null, null);
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    button.Content = e.Text;
                    ClickNumber(button, null);
                    break;
                case "=":
                    button_Equals_Click(null, null);
                    break;
                default:
                    return;
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int keyCode = KeyInterop.VirtualKeyFromKey(e.Key);

            switch (keyCode)
            {
                case 8:
                    button_backspace_Click(null, null);
                    break;
                case 13:
                    button_Equals_Click(null, null);
                    break;
                case 27:
                    Application.Current.Shutdown();
                    break;
                case 46:
                    button_C_Click(null, null);
                    break;
                default:
                    return;
            }
        }
    }
}