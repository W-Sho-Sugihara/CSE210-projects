using System.IO;

class Journal
{
    List<Entry> _entries = [];

    public void AddEntry(string date, string prompt, string entryText)
    {
        Entry newEntry = new()
        {
            _date = date,
            _promptText = prompt,
            _entryText = entryText
        };

        _entries.Add(newEntry);
    }
    public void EditEntry(int entryNumber, string entryText)
    {
          _entries[entryNumber - 1]._entryText = entryText; // -1 so it matches the index because the entries will be displayed starting at #1
    }
    public void DeleteEntry(int entryNumber)
    {
        _entries.RemoveAt(entryNumber - 1); // -1 so it matches the index because the entries will be displayed starting at #1
    }
    public void DisplayAll()
    {
        for (int i = 0; i < _entries.Count; i++)
            {
                Console.WriteLine($"Entry #{i + 1}.");
                _entries[i].Display();
            }
    }
    public void SaveToFile(string givenFileName)
    {
        string fileName = givenFileName;
        using StreamWriter outputFile = new(fileName);
        foreach (var entry in _entries)
        {
            outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
        }
    }
    public void LoadFromFile(string fileName)
    {
        _entries.Clear();
        using StreamReader loadingFile = new(fileName);
        string line  = loadingFile.ReadLine();
        while (line != null)
        {
            string[] parts = line.Split('|');
            Entry entry = new()
            {
                _date = parts[0],
                _promptText = parts[1],
                _entryText = parts[2]
            };
            _entries.Add(entry);
            line = loadingFile.ReadLine();
        }
    }
}