#if false
using System;

namespace MulticastDelegateApp
{
    public delegate void Notifier(string msg);

    class MulticastDelegate
    {
        static void Email(string msg) => Console.WriteLine($"Email: {msg}");
        static void SMS(string msg) => Console.WriteLine($"SMS: {msg}");

        /*
        static void Main(string[] args)
        {
            Notifier n = Email;
            n += SMS;

            n("Order placed successfully!");

            n -= SMS;
            n("Only email this time.");
        }
        */
    }
}

#endif

