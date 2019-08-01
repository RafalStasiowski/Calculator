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
    static class Calculations
    {
        
        public static string Add(string _a,string _b)
        {
            double tmpA;
            double tmpB;
            if (double.TryParse(_a, out tmpA) && double.TryParse(_b, out tmpB))
                return (tmpA + tmpB).ToString();
            else
                return "Error +";
        }
        public static string Substract(string _a, string _b)
        {
            double tmpA;
            double tmpB;
            if (double.TryParse(_a, out tmpA) && double.TryParse(_b, out tmpB))
                return (tmpA - tmpB).ToString();
            else
                return "Error -";
        }
        public static string Multiply(string _a, string _b)
        {
            double tmpA;
            double tmpB;
            if (double.TryParse(_a, out tmpA) && double.TryParse(_b, out tmpB))
                return (tmpA * tmpB).ToString();
            else
                return "Error *";
        }
        public static string Divide(string _a, string _b)
        {
            double tmpA;
            double tmpB;
            if (double.TryParse(_a, out tmpA) && double.TryParse(_b, out tmpB))
            {
                
                if (tmpB == 0)
                    return "division by 0";
                else
                    return (tmpA / tmpB).ToString();
            }
            else
                return "Error /";            
        }
        public static string Pow(string _a, string _b)
        {
            double tmpA;
            double tmpB;
            if (double.TryParse(_a, out tmpA) && double.TryParse(_b, out tmpB))
                return (Math.Pow(tmpA,tmpB)).ToString();
            else
                return "Error ^";
        }
        public static string Root(string _a, string _b)
        {
            double tmpA;
            double tmpB;
            if (double.TryParse(_a, out tmpA) && double.TryParse(_b, out tmpB))
                return (Math.Pow(tmpA, 1/tmpB)).ToString();
            else
                return "Error Root";
        }
        public static string Sin(string _a)
        {
            double tmpA;
            if (double.TryParse(_a, out tmpA))
                return (Math.Sin(tmpA)).ToString();
            else
                return "Error Sin";
        }
        public static string Cos(string _a)
        {
            double tmpA;
            if (double.TryParse(_a, out tmpA))
                return (Math.Cos(tmpA)).ToString();
            else
                return "Error Cos";
        }
        public static string Tan(string _a)
        {
            double tmpA;
            if (double.TryParse(_a, out tmpA))
                return (Math.Tan(tmpA)).ToString();
            else
                return "Error Tan";
        }
        public static string Equals(string input)
        {
            Operation operation = new Operation(input);
            return operation.Calculate();
        }

        public static string Reversed(string input)
        {
            double tmpA;
            if (double.TryParse(Equals(input), out tmpA))
            {
                if (tmpA != 0)
                    return (1 / tmpA).ToString();
                else
                    return "division by 0";
            }
            else
                return "Error Reverse";
        }
        public static string Sqrt(string _a)
        {
            double tmpA;
            if (double.TryParse(_a, out tmpA))
                return (Math.Pow(tmpA,0.5)).ToString();
            else
                return "Error Sqrt";
        }
        public static string Pow2(string _a)
        {
            double tmpA;
            if (double.TryParse(_a, out tmpA))
                return (Math.Pow(tmpA,2)).ToString();
            else
                return "Error Pow2";
        }
        public static string Negative(string input)
        {
            double tmpA;
            if (double.TryParse(Equals(input), out tmpA))
            {
                return (-1 * tmpA).ToString();
            }
            else
                return "Error Negative";
        }
    }
}
