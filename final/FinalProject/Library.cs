public class Library
{
    private List<Book> _books;
    private List<User> _users;

    public Library()
    {
        _books = new List<Book>();
        _users = new List<User>();
    }

    public List<User> GetUsers()
    {
        return _users;
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<Book> GetBooks()
    {
        return _books;
    }

    public void SetBooks(List<Book> books)
    {
        this._books = books;
    }

    public List<Book> SearchBookByTitle(string title)
    {
        return _books.FindAll(book => book.GetTitle().Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public User SearchUserByName(string name)
    {
        return _users.Find(user => user.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Book> SearchBookByAuthor(string author)
    {
        return _books.FindAll(book => book.GetAuthor().Contains(author, StringComparison.OrdinalIgnoreCase));
    }

    public List<Book> SearchBookByGenre(string genre)
    {
        return _books.FindAll(book => book.GetGenre().Contains(genre, StringComparison.OrdinalIgnoreCase));
    }

    public bool LoanBook(Book book, User user)
    {
        
        
        if (book.GetStatus() == BookStatus.Available)
        {
            
            
            user.LoanBook(book);
            book.SetStatus(BookStatus.OnLoan);
            return true;
        }
        return false;
    }


    public bool ReturnBook(Book book, User user)
    {
        if (book.GetStatus() == BookStatus.OnLoan && user.GetBorrowedBooks().Contains(book))
        {
            book.SetStatus(BookStatus.Available);
            user.ReturnBook(book);
            return true;
        }
        return false;
    }

    public void ListAllBooks()
    {
        Console.WriteLine("==== All Books in the Library ====");
        foreach (Book book in _books)
        {
            Console.WriteLine($"Title: {book.GetTitle()}");
            Console.WriteLine($"Author: {book.GetAuthor()}");
            Console.WriteLine($"Genre: {book.GetGenre()}");
            Console.WriteLine($"Status: {book.GetStatus()}");

            if (book is FictionBook fictionBook)
            {
                Console.WriteLine($"Publisher: {fictionBook.GetPublisher()}");
            }
            else if (book is NonFictionBook nonFictionBook)
            {
                Console.WriteLine($"Topic: {nonFictionBook.GetTopic()}");
            }
            else if (book is ReferenceBook referenceBook)
            {
                Console.WriteLine($"Edition: {referenceBook.GetEdition()}");
            }

            Console.WriteLine();
        }
    }
}
