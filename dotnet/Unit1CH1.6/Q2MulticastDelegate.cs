#if false
using System;

namespace Unit1CH1._6
{
    // Declare a delegate
    public delegate void Notify(string message);

    class EmailService
    {
        public void SendEmail(string msg)
        {
            Console.WriteLine($"Email sent: {msg}");
        }
    }

    class SMSService
    {
        public void SendSMS(string msg)
        {
            Console.WriteLine($"SMS sent: {msg}");
        }
    }

    class PushService
    {
        public void SendPush(string msg)
        {
            Console.WriteLine($"Push notification sent: {msg}");
        }
    }

    internal class MulticastDelegateDemo
    {
        /*
        static void Main(string[] args)
        {
            EmailService email = new EmailService();
            SMSService sms = new SMSService();
            PushService push = new PushService();

            // Create delegate instances
            Notify notify = email.SendEmail;
            notify += sms.SendSMS;   // Add another method
            notify += push.SendPush; // Add another method

            Console.WriteLine("Invoking multicast delegate (all methods):");
            notify("Hello User!");

            Console.WriteLine("\nRemoving SMS from multicast:");
            notify -= sms.SendSMS;   // Remove a method
            notify("Hello again!");
        }
        */
    }
}

#endif

