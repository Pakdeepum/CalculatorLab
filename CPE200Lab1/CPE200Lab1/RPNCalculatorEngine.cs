using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == null || str == "") return "E";
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            double Numcount=0;
            double opercount=0;
            string firstOperand, secondOperand;
            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    Numcount++;
                }
                if (isOperator(token))
                {
                    opercount++;
                }

                if (opercount < 0||Numcount <= 0|| opercount>=Numcount)
                {
                    return "E";
                }
            }
            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    
                    //FIXME, what if there is only one left in stack?
                    if(rpnStack == null)
                    {
                        return "E";
                    }
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 6);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            result = rpnStack.Pop();
            return result;
        }
    }
}
