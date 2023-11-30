using System;
using System.Collections.Generic;

// Visitor interface
interface IVisitor
{
    void Visit(Circle circle);
    void Visit(Triangle triangle);
}

// Element interface
interface IShape
{
    void Accept(IVisitor visitor);
}

// ConcreteElement
class Circle : IShape
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

// Another ConcreteElement
class Triangle : IShape
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Draw()
    {
        Console.WriteLine("Drawing a Triangle");
    }
}

// ConcreteVisitor
class DrawingVisitor : IVisitor
{
    public void Visit(Circle circle)
    {
        Console.WriteLine("DrawingVisitor draws a Circle");
        circle.Draw();
    }

    public void Visit(Triangle triangle)
    {
        Console.WriteLine("DrawingVisitor draws a Triangle");
        triangle.Draw();
    }
}

// ObjectStructure
class DrawingBoard
{
    private readonly List<IShape> shapes = new List<IShape>();

    public void AddShape(IShape shape)
    {
        shapes.Add(shape);
    }

    public void RemoveShape(IShape shape)
    {
        shapes.Remove(shape);
    }

    public void DrawShapes(IVisitor visitor)
    {
        foreach (var shape in shapes)
        {
            shape.Accept(visitor);
        }
    }
}

class Program
{
    static void Main()
    {
        DrawingBoard drawingBoard = new DrawingBoard();

        drawingBoard.AddShape(new Circle());
        drawingBoard.AddShape(new Triangle());

        DrawingVisitor drawingVisitor = new DrawingVisitor();

        drawingBoard.DrawShapes(drawingVisitor);
    }
}
