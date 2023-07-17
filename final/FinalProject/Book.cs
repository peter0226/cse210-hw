public enum BookStatus
{
    Available,
    OnLoan,
    Reserved,
    Lost,
    Damaged
}


public abstract class Book
{
    private string _title;
    private string _author;
    private string _genre;
    private BookStatus _status;

    private int _maximumLoanDays=1;

    public Book(string title, string author, string genre, BookStatus status)
    {
        this._title = title;
        this._author = author;
        this._genre = genre;
        this._status = status;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        this._title = title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public void SetAuthor(string author)
    {
        this._author = author;
    }

    public string GetGenre()
    {
        return _genre;
    }

    public void SetGenre(string genre)
    {
        this._genre = genre;
    }

    public BookStatus GetStatus()
    {
        return _status;
    }

    public void SetStatus(BookStatus status)
    {
        this._status = status;
    }

    public abstract double CalculateLateFee(int daysLate);

    public double GetMaximumLoanDays()
    {
        return _maximumLoanDays;
    }
}
