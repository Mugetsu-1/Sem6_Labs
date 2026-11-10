#if false
using System;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    class Program
    {
        static async Task<string> GetMessageAsync()
        {
            await Task.Delay(1000);
            return "Hello from async!";
        }

        /*
        static async Task Main(string[] args)
        {
            string msg = await GetMessageAsync();
            Console.WriteLine(msg);

            Task t1 = Task.Delay(500);
            Task t2 = Task.Delay(300);
            await Task.WhenAll(t1, t2);
            Console.WriteLine("Both tasks completed.");
        }
        */
    }
}

#endif

