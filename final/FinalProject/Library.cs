public class Library
{
    private List<Book> books;

    public void AddBook(Book book)
    {
        // Implementación para agregar un libro a la biblioteca
    }

    public List<Book> SearchBookByTitle(string title)
    {
        // Implementación para buscar libros por título en la biblioteca
        return new List<Book>();
    }

    public List<Book> SearchBookByAuthor(string author)
    {
        // Implementación para buscar libros por autor en la biblioteca
        return new List<Book>();
    }

    public List<Book> SearchBookByGenre(string genre)
    {
        // Implementación para buscar libros por género en la biblioteca
        return new List<Book>();
    }

    public bool LoanBook(Book book, User user)
    {
        // Implementación para realizar el préstamo de un libro a un usuario
        return false;
    }

    public bool ReturnBook(Book book, User user)
    {
        // Implementación para devolver un libro prestado por un usuario
        return false;
    }
}