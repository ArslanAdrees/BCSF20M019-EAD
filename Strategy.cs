using System;

// Strategy interface
interface ICompressionStrategy
{
    void Compress(string fileName);
}

// ConcreteStrategy
class ZipCompressionStrategy : ICompressionStrategy
{
    public void Compress(string fileName)
    {
        Console.WriteLine($"Compressing {fileName} using Zip");
    }
}

// Another ConcreteStrategy
class RarCompressionStrategy : ICompressionStrategy
{
    public void Compress(string fileName)
    {
        Console.WriteLine($"Compressing {fileName} using Rar");
    }
}

// Context
class CompressionContext
{
    private ICompressionStrategy _compressionStrategy;

    public CompressionContext(ICompressionStrategy compressionStrategy)
    {
        _compressionStrategy = compressionStrategy;
    }

    public void SetCompressionStrategy(ICompressionStrategy compressionStrategy)
    {
        _compressionStrategy = compressionStrategy;
    }

    public void CompressFile(string fileName)
    {
        _compressionStrategy.Compress(fileName);
    }
}

class Program
{
    static void Main()
    {
        ICompressionStrategy zipStrategy = new ZipCompressionStrategy();
        ICompressionStrategy rarStrategy = new RarCompressionStrategy();

        CompressionContext context = new CompressionContext(zipStrategy);
        context.CompressFile("document.txt");

        context.SetCompressionStrategy(rarStrategy);
        context.CompressFile("image.png");
    }
}

