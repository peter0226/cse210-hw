using System;
public class PromptGenerator
    {
        private List<string> _prompts;

        public PromptGenerator()
        {
            _prompts = new List<string>();
            LoadPromptsFromFile("prompts.txt");
        }

        public string GeneratePrompt()
        {
            Random rand = new Random();
            int index = rand.Next(_prompts.Count);
            return _prompts[index];
        }

        public void LoadPromptsFromFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    _prompts.Add(line);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: Prompts file not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void AddPrompt(string prompt)
        {
            _prompts.Add(prompt);
        }

        public void RemovePrompt(string prompt)
        {
            _prompts.Remove(prompt);
        }
    }