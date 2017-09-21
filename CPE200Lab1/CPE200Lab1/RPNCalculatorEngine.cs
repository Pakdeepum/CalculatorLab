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
            Stack<string> stackCheck = new Stack<string>();
            string result;
            int Numcount=0;
            int opercount=0;
            string firstOperand, secondOperand;
            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    Numcount++;
                }
                else if (isOperator(token))
                {
                    opercount++;
                }
            }
            foreach (string token in parts)
            {
                if (Numcount == 1 && opercount == 0)
                {
                    return token;
                }
                else if (opercount < 1 || Numcount <= 0 || opercount >= Numcount || opercount < (Numcount - 1)||parts[0]=="+")
                {
                    return "E";
                }
                else if (!isNumber(token) && !isOperator(token))
                {
                    stackCheck.Push(token);
                }
                else if (isNumber(token))
                {
                   
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    if (rpnStack == null)
                    {
                        return "E";
                    }

                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 6);
                    if (stackCheck.Count() != 0) return "E";

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
