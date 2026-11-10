#if false
using System;

namespace EventApp
{
    public delegate void AlarmHandler(object sender, EventArgs e);

    class AlarmClock
    {
        public event AlarmHandler Alarm;
        public void Trigger() => Alarm?.Invoke(this, EventArgs.Empty);
    }

    class Program
    {
        static void WakeUp(object s, EventArgs e) => Console.WriteLine("Wake up!");

        /*
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            clock.Alarm += WakeUp;
            clock.Trigger();
        }
        */
    }
}

#endif

