using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity(0);

        ReflectionActivity reflectionActivity = new ReflectionActivity(0);

        ListingActivity listingActivity = new ListingActivity(0);

        MeditationActivity meditationActivity = new MeditationActivity(0);

        bool exitLoop=false;

        while(!exitLoop){
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Meditation Activity");
            Console.WriteLine("5. Quit");
            String choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathingActivity.DisplayBreathing();
                    break;
                case "2":
                    reflectionActivity.DisplayReflection();
                    break;
                case "3":
                    listingActivity.DisplayListing();
                    break;
                case "4":
                    meditationActivity.StartMeditation();
                    break;
                case "5":
                    exitLoop = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}