public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public abstract void RecordEvent();
    public abstract string GetDetailsString();
    public abstract bool IsComplete();
    public abstract int GetPoints();
    public abstract void SaveToFile();
    public virtual string GetStringRepresentation()
    {
        return $"{_name},{_description},{_points}";
    }
    public string Name()
    {
        return _name;
    }
}