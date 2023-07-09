
public class Loan
{
    private Book book;
    private User user;
    private DateTime loanDate;
    private DateTime returnDate;

    public Book GetBook()
    {
        return book;
    }

    public void SetBook(Book book)
    {
        this.book = book;
    }

    public User GetUser()
    {
        return user;
    }

    public void SetUser(User user)
    {
        this.user = user;
    }

    public DateTime GetLoanDate()
    {
        return loanDate;
    }

    public void SetLoanDate(DateTime loanDate)
    {
        this.loanDate = loanDate;
    }

    public DateTime GetReturnDate()
    {
        return returnDate;
    }

    public void SetReturnDate(DateTime returnDate)
    {
        this.returnDate = returnDate;
    }

    public double CalculateLateFee()
    {
        // Implementación del cálculo de la tarifa de retraso para el préstamo
        throw new NotImplementedException();
    }
}