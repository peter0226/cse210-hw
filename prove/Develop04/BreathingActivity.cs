class BreathingActivity : Activity
{
    private int _timeBreathingIn=4;
    private int _timeBreathingOut=6;

    public BreathingActivity(int seconds)
        : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
        seconds)
    {
    }

    public void DisplayBreathing()
    {
        DisplayingStartMessage();

        int timeBreathingI=_timeBreathingIn;
        int timeBreathingO=_timeBreathingOut;
        bool breathingInStatus = true;
        bool breathingOutStatus = false;
        Console.Write("Breathe in...");

        for (int i = 0; i < _seconds; i++)
        {
            if(timeBreathingI>0 && breathingInStatus==true){
                PauseBreathe(timeBreathingI);
                timeBreathingI--;
            }else if(breathingInStatus==true){
                breathingInStatus=false;
                breathingOutStatus=true;
                timeBreathingO=_timeBreathingOut;
                Console.Write("\b \b");
                Console.WriteLine();
                Console.Write("Breathe out...");
            }

            if(timeBreathingO>0 && breathingOutStatus==true){
                PauseBreathe(timeBreathingO);
                timeBreathingO--;
            }else if(breathingOutStatus==true){
                breathingOutStatus=false;
                breathingInStatus=true;
                timeBreathingI=_timeBreathingIn;
                Console.Write("\b \b");
                Console.WriteLine("\n");
                Console.Write("Breathe in...");

            }

            Thread.Sleep(1000);
        }

        Console.Write("\b \b");
        Console.WriteLine();

        DisplayingEndMessage();
    }

    public void PauseBreathe(int time)
    {
        Console.Write("\b \b");
        Console.Write(time);
    }
}