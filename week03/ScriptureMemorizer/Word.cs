public class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Word cannot be null or empty.", nameof(input));

        _text = input.Trim();
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        } else
        {
            return _text;
        }
    }

}