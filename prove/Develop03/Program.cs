using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {

        string jsonString = File.ReadAllText("scritures.json");

        List<ScriptureData> scriptures = JsonSerializer.Deserialize<List<ScriptureData>>(jsonString);

        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        ScriptureData selectedScripture = scriptures[randomIndex];
        Scripture scripture;

        if (selectedScripture.verse != 0)
        {
            scripture = new Scripture(selectedScripture.book, selectedScripture.chapter, selectedScripture.text, selectedScripture.verse);
        }else{
            scripture = new Scripture(selectedScripture.book, selectedScripture.chapter, selectedScripture.text, selectedScripture.initialVerse, selectedScripture.finalVerse);
        }
        
        DisplayScripture(scripture);

        while (scripture.AreWordsVisible())
        {
            Console.WriteLine("Press Enter to hide some words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
            Console.Clear();
            DisplayScripture(scripture);
        }
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine(scripture.GetReference()+" "+scripture.GetText());
    }
}