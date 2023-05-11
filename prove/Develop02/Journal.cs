using System;

public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry.Prompt.Replace(",", "|||")},{entry.Answer.Replace(",", "|||")},{entry.Date.ToString()}");
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] entryData = reader.ReadLine().Split(',');
                    string prompt = entryData[0].Replace("|||", ",");
                    string answer = entryData[1].Replace("|||", ",");
                    DateTime date = DateTime.Parse(entryData[2]);
                    Entry entry = new Entry(prompt, answer, date);
                    AddEntry(entry);
                }
            }
        }
    }
