public class NonFictionBook : Book
{
    private string topic;

    public NonFictionBook(string title, string author, string genre, string status, string topic) : base(title, author, genre, status)
    {
        this.topic = topic;
    }

    public string GetTopic()
    {
        return topic;
    }

    public void SetTopic(string topic)
    {
        this.topic = topic;
    }

    public override double CalculateLateFee(int daysLate)
    {
        // Implementación del cálculo de la tarifa de retraso para libros de no ficción
        throw new NotImplementedException();
    }
}
