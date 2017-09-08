using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class rpnCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            string result = "Zero.";
            Stack<string> NumList = new Stack<string>();
            string[] parts = str.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    NumList.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    string second = NumList.Pop().ToString();
                    string first = NumList.Pop().ToString();
                    result = calculate(parts[i], first, second);
                    NumList.Push(result);
                }
            }
            return NumList.Pop().ToString();
        }
    }
}
