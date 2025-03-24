namespace EventsAndDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer( 2, 2);
            timer.TimerStarted += timer.increase;
            timer.TimerStarted += timer.multiply;
            timer.startTimer();
        }
    }
}
