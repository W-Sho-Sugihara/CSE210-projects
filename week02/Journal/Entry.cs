using System;

public class Entry
{
    string _date;
    string _promptText;
    string _entryText;

    public void Display()
    {
        Console.WriteLine($"Question: {_promptText}");
        Console.WriteLine($"{_entryText}");
    }
}