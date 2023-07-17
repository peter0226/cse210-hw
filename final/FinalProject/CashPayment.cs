public class CashPayment : PaymentMethod
{
    public override void MakePayment(double amount)
    {
        Console.WriteLine($"Payment of {amount:C} in Cash received.");
        Console.Write("Enter the amount given by the customer: ");
        double amountGiven = Convert.ToDouble(Console.ReadLine());

        if (amountGiven >= amount)
        {
            double change = amountGiven - amount;
            Console.WriteLine($"Change: {change:C}");
        }
        else
        {
            Console.WriteLine("Insufficient amount provided. Payment cannot be completed.");
        }
    }
}