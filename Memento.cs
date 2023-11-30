using System;

// Memento
class EditorMemento
{
    public string Text { get; private set; }

    public EditorMemento(string text)
    {
        Text = text;
    }
}

// Originator
class TextEditor
{
    private string text;

    public string Text
    {
        get { return text; }
        set
        {
            text = value;
            Console.WriteLine($"Editor text set to: {value}");
        }
    }

    public EditorMemento Save()
    {
        Console.WriteLine("Saving editor state");
        return new EditorMemento(text);
    }

    public void Restore(EditorMemento memento)
    {
        text = memento.Text;
        Console.WriteLine($"Restored editor state to: {memento.Text}");
    }
}

// Caretaker
class TextEditorHistory
{
    public EditorMemento Memento { get; set; }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();
        TextEditorHistory history = new TextEditorHistory();

        editor.Text = "First line of text";
        history.Memento = editor.Save();

        editor.Text = "Modified text";
        editor.Restore(history.Memento);
    }
}
