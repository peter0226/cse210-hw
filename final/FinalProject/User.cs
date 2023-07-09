public class User
{
    private string name;
    private string idNumber;
    private List<Book> borrowedBooks;

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetIdNumber()
    {
        return idNumber;
    }

    public void SetIdNumber(string idNumber)
    {
        this.idNumber = idNumber;
    }

    public List<Book> GetBorrowedBooks()
    {
        return borrowedBooks;
    }

    public bool LoanBook(Book book)
    {
        // Implementación para realizar el préstamo de un libro por parte del usuario
        return false;
    }

    public bool ReturnBook(Book book)
    {
        // Implementación para devolver un libro prestado por el usuario
        return false;
    }
}