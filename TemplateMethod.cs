using System;

abstract class DataProcessor
{
    // Template method
    public void ProcessData()
    {
        ReadData();
        TransformData();
        DisplayData();
    }

    protected abstract void ReadData();
    protected abstract void TransformData();
    protected abstract void DisplayData();
}

// ConcreteClass implementing the template method
class CsvDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from CSV file");
    }

    protected override void TransformData()
    {
        Console.WriteLine("Transforming CSV data");
    }

    protected override void DisplayData()
    {
        Console.WriteLine("Displaying CSV data");
    }
}

// Another ConcreteClass
class XmlDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from XML file");
    }

    protected override void TransformData()
    {
        Console.WriteLine("Transforming XML data");
    }

    protected override void DisplayData()
    {
        Console.WriteLine("Displaying XML data");
    }
}

class Program
{
    static void Main()
    {
        DataProcessor csvProcessor = new CsvDataProcessor();
        csvProcessor.ProcessData();

        Console.WriteLine();

        DataProcessor xmlProcessor = new XmlDataProcessor();
        xmlProcessor.ProcessData();
    }
}

