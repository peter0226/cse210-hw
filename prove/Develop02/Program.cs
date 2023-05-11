using System;

class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            string fileName;
            //string fileName = "journal.csv";

            while (true)
            {
                Console.WriteLine("1. Write   \n2. Display   \n3. Load   \n4. Save   \n5. Quit");
                Console.WriteLine("What would you like to do?");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = promptGenerator.GeneratePrompt();
                        Console.WriteLine(prompt);
                        string answer = Console.ReadLine();
                        Entry entry = new Entry(prompt, answer);
                        journal.AddEntry(entry);
                        Console.WriteLine("Entry added successfully!");
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.WriteLine("Enter file name to load from:");
                        fileName = Console.ReadLine();
                        journal.LoadFromFile(fileName);
                        Console.WriteLine("Entries loaded successfully!");
                        break;
                    case "4":
                        Console.WriteLine("Enter file name to save to:");
                        fileName = Console.ReadLine();
                        journal.SaveToFile(fileName);
                        Console.WriteLine("Entries saved successfully!");
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please select one of the following choices:");
                        break;
                }

                Console.WriteLine("Please select one of the following choices:");
            }
        }
    }