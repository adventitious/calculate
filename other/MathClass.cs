using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MathClass
    {
        public static List<Element> SimplifyElements(List<Element> elements)
        {

            // 3, +, 4, s, 5, *, 7  =  7, s, 35
            // 3, *, 4, s, 5, +, 7  = 12, s, 13
            // 3, *, 4, -, 5, +, 9  = 2,

            return null;
        }

        public static string SimplifyString(string inputSum)
        {
            string output = "";
            output = calcLong(inputSum);
            return output;
        }

        public static string calcShort(string input)
        {
            string output = "8";

            List<Element> elems = new List<Element>();

            elems = Element.StringToElements(input);
            elems = MulltiplyElements(elems);
            elems = DivideElements(elems);
            elems = AddElements(elems);
            elems = SubtractElements(elems);
            Console.WriteLine(Element.ElementsToString(elems));

            return elems[0].Content;
        }

        public static List<Element> MulltiplyElements(List<Element> elements)
        {
            for (int i = 0; i < elements.Count; i++) // Loop through List with for
            {
                if (elements[i].EType == "operand" && elements[i].Content == "*")
                {
                    // i = 1,
                    double leftSide = double.Parse(elements[i - 1].Content);
                    double rightSide = double.Parse(elements[i + 1].Content);
                    double product = leftSide * rightSide;
                    Console.WriteLine(product);
                    elements[i + 1] = new Element("number", "" + product);
                    elements.RemoveAt(i - 1);
                    elements.RemoveAt(i - 1);
                    i--;
                }
            }
            return elements;
        }

        public static List<Element> DivideElements(List<Element> elements)
        {
            for (int i = 0; i < elements.Count; i++) // Loop through List with for
            {
                if (elements[i].EType == "operand" && elements[i].Content == "/")
                {
                    // i = 1,
                    double leftSide = double.Parse(elements[i - 1].Content);
                    double rightSide = double.Parse(elements[i + 1].Content);
                    double product = leftSide / rightSide;
                    Console.WriteLine(product);
                    elements[i + 1] = new Element("number", "" + product);
                    elements.RemoveAt(i - 1);
                    elements.RemoveAt(i - 1);
                    i--;
                }
            }
            return elements;
        }

        public static List<Element> AddElements(List<Element> elements)
        {
            for (int i = 0; i < elements.Count; i++) // Loop through List with for
            {
                if (elements[i].EType == "operand" && elements[i].Content == "+")
                {
                    // i = 1,
                    double leftSide = double.Parse(elements[i - 1].Content);
                    double rightSide = double.Parse(elements[i + 1].Content);
                    double product = leftSide + rightSide;
                    Console.WriteLine(product);
                    elements[i + 1] = new Element("number", "" + product);
                    elements.RemoveAt(i - 1);
                    elements.RemoveAt(i - 1);
                    i--;
                }
            }
            return elements;
        }

        public static List<Element> SubtractElements(List<Element> elements)
        {
            for (int i = 0; i < elements.Count; i++) // Loop through List with for
            {
                if (elements[i].EType == "operand" && elements[i].Content == "-")
                {
                    // i = 1,
                    double leftSide = double.Parse(elements[i - 1].Content);
                    double rightSide = double.Parse(elements[i + 1].Content);
                    double product = leftSide - rightSide;
                    Console.WriteLine(product);
                    elements[i + 1] = new Element("number", "" + product);
                    elements.RemoveAt(i - 1);
                    elements.RemoveAt(i - 1);
                    i--;
                }
            }
            return elements;
        }


        static string calcLong(string input)
        {
            // look for openBr, look for closeBr
            // if openBr in tempSubS between openBr and closeBr, skip
            // else, is the subS

            bool hasBrakets = true;

            while (hasBrakets == true)
            {
                int openB = -1;
                int closeB = -1;
                int openC = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '(')
                    {
                        if (openB == -1)
                        {
                            openB = i;
                        }
                        openC++;
                    }
                    if (input[i] == ')')
                    {
                        if (openC == 1)
                        {
                            closeB = i;
                        }
                        else
                        {
                            openC--;
                        }
                    }
                }

                if (openB == -1 && closeB == -1)
                {
                    hasBrakets = false;
                    string s1 = calcShort(input);  // string with no brackets
                    return s1;
                }
                else
                {
                    string preBraket = input.Substring(0, openB);
                    string inBraket = input.Substring(openB + 1, closeB - openB - 1);
                    string postBraket = input.Substring(closeB + 1);

                    string sumInBracket = calcLong(inBraket);

                    input = preBraket + sumInBracket + postBraket;
                }
            }
            return "";
        }


    }


    class Element
    {
        private string eType;
        private string content;

        public string EType { get => eType; set => eType = value; }
        public string Content { get => content; set => content = value; }

        public Element(string argEType, string argContent)
        {
            EType = argEType;
            Content = argContent;
        }

        public static List<Element> StringToElements(string input)
        {
            // turn 4+33*5unknown8 to 4,33,*,5,unknown,8

            List<Element> elements = new List<Element>();

            string partEl = "";
            string partElType = "";
            /*
            if type != partElType
                if partEl != ""
                    add new element partEl
                partEl = ichar
                partElType = ichar type
            else
                partEl = partEl + ichar
                     */
            for (int i = 0; i < input.Length; i++)
            {
                string charType = GetCharType(input[i]);
                if (charType != partElType)
                {
                    if (partEl != "")
                    {
                        elements.Add(new Element(partElType, partEl));
                    }
                    partEl = "" + input[i];
                    partElType = charType;
                }
                else
                {
                    partEl = partEl + input[i];
                }
            }
            if (partEl != "")
            {
                elements.Add(new Element(partElType, partEl));
            }
            return elements;
        }


        private static string GetCharType(char c)
        {
            if (IsOperand(c))
                return "operand";
            if (IsInteger(c))
                return "number";
            return "unknown";
        }


        private static bool IsOperand(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                return true;
            }
            return false;
        }


        private static bool IsInteger(char c)
        {
            if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4')
                return true;

            if (c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                return true;

            return false;
        }

        public static string ElementsToString(List<Element> elements)
        {
            string output = "";
            for (int i = 0; i < elements.Count; i++) // Loop through List with for
            {
                output = output + elements[i].ToString() + "\n";
            }
            return output;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", base.ToString(), EType, Content);
        }
    }


}
