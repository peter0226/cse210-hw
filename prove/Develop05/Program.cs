using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//To show creativity, the function to save levels was added

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static List<int> _levelsScore = new List<int>();
    static int _userLevel = 0;
    static int _userScore = 0;

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Levels");
            Console.WriteLine(" 7. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    selectTypeGoal();
                    break;
                case "2":
                    ShowGoalList();
                    break;
                case "3":
                    SaveGoalsAndScore();
                    break;
                case "4":
                    LoadGoalsAndScore();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    MenuLevels();
                    break;
                case "7":
                    exit = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a valid option number.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void MenuLevels(){
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine(" 1. Show points by levels");
            Console.WriteLine(" 2. My Level");
            Console.WriteLine(" 3. Add a new level score");
            Console.WriteLine("Choose an option:");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    showLevels();
                    exit = true;
                    break;
                case "2":
                    Console.WriteLine("You are at level {0}",_userLevel);
                    exit = true;
                    break;
                case "3":
                    bool validScore = false;
                    while (!validScore)
                    {
                        Console.Write("Write the minimum score for level {0}: ", _levelsScore.Count + 1);
                        int points = int.Parse(Console.ReadLine());

                        if (_levelsScore.Count == 0 || points > _levelsScore[_levelsScore.Count - 1])
                        {
                            _levelsScore.Add(points);
                            validScore = true;
                        }
                        else
                        {
                            Console.WriteLine("The score must be greater than the previous score.");
                        }
                    }
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a valid option number.");
                    break;
            }
        }

    }

    static void showLevels(){
        if(_levelsScore.Count>0){
            for (int i = 0; i < _levelsScore.Count; i++)
            {
                Console.WriteLine("Nivel " + (i + 1) + ": " + _levelsScore[i]);
            }
        }else{
            Console.WriteLine("No levels entered");
        }
    }

    static void DetermineUserLevel()
    {

        for (int i = 0; i < _levelsScore.Count; i++)
        {
            if (_userScore >= _levelsScore[i])
            {
                _userLevel = i + 1;
            }
            else
            {
                break;
            }
        }
    }

    static void selectTypeGoal(){
         bool exit = false;

        while (!exit)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    SimpleGoal simpleGoal = SimpleGoal.Create();
                    _goals.Add(simpleGoal);
                    ShowUserScore();
                    exit = true;
                    break;
                case "2":
                    EternalGoal eternalGoal = EternalGoal.Create();
                    _goals.Add(eternalGoal);
                    ShowUserScore();
                    exit = true;
                    break;
                case "3":
                    ChecklistGoal checklistGoal = ChecklistGoal.Create();
                    _goals.Add(checklistGoal);
                    ShowUserScore();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a valid option number.");
                    break;
            }
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no registered targets.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{_goals[i].GetName()}");
            }
            Console.Write("Which goal did you accomplish? ");
            int goalOption = int.Parse(Console.ReadLine());

            Goal goal = _goals[goalOption-1];

            if (goal != null)
            {
                int pointsEarned = goal.RecordEvent();
                _userScore += pointsEarned; 
                DetermineUserLevel();
                Console.WriteLine("You are at level {0}",_userLevel);

                Console.WriteLine("Congratulations! You have earned {0} points!",pointsEarned);
                ShowUserScore();
            }
            else
            {
                Console.WriteLine("No such target was found.");
            }
        }
        
    }

    static void ShowGoalList()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no registered targets.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                string countText = (_goals[i].GetCompletionCount() != -1) ? "-- Currently completed: "+_goals[i].GetCompletionCount()+"/"+_goals[i].GetTargetCount() : "";
                Console.WriteLine($"{i + 1}. [{(_goals[i].IsComplete() ? 'x' : ' ')}] {_goals[i].GetName()} ({_goals[i].GetDescription()}) {countText}");
            }
            ShowUserScore();
        }
    }

    static void ShowUserScore()
    {
        Console.WriteLine("You have {0} points!",_userScore);
    }

    static void SaveGoalsAndScore()
    {
        string fileName = "goals.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Levels|{_userLevel}|{(string.Join(",", _levelsScore))}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
            writer.WriteLine(_userScore);
        }

        Console.WriteLine("Objectives and score successfully saved.");
    }

    static void LoadGoalsAndScore()
    {
        string fileName = "goals.txt";
        if (File.Exists(fileName))
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Levels"))
                    {
                        string[] data=line.Split('|');
                        _userLevel=int.Parse(data[1]);
                        _levelsScore=ConvertStringToList(data[2]);

                    }
                    else if (line.StartsWith("SimpleGoal"))
                    {
                        SimpleGoal simpleGoal = SimpleGoal.Deserialize(line.Split('|'));
                        _goals.Add(simpleGoal);
                    }
                    else if (line.StartsWith("EternalGoal"))
                    {
                        EternalGoal eternalGoal = EternalGoal.Deserialize(line.Split('|'));
                        _goals.Add(eternalGoal);
                    }
                    else if (line.StartsWith("ChecklistGoal"))
                    {
                        ChecklistGoal checklistGoal = ChecklistGoal.Deserialize(line.Split('|'));
                        _goals.Add(checklistGoal);
                    }
                    else
                    {
                        int score;
                        if (int.TryParse(line, out score))
                        {
                            _userScore = score;
                        }
                    }
                }
            }

            Console.WriteLine("Goals and score loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved target file found.");
        }
    }

    static List<int> ConvertStringToList(string input)
    {
        List<int> result = new List<int>();

        if (!string.IsNullOrEmpty(input))
        {
            string[] numbers = input.Split(',');

            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int parsedNumber))
                {
                    result.Add(parsedNumber);
                }
                else
                {
                    
                }
            }
        }

        return result;
    }


}