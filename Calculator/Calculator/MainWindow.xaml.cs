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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result = 0;
        string operation = "";
        bool isOperation = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Number(object sender, RoutedEventArgs e)
        {
            if (TextChanged.Text == "0" || isOperation)
            {
                TextChanged.Clear();
            }

            isOperation = false;
            Button button = (Button)sender;

            if (Convert.ToString(button.Content) == ",")
            {
                if (!TextChanged.Text.Contains(","))
                {
                    TextChanged.Text = TextChanged.Text + button.Content;
                }
            }
            else
            {
                TextChanged.Text = TextChanged.Text + button.Content;
            }
        }

        private void Button_Operator(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (result != 0)
            {
                switch (operation)
                {
                    case "+":
                        TextChanged.Text = Convert.ToString(result + Convert.ToDouble(TextChanged.Text));
                        break;
                    case "*":
                        TextChanged.Text = Convert.ToString(result * Convert.ToDouble(TextChanged.Text));
                        break;
                    case "/":
                        TextChanged.Text = Convert.ToString(result / Convert.ToDouble(TextChanged.Text));
                        break;
                    case "-":
                        TextChanged.Text = Convert.ToString(result - Convert.ToDouble(TextChanged.Text));
                        break;
                }

                operation = Convert.ToString(button.Content);
                Label_operation.Content = result + " " + operation;
                isOperation = true;
            }

            else 
            {
                operation = Convert.ToString(button.Content);
                result = Convert.ToDouble(TextChanged.Text);
                Label_operation.Content = result + " " + operation;
                isOperation = true;
            }
        }

        private void Button_CE(object sender, RoutedEventArgs e)
        {
            TextChanged.Text = "0";
        }

        private void Button_C(object sender, RoutedEventArgs e)
        {
            TextChanged.Text = "0";
            result = 0;
            Label_operation.Content = "";
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            int len = TextChanged.Text.Length;

            if(len > 1)
            {
                TextChanged.Text = TextChanged.Text.Remove(TextChanged.Text.Length - 1);
            }
            else
            {
                TextChanged.Text = TextChanged.Text.Remove(TextChanged.Text.Length - 1) + "0";
            }
        }

        private void Button_Result(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    TextChanged.Text = Convert.ToString(result + Convert.ToDouble(TextChanged.Text));
                    break;
                case "*":
                    TextChanged.Text = Convert.ToString(result * Convert.ToDouble(TextChanged.Text));
                    break;
                case "/":
                    TextChanged.Text = Convert.ToString(result / Convert.ToDouble(TextChanged.Text));
                    break;
                case "-":
                    TextChanged.Text = Convert.ToString(result - Convert.ToDouble(TextChanged.Text));
                    break;
            }

            result = Convert.ToDouble(TextChanged.Text);
            Label_operation.Content = "";
        }

        private void Button_plusminus(object sender, RoutedEventArgs e)
        {
            TextChanged.Text = Convert.ToString(-Convert.ToDouble(TextChanged.Text));
            result = Convert.ToDouble(TextChanged.Text);
        }

        private void Button_sqrt(object sender, RoutedEventArgs e)
        {
            TextChanged.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(TextChanged.Text)));
            result = Convert.ToDouble(TextChanged.Text);
        }

        private void Button_proc(object sender, RoutedEventArgs e)
        {
            TextChanged.Text = Convert.ToString(Convert.ToDouble(TextChanged.Text)/100);
            result = Convert.ToDouble(TextChanged.Text);
        }

        private void Button_1(object sender, RoutedEventArgs e)
        {
            TextChanged.Text = Convert.ToString(1/Convert.ToDouble(TextChanged.Text));
            result = Convert.ToDouble(TextChanged.Text);
        }
    }
}
