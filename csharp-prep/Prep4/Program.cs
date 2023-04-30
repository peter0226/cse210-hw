using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true) {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            
            if (number == 0) {
                break;
            }
            
            numbers.Add(number);
        }
        
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();
        
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);
        
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositiveNumber = positiveNumbers.Any() ? positiveNumbers.Min() : 0;
        
        Console.WriteLine("The smallest positive number is: " + smallestPositiveNumber);
        
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers) {
            Console.WriteLine(number);
        }
    }
}