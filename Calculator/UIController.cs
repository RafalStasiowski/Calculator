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
    static class UIController
    {

        public static void AddToLabel(ref Label label, string input)
        {
            label.Content += input;
        }
        public static void ClearLabel(ref Label label)
        {
            label.Content = "";
        }
        public static void ValidInput(ref Label label)
        {
            string content = label.Content.ToString();
            if (content == "division by 0" ||
                       content == "Error +" ||
                       content == "Error -" ||
                       content == "Error *" ||
                       content == "Error /" ||
                       content == "Error ^" ||
                       content == "Error Root" ||
                       content == "Error Sqrt" ||
                       content == "Error Sin" ||
                       content == "Error Cos" ||
                       content == "Error Tan" ||
                       content == "Error Pow2" ||
                       content == "Error Reverse" ||
                       content == "Error Negative")
            {
                label.Content = "";
            }
            if(content == "0")
            {
                label.Content = "";
            }

        }
        public static void RemoveFromLabel(ref Label label)
        {
            string content = label.Content.ToString();
            if(content.Length > 0)
            {                               
                if (content.Length >= 3)
                {
                    if (content[content.Length - 3] == 'S' &&
                        content[content.Length - 2] == 'i' &&
                        content[content.Length - 1] == 'n')
                    {
                        label.Content = content.Remove(content.Length - 3, 3);
                    }
                    else if (content[content.Length - 3] == 'C' &&
                        content[content.Length - 2] == 'o' &&
                        content[content.Length - 1] == 's')
                    {
                        label.Content = content.Remove(content.Length - 3, 3);
                    }
                    else if (content[content.Length - 3] == 'T' &&
                        content[content.Length - 2] == 'a' &&
                        content[content.Length - 1] == 'n')
                    {
                        label.Content = content.Remove(content.Length - 3, 3);
                    }
                    else if (content[content.Length - 3] == 'S' &&
                        content[content.Length - 2] == 'i' &&
                        content[content.Length - 1] == 'n')
                    {
                        label.Content = content.Remove(content.Length - 3, 3);
                    }
                    else if (content.Length >= 4 &&
                        content[content.Length - 4] == 'S' &&
                        content[content.Length - 3] == 'q' &&
                        content[content.Length - 2] == 'r' &&
                        content[content.Length - 1] == 't')
                    {
                        label.Content = content.Remove(content.Length - 4, 4);
                    }
                    else if (content.Length >= 4 &&
                        content[content.Length - 4] == 'R' &&
                        content[content.Length - 3] == 'o' &&
                        content[content.Length - 2] == 'o' &&
                        content[content.Length - 1] == 't')
                    {
                        label.Content = content.Remove(content.Length - 4, 4);
                    }
                    else
                    {
                        label.Content = content.Remove(content.Length - 1, 1);
                    }
                }
                else
                {
                    label.Content = content.Remove(content.Length - 1, 1);
                }
            }
            
        }

        public static void SetLabel(ref Label label, string input)
        {
            label.Content = input;
        }
    }
}
