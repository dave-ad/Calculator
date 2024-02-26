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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double currentNumber = 0;
        private double result = 0;
        private char? currentOperation = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string number = button.Content.ToString();
                if (lblResult.Content.ToString() == "0")
                    lblResult.Content = number;
                else
                    lblResult.Content += number;
            }
        }

        private void clearBtn(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (currentOperation != null)
                {
                    PerformOperation();
                }

                currentNumber = double.Parse(lblResult.Content.ToString());
                currentOperation = button.Content.ToString()[0];

                //string operation = button.Content.ToString();
                //operationsLbl.Content += lblResult.Content + " " + operation + " ";

                lblResult.Content = "0";
                operationsLbl.Content += currentNumber.ToString() + " " + currentOperation + " ";
            }
        }

        private void PerformOperation()
        {
            if (currentOperation != null)
            {
                double number = double.Parse(lblResult.Content.ToString());
                switch (currentOperation)
                {
                    case '+':
                        result = currentNumber + number;
                        break;
                    case '-':
                        result = currentNumber - number;
                        break;
                    case '*':
                        result = currentNumber * number;
                        break;
                    case '/':
                        result = currentNumber / number;
                        break;
                }
                lblResult.Content = result.ToString();
                currentNumber = result;
            }
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation();
            currentOperation = null;
        }

        private void ClearControls()
        {
            lblResult.Content = "0";
            operationsLbl.Content = "";
        }
        
        private void showOpResult(object sender, RoutedEventArgs e)
        {
            PerformOperation();
            operationsLbl.Content += lblResult.Content + " = ";
            currentOperation = null;
        }
    }
}
