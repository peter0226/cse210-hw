public class PayPalPayment : PaymentMethod
{
    public override void MakePayment(double amount)
    {
        Console.WriteLine("==== Payment with PayPal ====");
        Console.Write("Enter the email associated with your PayPal account: ");
        string correoPayPal = Console.ReadLine();

        if (!IsValidEmail(correoPayPal))
        {
            Console.WriteLine("Invalid email. The payment has not been made.");
            return;
        }

        Console.WriteLine($"Paying {amount:C} with PayPal through {correoPayPal}. ");
    }

    private bool IsValidEmail(string email)
    {
        return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
    }
}