public class CreditCardPayment : PaymentMethod
{
    public override void MakePayment(double amount)
    {
        Console.WriteLine("==== Credit Card Payment =====");
        Console.Write("Enter the card number: ");
        string numeroTarjeta = Console.ReadLine();

        if (!long.TryParse(numeroTarjeta, out _))
        {
            Console.WriteLine("Invalid card number. Payment has not been made.");
            return;
        }

        Console.Write("Enter cardholder's name: ");
        string nombreTitular = Console.ReadLine();

        
        if (string.IsNullOrWhiteSpace(nombreTitular))
        {
            Console.WriteLine("Invalid holder name. The payment has not been made.");
            return;
        }

        Console.WriteLine($"Paying {amount:C} with a credit card in the name of {nombreTitular}.");
    }
}