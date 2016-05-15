
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

        
    }
}