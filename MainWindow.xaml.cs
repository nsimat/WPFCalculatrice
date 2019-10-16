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

namespace WPFCalculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        double memory = 0.0;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            resultText.Text = "0";

            cBtn.Click += CBtn_Click;

            plusorminusBtn.Click += PlusorminusBtn_Click;

            mrBtn.Click += MrBtn_Click;

            mcBtn.Click += McBtn_Click;

            mPlusBtn.Click += MPlusBtn_Click;

            mNegativeBtn.Click += MNegativeBtn_Click;

            equalBtn.Click += EqualBtn_Click;
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            //double newNumber;

            if(double.TryParse(resultText.Text, out double newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultText.Text = result.ToString();
            }
        }

        private void MNegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultText.Text, out lastNumber))
            {
                memory -= lastNumber;
            }
                
        }

        private void MPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultText.Text, out lastNumber))
            {
                memory += lastNumber;
            }
            
        }

        private void McBtn_Click(object sender, RoutedEventArgs e)
        {
            memory = 0;
        }

        private void MrBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = memory.ToString();
        }

        private void PlusorminusBtn_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultText.Text, out lastNumber))
            {
                lastNumber *= -1;
                resultText.Text = lastNumber.ToString();
            }
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "0";
            lastNumber = 0;
            result = 0;
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroBtn)
                selectedValue = 0;

            if (sender == oneBtn)
                selectedValue = 1;

            if (sender == twoBtn)
                selectedValue = 2;

            if (sender == threeBtn)
                selectedValue = 3;

            if (sender == fourBtn)
                selectedValue = 4;

            if (sender == fiveBtn)
                selectedValue = 5;

            if (sender == sixBtn)
                selectedValue = 6;

            if (sender == sevenBtn)
                selectedValue = 7;

            if (sender == eightBtn)
                selectedValue = 8;

            if (sender == nineBtn)
                selectedValue = 9;


            if (resultText.Text == "0")
            {
                resultText.Text = $"{selectedValue}";
            }
            else
            {
                resultText.Text = $"{resultText.Text}{selectedValue}";
            }

        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultText.Text, out lastNumber))
            {
                resultText.Text = "0";
            }

            if (sender == multiplicationBtn)
                selectedOperator = SelectedOperator.Multiplication;

            if (sender == divisionBtn)
                selectedOperator = SelectedOperator.Division;

            if (sender == plusBtn)
                selectedOperator = SelectedOperator.Addition;
            
            if (sender == negativeBtn)
                selectedOperator = SelectedOperator.Substraction;
        }

        public enum SelectedOperator
        {
            Addition,
            Substraction,
            Multiplication,
            Division
        }

        private void commaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (resultText.Text.Contains(","))
            {
                //Do nothing
            }
            else
            {
                resultText.Text = $"{resultText.Text},";
            }
        }

        public class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }

            public static double Substract(double n1, double n2)
            {
                return n1 - n2;
            }

            public static double Multiply(double n1, double n2)
            {
                return n1 * n2;
            }

            public static double Divide(double n1, double n2)
            {
                if(n2 == 0)
                {
                    MessageBox.Show("La division par 0 n'est pas supportée!", "Mauvaise opération", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
                return n1 / n2;
            }
        }
    }
}
