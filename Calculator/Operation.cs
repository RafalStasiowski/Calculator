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
    class Operation
    {
        private List<string> elements = new List<string>();
        
        public Operation(string operation)
        {
            elements = Split(operation);
            Validate();
        }

        /*
         * Split(string operation)
         * method that split input string into single elements that will be calculated,
         * and return List of strings that contain those elements
         */
        private List<string> Split(string operation)
        {
            List<string> splitted = new List<string>();
            string toSplitted = "";
            for (int i = 0; i < operation.Length; i++) 
            {

                if (operation[i] == '+')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "+");
                }
                else if (operation[i] == '-')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "-");
                }
                else if (operation[i] == '*')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "*");
                }
                else if (operation[i] == '/')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "/");
                }
                else if (operation[i] == '(')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "(");
                }
                else if (operation[i] == ')' && i - 1 > 0)
                {
                    AddToSplitted(ref toSplitted, ref splitted, ")");
                }
                else if (operation[i] == '^')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "^");
                }
                else if (i + 3 < operation.Length && operation[i] == 'S' && operation[i + 1] == 'q' && operation[i + 2] == 'r' && operation[i + 3] == 't')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "Sqrt");
                    i += 3;
                }
                else if (i + 3 < operation.Length && operation[i] == 'R' && operation[i + 1] == 'o' && operation[i + 2] == 'o' && operation[i + 3] == 't')
                {                  
                    AddToSplitted(ref toSplitted, ref splitted, "Root");
                    i += 3;
                }
                else if (i + 2 < operation.Length && operation[i] == 'C' && operation[i + 1] == 'o' && operation[i + 2] == 's')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "Cos");
                    i += 2;
                }
                else if (i + 2 < operation.Length && operation[i] == 'S' && operation[i + 1] == 'i' && operation[i + 2] == 'n')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "Sin");
                    i += 2;
                }
                else if (i + 2 < operation.Length && operation[i] == 'T' && operation[i + 1] == 'a' && operation[i + 2] == 'n')
                {
                    AddToSplitted(ref toSplitted, ref splitted, "Tan");
                    i += 2;
                }
                else
                {
                    toSplitted += operation[i];
                }
                
            }
            if(toSplitted.Length>0)
                splitted.Add(toSplitted);

            return splitted;
        }
        /*
         * Valid(string s)
         * Valid2(string s)
         * Valid3(string s)
         * Those methods are use for check what is string on the input and return bool value.
         * Used for check what kind of operator is in input string
         */
        private bool Valid(string s)
        {
            if (s == "(")
                return true;
            else
                return false;
        }
        private bool Valid2(string s)
        {
            if (s == "Sin" || s == "Cos" || s == "Tan" || s == "Sqrt")
                return true;
            else
                return false;
        }
        private bool Valid3(string s)
        {
            if (s == "+" || s == "-" || s == "*" || s == "/" || s == "^" || s == "Root")
                return true;
            else
                return false;
        }

        /*
         * AddToSplitted(ref string toSplitted, ref List<string> splitted, string character)
         * Procedure that add element to list
         * Used in split() method
         */
        private void AddToSplitted(ref string toSplitted, ref List<string> splitted, string character)
        {
            if (toSplitted.Length > 0)
            {
                splitted.Add(toSplitted);
                toSplitted = "";
            }
            splitted.Add(character);
        }

        /*
         * Validate()
         * Procedure that check, and modificate input string, to make sure that input will be valid
         * for the rest of the methods
         */
        private void Validate()
        {
            if (elements.Count > 0)
            {
                if (Valid3(elements[0]))
                {
                    elements.Insert(0, "0");
                }
                if (Valid3(elements[elements.Count - 1]) || Valid2(elements[elements.Count - 1]))
                {
                    elements.Add("0");
                }
                for (int i = elements.Count - 1; i > 0; i--) 
                {
                    if(Valid3(elements[i]) && Valid3(elements[i - 1]))
                    {
                        elements.Insert(i,"0");
                    }
                }
                for (int i = 0; i < elements.Count - 1; i++)
                {
                    if ((Valid2(elements[i + 1]) && !Valid3(elements[i]) && !Valid2(elements[i])) || (Valid(elements[i + 1]) && !Valid2(elements[i])) && !Valid3(elements[i]))
                    {
                        elements.Insert(i + 1, "*");
                    }                    
                }
                for (int i = 0; i < elements.Count - 1; i++)
                {
                    if (Valid2(elements[i]) && Valid3(elements[i + 1]))
                    {
                        elements[i] = "0";
                    }
                }
            }            
        }
        /*
         * FindEndBracket(int index)
         * Method that find, and return index of end bracket
         */
        private int FindEndBracket(int index)
        {
            int counter = 0;
            for (int i = index + 1; i < elements.Count; i++)
            {
                if (elements[i] == "(")
                {
                    counter++;
                }
                else if (elements[i] == ")" && counter == 0)
                {
                    return i;
                }
                else if (elements[i] == ")" && counter > 0)
                {
                    counter--;
                }
            }
            return index;
        }
        /*
         * SetOperationOrder()
         * Method that return index of next operator to compute
         */
        private int SetOperationOrder()
        {
            for (int i = elements.Count - 1; i >= 0; i--) 
            {
                if (elements[i] == "Sin" || elements[i] == "Cos" || elements[i] == "Tan" || elements[i] == "Sqrt")
                    return i;
            }
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                if (elements[i] == "^" || elements[i] == "Root")
                    return i;
            }
            for (int i = 0; i < elements.Count; i++) 
            {
                if (elements[i] == "/" || elements[i] == "*")
                    return i;
            }
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == "+" || elements[i] == "-")
                    return i;
            }
            for (int i = 0; i < elements.Count - 1; i++)
            {
                if (Valid2(elements[i + 1]) && !Valid3(elements[i]))
                {
                    elements.Insert(i + 1, "*");
                }
            }
            return -1;
        }
        private static bool IsEmpty(string s)
        {
            if (s == "")
                return true;
            else
                return false;
        }
        /*
         * Calculate()
         * Method that do all calculation and return string with result
         */
        public string Calculate()
        {
            List<int> toDelete = new List<int>();
            while (elements.Count > 1)
            {
                
                for (int i = 0; i < elements.Count - 1; i++) 
                {
                    if(elements[i] == "(")
                    {
                        if (elements[i + 1] == ")") 
                        {
                            elements[i] = "0";
                            elements[i + 1] = "";
                        }
                        else
                        {
                            int endBracket = FindEndBracket(i);
                            string toCalculate = "";
                            for (int j = i + 1; j < endBracket; j++) 
                            {
                                toCalculate += elements[j];
                                elements[j] = "";
                            }
                            elements[endBracket] = "";
                            
                            Operation recursiveOperation = new Operation(toCalculate);
                            elements[i] = recursiveOperation.Calculate();

                        }     
                    }
                }
                elements.RemoveAll(IsEmpty);
                int p = SetOperationOrder();

                while (p >= 0) 
                {
                    if (elements[p] == "+")
                    {            
                        elements[p] = Calculations.Add(elements[p - 1], elements[p + 1]);
                        elements[p - 1] = "";
                        elements[p + 1] = "";
                    }            
                    else if (elements[p] == "-")
                    {            
                        elements[p] = Calculations.Substract(elements[p - 1], elements[p + 1]);
                        elements[p - 1] = "";
                        elements[p + 1] = "";
                    }            
                    else if (elements[p] == "*")
                    {            
                        elements[p] = Calculations.Multiply(elements[p - 1], elements[p + 1]);
                        elements[p - 1] = "";
                        elements[p + 1] = "";
                    }            
                    else if (elements[p] == "/")
                    {            
                        elements[p] = Calculations.Divide(elements[p - 1], elements[p + 1]);
                        elements[p - 1] = "";
                        elements[p + 1] = "";
                    }
                    else if (elements[p] == "^")
                    {
                        elements[p] = Calculations.Pow(elements[p - 1], elements[p + 1]);
                        elements[p - 1] = "";
                        elements[p + 1] = "";
                    }
                    else if (elements[p] == "Root")
                    {
                        elements[p] = Calculations.Root(elements[p - 1], elements[p + 1]);
                        elements[p - 1] = "";
                        elements[p + 1] = "";
                    }
                    else if (elements[p] == "Sqrt")
                    {
                        elements[p] = Calculations.Sqrt(elements[p + 1]);
                        elements[p + 1] = "";
                    }
                    else if (elements[p] == "Sin")
                    {
                        elements[p] = Calculations.Sin(elements[p + 1]);
                        elements[p + 1] = "";
                    }
                    else if (elements[p] == "Cos")
                    {
                        elements[p] = Calculations.Cos(elements[p + 1]);
                        elements[p + 1] = "";
                    }
                    else if (elements[p] == "Tan")
                    {
                        elements[p] = Calculations.Tan(elements[p + 1]);
                        elements[p + 1] = "";
                    }
                    else
                    {
                        string result = "";
                        for (int i = 0; i < elements.Count; i++) 
                        {
                            result += elements[0];
                            elements[i] = "";
                        }
                        elements[0] = result;
                    }
                    elements.RemoveAll(IsEmpty);
                    p = SetOperationOrder();
                }
                
            }
            
            if (elements.Count > 0)
            {
                return elements[0];
            }
                
            else
                return "0";
        }
    }
}
