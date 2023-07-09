public class FictionBook : Book
{
    private string publisher;

    public FictionBook(string title, string author, string genre, string status, string publisher) : base(title, author, genre, status)
    {
        this.publisher = publisher;
    }

    public string GetPublisher()
    {
        return publisher;
    }

    public void SetPublisher(string publisher)
    {
        this.publisher = publisher;
    }

    public override double CalculateLateFee(int daysLate)
    {
        // Implementación del cálculo de la tarifa de retraso para libros de ficción
        throw new NotImplementedException();
    }
}
