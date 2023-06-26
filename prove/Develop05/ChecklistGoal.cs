class ChecklistGoal : Goal
{
    private int _completionCount;
    private int _targetCount;
    private int _bonusPoints;


    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _completionCount = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int completionCount)
        : base(name, description, points)
    {
        _completionCount = completionCount;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _completionCount++;

        if (_completionCount == _targetCount)
        {
            return _points + _bonusPoints;
        }else if(_completionCount > _targetCount){
            Console.WriteLine("This task is already completed");
            return 0;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _completionCount == _targetCount;
    }

    public override void Save()
    {
        Console.WriteLine("Guardando el objetivo de lista de verificación '{0}'", _name);
        // Lógica para guardar el objetivo
    }

    public override void Load()
    {
        Console.WriteLine("Cargando el objetivo de lista de verificación '{0}'", _name);
        // Lógica para cargar el objetivo
    }

    public override int GetCompletionCount(){
        return _completionCount;
    }

    public override int GetTargetCount(){
        return _targetCount;
    }

    public static ChecklistGoal Create()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of poits associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int targetCount = int.Parse(Console.ReadLine());

        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonusPoints = int.Parse(Console.ReadLine());

        return new ChecklistGoal(name, description, points, targetCount, bonusPoints);
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_targetCount}|{_completionCount}";
    }

    public static ChecklistGoal Deserialize(string[] data)
    {
        string name = data[1];
        string description = data[2];
        int points = int.Parse(data[3]);
        int bonusPoints = int.Parse(data[4]);
        int targetCount = int.Parse(data[5]);
        int completionCount = int.Parse(data[6]);
        
        
        return new ChecklistGoal(name,description,points,targetCount, bonusPoints, completionCount);
        
    }

}
