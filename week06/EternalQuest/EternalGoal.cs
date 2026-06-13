public class  EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        
    }
    public override bool IsComplete()
    {
        return false; // Always false due to its never ending eternal nature of the goal
    }
    public override string GetDetailsString()
    {
        return $"[∞] {_name} ({_description})";
    }

    public override int GetPoints() => _points;
    public static EternalGoal LoadFromString(string line)
    {
        string[] parts = line.Split(',');
        string name = parts[0];
        string desc = parts[1];
        int pts = int.Parse(parts[2]);
        return new EternalGoal(name, desc, pts);
    }
    public override void SaveToFile()
    {
        using StreamWriter writer = new("EternalGoal.txt", append: true);
        writer.WriteLine(GetStringRepresentation());
    }
}