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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "1");
        }

        private void Button_addition_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "+");
        }

        private void Button_result_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.SetLabel(ref label_result, Calculations.Equals(label_result.Content.ToString()));
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "2");
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "3");
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "4");
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "5");
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "6");
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "7");
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "8");
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "9");
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            if ((label_result.Content.ToString().Length > 0 && label_result.Content.ToString() != "0")|| label_result.Content.ToString() == "")
                UIController.AddToLabel(ref label_result, "0");
        }

        private void Button_dot_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, ",");
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            UIController.RemoveFromLabel(ref label_result);
        }

        private void Button_c_Click(object sender, RoutedEventArgs e)
        {
            UIController.SetLabel(ref label_result, "");
        }

        private void Button_substraction_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "-");
        }

        private void Button_multiplication_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "*");
        }

        private void Button_division_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "/");
        }

        private void Button_pow_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "^");
        }

        private void Button_root_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "Root");
        }

        private void Button_sqrt_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "Sqrt");
        }

        private void Button_square_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.SetLabel(ref label_result, Calculations.Pow2(Calculations.Equals(label_result.Content.ToString())));
        }

        private void Button_sin_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "Sin");
        }

        private void Button_cos_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "Cos");
        }

        private void Button_tan_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "Tan");
        }

        private void Button_bracket_open_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, "(");
        }

        private void Button_bracket_close_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.AddToLabel(ref label_result, ")");
        }

        private void Button_negative_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.SetLabel(ref label_result, Calculations.Negative(Calculations.Equals(label_result.Content.ToString())));
        }

        private void Button_reverse_Click(object sender, RoutedEventArgs e)
        {
            UIController.ValidInput(ref label_result);
            UIController.SetLabel(ref label_result, Calculations.Reversed(Calculations.Equals(label_result.Content.ToString())));
        }
    }
}
