#if false
using System;

namespace MulticastEventApp
{
    public delegate void OrderHandler(string orderId, string status);

    class OrderProcessor
    {
        public event OrderHandler StatusChanged;

        public void Process(string id)
        {
            StatusChanged?.Invoke(id, "Shipped");
            StatusChanged?.Invoke(id, "Delivered");
        }
    }

    class Program
    {
        static void Email(string id, string s) => Console.WriteLine($"Email: Order {id} {s}");
        static void SMS(string id, string s) => Console.WriteLine($"SMS: Order {id} {s}");

        /*
        static void Main(string[] args)
        {
            OrderProcessor p = new OrderProcessor();
            p.StatusChanged += Email;
            p.StatusChanged += SMS;

            p.Process("1001");

            p.StatusChanged -= SMS;
            p.Process("1002");
        }
        */
    }
}

#endif

