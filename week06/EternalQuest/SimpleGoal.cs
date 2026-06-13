public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    } 
    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override int GetPoints() => _isComplete ? 0 : _points;
    public override string GetDetailsString()
    {
        string checkmark = _isComplete ? "[X]" : "[ ]";
        return $"{checkmark} {_name} ({_description})";
    }
    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{_isComplete}";
    }
    public static SimpleGoal LoadFromString(string line)
    {
        string[] parts = line.Split(',');
        string name = parts[0];
        string desc = parts[1];
        int pts = int.Parse(parts[2]);
        bool done = bool.Parse(parts[3]);
        SimpleGoal goal = new(name, desc, pts);
        if (done) goal.RecordEvent();
        return goal;
    }
    public override void SaveToFile()
    {
        using StreamWriter writer = new("SimpleGoal.txt", append: true);
        writer.WriteLine(GetStringRepresentation());    }
}