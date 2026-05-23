public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitText = text.Split(" ");
        foreach(var word in splitText)
        {
            AddWord(word);
        }
    }
    private void AddWord(string word)
    {
         _words.Add(new Word(word));
    }
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(Word => Word.GetDisplayText()));
    }
    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<int> indexes = Enumerable.Range(0, _words.Count)
                                    .Where(i => !_words[i].IsHidden())
                                    .OrderBy(i => random.Next())
                                    .Take(count)
                                    .ToList();
        foreach (int index in indexes)
        {
            _words[index].Hide();
        }
    }
    public void ResetHiddenWords()
    {
        foreach(var word in _words)
        {
            word.Show();
        }
    }
}