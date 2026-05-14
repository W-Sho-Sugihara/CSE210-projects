using System;

class Journal
{
    List<Entry> _entries = [];

    void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    void DeleteEntry(int entryNumber)
    {
        _entries.RemoveAt(entryNumber - 1); // -1 so it matches the index because the entries will be displayed starting at #1
    }
    void DisplayAll()
    {
        for (int i = 0; i < _entries.Count; i++)
            {
                Console.WriteLine($"#{i + 1}.");
                _entries[i].Display();
            }
    }
    void SaveToFile(string fileName)
    {
        
    }
    void LoadFromFile(string fileName)
    {
        
    }
}