public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private DateOnly _lastSavedDate;
    private List<(DateOnly date, int score)> _scoreHistory = new();
    public GoalManager()
    {
        _goals = [];
        _score = 0;
    }
    public void Start()
    {
        LoadGoals();
        LoadCurrentScore();

        bool running = true;
        while (running)
        {
            //Console.WriteLine($"\nYou have {_score} points as of {_lastSavedDate}.\n");
            Console.WriteLine($"\nScore: {_score}\n");
            DisplayMenu();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": DisplayPlayerHistory();  break;
                case "2": ListGoalNames();      break;
                case "3": ListGoalDetails();    break;
                case "4": CreateGoal();         break;
                case "5": RecordEvent();        break;
                case "6": SaveGoals();          break;
                case "7": running = false;      break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
    private void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Show player score history");
        Console.WriteLine("  2. List goal names");
        Console.WriteLine("  3. List goal details");
        Console.WriteLine("  4. Create new goal");
        Console.WriteLine("  5. Record event");
        Console.WriteLine("  6. Save goals");
        Console.WriteLine("  7. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public void DisplayPlayerHistory()
    {
        int completedGoals = 0;
        foreach (Goal goal in _goals)
            if (goal.IsComplete())
                completedGoals++;

        Console.WriteLine($"\nScore history:");
        foreach ((DateOnly date, int score) in _scoreHistory)
            Console.WriteLine($"  {date} -- {score} points");

        Console.WriteLine($"\nYou have {_score} points as of {_lastSavedDate}.");
        Console.WriteLine($"You have completed {completedGoals} out of {_goals.Count} goals.\n");
    }

    public void ListGoalNames(bool includeCompleted = true)
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {   
            if(!includeCompleted && _goals[i].IsComplete())
                continue;
            Console.WriteLine($"  {i + 1}. {_goals[i].Name()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal details:");
        foreach (Goal g in _goals)
            Console.WriteLine($"  {g.GetDetailsString()}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nTypes of goals:");
        Console.WriteLine("  1. Simple goal");
        Console.WriteLine("  2. Eternal goal");
        Console.WriteLine("  3. Checklist goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for bonus? ");
                int required = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus point value? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, required, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames(false);
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count || _goals[index].IsComplete())
        {
            Console.WriteLine("\nInvalid selection.");
            return;
        }

        Goal goal = _goals[index];
        int pointsBefore = goal.GetPoints();
        goal.RecordEvent();
        int earned = pointsBefore;

        _score += earned;
        Console.WriteLine($"\nCongratulations! You have earned {earned} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        foreach (string filename in new[] { "SimpleGoal.txt", "EternalGoal.txt", "ChecklistGoal.txt" })
            File.WriteAllText(filename, string.Empty);

        foreach (Goal g in _goals)
            g.SaveToFile();

        SaveScore();

        Console.WriteLine("Goals saved.");
    }
    public void SaveScore()
    {
        if (_scoreHistory.Count > 0 && _score == _scoreHistory[^1].score)
            return;

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        using StreamWriter scoreWriter = new("score.txt", append: true);
        scoreWriter.WriteLine($"{today},{_score}");

        _scoreHistory.Add((today, _score));
    }
    public void LoadCurrentScore()
    {
        if (File.Exists("score.txt"))
        {
            string[] lines = File.ReadAllLines("score.txt");
            if (lines.Length == 0) return;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split(',');
                DateOnly date = DateOnly.Parse(parts[0]);
                int score = int.Parse(parts[1].Trim());
                _scoreHistory.Add((date, score));
            }

            _lastSavedDate = _scoreHistory[^1].date;
            _score = _scoreHistory[^1].score;
        }
    }
    public void LoadGoals()
    {
        if (File.Exists("SimpleGoal.txt"))
            foreach (string line in File.ReadAllLines("SimpleGoal.txt"))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    _goals.Add(SimpleGoal.LoadFromString(line));
            }
        if (File.Exists("EternalGoal.txt"))
            foreach (string line in File.ReadAllLines("EternalGoal.txt"))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    _goals.Add(EternalGoal.LoadFromString(line));
            }

        if (File.Exists("ChecklistGoal.txt"))
            foreach (string line in File.ReadAllLines("ChecklistGoal.txt"))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    _goals.Add(ChecklistGoal.LoadFromString(line));
            }
    }
}