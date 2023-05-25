public class Scripture
{
    private List<Word> _words;
    private Reference _reference;

    public Scripture(string book, int chapter,string text, int verse)
    {
        _words = new List<Word>();
        _reference = new Reference(book, chapter, verse);

        string[] wordArray = text.Split(' ');

        foreach (string wordContent in wordArray)
        {
            Word word = new Word(wordContent);
            word.SetStatus(true);
            _words.Add(word);
        }
    }

    public Scripture(string book, int chapter, string text, int initialVerse, int finalVerse)
    {
        _words = new List<Word>();
        _reference = new Reference(book, chapter, initialVerse, finalVerse);

        string[] wordArray = text.Split(' ');

        foreach (string wordContent in wordArray)
        {
            Word word = new Word(wordContent);
            word.SetStatus(true);
            _words.Add(word);
        }
    }

    

    public void HideRandomWords()
    {
        Random random = new Random();

        foreach (Word word in _words)
        {
            if (word.GetStatus())
            {
                if (random.Next(2) == 0)
                    word.SetStatus(false);
            }
        }

        
    }

    public bool AreWordsVisible()
    {
        foreach (Word word in _words)
        {
            if (word.GetStatus()==true)
                return true;
        }

        return false;
    }

    public string GetReference()
    {
        return _reference.GetReference();
    }

    public string GetText()
    {
        string text = "";

        foreach (Word word in _words)
        {
            if (word.GetStatus()){
                text += word.GetContent() + " ";
            }else{
                int contador = 0;
                while (contador < word.GetContent().Length)
                {
                    text +="_";
                    contador++;
                }
            }
            text +=" ";
        }

        return text.TrimEnd();
    }
}