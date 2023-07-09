public class ReferenceBook : Book
{
    private int edition;

    public ReferenceBook(string title, string author, string genre, string status, int edition) : base(title, author, genre, status)
    {
        this.edition = edition;
    }

    public int GetEdition()
    {
        return edition;
    }

    public void SetEdition(int edition)
    {
        this.edition = edition;
    }

    public override double CalculateLateFee(int daysLate)
    {
        // Implementación del cálculo de la tarifa de retraso para libros de referencia
        throw new NotImplementedException();
    }
}