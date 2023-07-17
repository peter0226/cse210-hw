public class WireTransferPayment : PaymentMethod
{
    private long numeroCuenta=1122334455667;
    public override void MakePayment(double amount)
    {
        Console.WriteLine("==== Payment with Bank Transfer ====");
        Console.WriteLine($"Make a transfer of {amount:C} to the account {numeroCuenta} to complete the payment.");
    }
}