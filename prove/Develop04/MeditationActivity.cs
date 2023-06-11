class MeditationActivity : Activity
{
    private int _meditationDuration;

    public MeditationActivity(int seconds) : base("Meditation Activity",
                                                  "This activity will help you relax and focus your mind through meditation.",
                                                  seconds)
    {
        _meditationDuration = seconds;
    }

    public void StartMeditation()
    {
        DisplayingStartMessage();

        Console.WriteLine("Close your eyes and focus on your breath.");
        Console.WriteLine("Let go of any thoughts or distractions.");

        Console.WriteLine("Remaining time:");
        PauseCountTimer();

        DisplayingEndMessage();
    }
}