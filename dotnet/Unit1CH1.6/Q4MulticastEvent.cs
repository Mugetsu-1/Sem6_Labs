#if false
using System;

namespace Unit1CH1._6
{
    // Declare a delegate
    public delegate void NotifyHandler(string message);

    class Publisher
    {
        // Declare an event
        public event NotifyHandler OnNotify;

        public void RaiseNotification(string msg)
        {
            Console.WriteLine($"\nRaising notification: {msg}");
            OnNotify?.Invoke(msg);
        }
    }

    class EmailSubscriber
    {
        public void OnNotification(string msg)
        {
            Console.WriteLine($"Email received: {msg}");
        }
    }

    class SMSSubscriber
    {
        public void OnNotification(string msg)
        {
            Console.WriteLine($"SMS received: {msg}");
        }
    }

    class PushSubscriber
    {
        public void OnNotification(string msg)
        {
            Console.WriteLine($"Push received: {msg}");
        }
    }

    internal class MulticastEventDemo
    {
        /*
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            EmailSubscriber email = new EmailSubscriber();
            SMSSubscriber sms = new SMSSubscriber();
            PushSubscriber push = new PushSubscriber();

            // Subscribe multiple handlers to the same event (multicast)
            pub.OnNotify += email.OnNotification;
            pub.OnNotify += sms.OnNotification;
            pub.OnNotify += push.OnNotification;

            pub.RaiseNotification("System update available!");

            Console.WriteLine("\nRemoving SMS subscriber...");
            pub.OnNotify -= sms.OnNotification;

            pub.RaiseNotification("Maintenance scheduled.");
        }
        */
    }
}

#endif

