using System;
using System.Collections.Generic;

namespace EAD_Assignment04
{
    class Program
    {
        public static double stringSolve(string expression)
        {
            expression = expression.Replace(" ", ""); // remove extra spaces from expression
            return EvaluateExpression(expression);
        }

        private static double EvaluateExpression(string expression)
        {
            Stack<double> values = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c) || c == '.')
                {
                    int endIndex = i;
                    while (endIndex < expression.Length && (char.IsDigit(expression[endIndex]) || expression[endIndex] == '.'))
                    {
                        endIndex++;
                    }
                    string numStr = expression.Substring(i, endIndex - i);
                    double num = double.Parse(numStr);
                    values.Push(num);
                    i = endIndex - 1; // Skip the digits
                }
                else if (c == '(')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        ApplyOperation(values, operators);
                    }
                    if (operators.Count == 0 || operators.Pop() != '(')
                    {
                        throw new ArgumentException();
                    }
                }
                else if (IsOperator(c))
                {
                    while (operators.Count > 0 && HasPrecedence(operators.Peek(), c))
                    {
                        ApplyOperation(values, operators);
                    }
                    operators.Push(c);
                }
            }

            while (operators.Count > 0)
            {
                ApplyOperation(values, operators);
            }

            if (values.Count != 1 || operators.Count != 0)
            {
                throw new ArgumentException();
            }

            return values.Pop();
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private static bool HasPrecedence(char op1, char op2)
        {
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            { 
                return true; 
            }
            return false;
        }

        private static void ApplyOperation(Stack<double> values, Stack<char> operators)
        {
            char op = operators.Pop();
            double rightOperand = values.Pop();
            double leftOperand = values.Pop();
            double result = 0.0;

            if (op == '+')
            {
                result = leftOperand + rightOperand;
            }
            else if (op == '-')
            {
                result = leftOperand - rightOperand;
            }
            else if (op == '*')
            {
                result = leftOperand * rightOperand;
            }
            else if (op == '/')
            {
                if (rightOperand == 0)
                {
                    Console.WriteLine("Division by zero is not allowed.");
                    throw new DivideByZeroException();
                }
                result = leftOperand / rightOperand;
            }

            values.Push(result);
        }

        static void Main()
        {
            string choice;
            do
            {
                Console.Write("Enter an expression: ");
                string expression = Console.ReadLine();
                try
                {
                    double result = stringSolve(expression);
                    Console.WriteLine("Input: " + expression);
                    Console.WriteLine("Output: " + result);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid expression.");
                }
                Console.Write("Do you want to run it again(y/n): ");
               choice= Console.ReadLine();
            } while (choice=="Y"||choice=="y");

        }
    }

}