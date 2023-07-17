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
    private string title;
    private string author;
    private string genre;
    private BookStatus status;

    private int MaximumLoanDays=1;

    public Book(string title, string author, string genre, BookStatus status)
    {
        this.title = title;
        this.author = author;
        this.genre = genre;
        this.status = status;
    }

    public string GetTitle()
    {
        return title;
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public string GetGenre()
    {
        return genre;
    }

    public void SetGenre(string genre)
    {
        this.genre = genre;
    }

    public BookStatus GetStatus()
    {
        return status;
    }

    public void SetStatus(BookStatus status)
    {
        this.status = status;
    }

    public abstract double CalculateLateFee(int daysLate);

    public double GetMaximumLoanDays()
    {
        return MaximumLoanDays;
    }
}
