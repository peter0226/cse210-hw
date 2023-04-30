using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101); // Generates a random number between 1 and 100.
        int guess;
        int numGuesses = 0;

        Console.WriteLine("Welcome to the Guess My Number game!");

        do
        {
            Console.Write("Please guess the magic number (between 1 and 100): ");
            guess = int.Parse(Console.ReadLine());
            numGuesses++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Your guess is too low. Please try again.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Your guess is too high. Please try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number in {0} attempts.", numGuesses);
            }

        } while (guess != magicNumber);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}