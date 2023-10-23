using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static double stringSolve(string expression)
        {
            expression = expression.Replace(" ", "");  // remove extra spaces from expression
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
                        throw new ArgumentException("Unmatched parentheses!");
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
                throw new ArgumentException("Invalid expression.");
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
                    throw new DivideByZeroException("Division by zero error!");
                }
                result = leftOperand / rightOperand;
            }

            values.Push(result);
        }

    //--------------------------------------------------------
    string expression;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
            expression = textBox1.Text;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
            expression = textBox1.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
            expression = textBox1.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
            expression = textBox1.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
            expression =textBox1.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
            expression = textBox1.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
            expression =textBox1.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
            expression = textBox1.Text;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
            expression =textBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
            expression = textBox1.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
            expression =textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
            expression = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/";
            expression =textBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
            expression =textBox1.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
            expression =textBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                expression = textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            expression = textBox1.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
            try
            {
                textBox1.Text = stringSolve(expression).ToString();
            }
            catch (Exception m)
            {
                if (m.Message == "Division by zero error!")
                {
                    textBox1.Text = m.Message;
                }
                else
                {
                    textBox1.Text = "Invalid expression!";
                }
                
            }
        }
    }
}
