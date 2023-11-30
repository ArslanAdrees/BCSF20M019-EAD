using System;

// Context
class Context
{
    private string input;

    public Context(string input)
    {
        this.input = input;
    }

    public string Input
    {
        get { return input; }
        set { input = value; }
    }
}

// AbstractExpression
interface IExpression
{
    bool Interpret(Context context);
}

// TerminalExpression
class TerminalExpression : IExpression
{
    private string literal;

    public TerminalExpression(string literal)
    {
        this.literal = literal;
    }

    public bool Interpret(Context context)
    {
        return context.Input.Contains(literal);
    }
}

// NonTerminalExpression
class AndExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public AndExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public bool Interpret(Context context)
    {
        return left.Interpret(context) && right.Interpret(context);
    }
}

class OrExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public OrExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public bool Interpret(Context context)
    {
        return left.Interpret(context) || right.Interpret(context);
    }
}

class Program
{
    static void Main()
    {
        Context context = new Context("Hello, World!");

        IExpression expression1 = new TerminalExpression("Hello");
        IExpression expression2 = new TerminalExpression("World");
        IExpression expression3 = new TerminalExpression("Goodbye");

        IExpression orExpression = new OrExpression(expression1, expression3);
        IExpression andExpression = new AndExpression(orExpression, expression2);

        bool result = andExpression.Interpret(context);

        Console.WriteLine($"Result: {result}");
    }
}
