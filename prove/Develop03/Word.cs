public class Word
{
    private string _wordContent;
    private bool _status;

    public Word(string wordContent)
    {
        _wordContent = wordContent;
        _status = false;
    }

    public void SetStatus(bool status)
    {
        _status = status;
    }

    public bool GetStatus()
    {
        return _status;
    }

    public string GetContent()
    {
        return _wordContent;
    }
}