public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
                            int requiredCount, int bonusPoints, int timesCompleted = 0)
            : base(name, description, points)
        {
            _requiredCount = requiredCount;
            _bonusPoints = bonusPoints;
            _timesCompleted = timesCompleted;
        }

    public override bool IsComplete() 
    {
        return _timesCompleted >= _requiredCount;
    }
    public override void RecordEvent()
    {
        if (!IsComplete())
            _timesCompleted++;
    }
    public override string GetDetailsString()
    {
        string checkmark = IsComplete() ? "[X]" : "[ ]";
        return $"{checkmark} {_name} ({_description}) -- completed {_timesCompleted}/{_requiredCount} times";
    }
    public override int GetPoints()
    {
        if (IsComplete() && _timesCompleted == _requiredCount)
        {
            return _points + _bonusPoints;
        }
        else if (IsComplete())
        {
            return 0;
        } 
        else
        {
            return _points;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{_requiredCount},{_bonusPoints},{_timesCompleted}";
    }
    public static ChecklistGoal LoadFromString(string line)
    {
        string[] parts = line.Split(',');
        string name = parts[0];
        string desc = parts[1];
        int pts   = int.Parse(parts[2]);
        int req   = int.Parse(parts[3]);
        int bonus = int.Parse(parts[4]);
        int times = int.Parse(parts[5]);
        return new ChecklistGoal(name, desc, pts, req, bonus, times);
    }
    public override void SaveToFile()
    {
        using StreamWriter writer = new("ChecklistGoal.txt", append: true);
        writer.WriteLine(GetStringRepresentation());
    }
}