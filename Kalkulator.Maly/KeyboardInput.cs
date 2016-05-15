using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalkulator.Maly
{
    public partial class MainWindow : Window
    {
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
                    Operation(button, null);
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
                    Close();
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