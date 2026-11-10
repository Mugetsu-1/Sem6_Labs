#if false
using System;

namespace Unit1CH1._3
{
    class ResourceHolder
    {
        public int resourceId;

        public ResourceHolder(int id)
        {
            resourceId = id;
            Console.WriteLine("Resource " + resourceId + " created");
        }

        // Destructor
        ~ResourceHolder()
        {
            Console.WriteLine("Destructor called for Resource " + resourceId);
           
        }

        public void UseResource()
        {
            Console.WriteLine("Using Resource " + resourceId);
        }
    }

    internal class DestructGarbageCollection
    {
        /*
        static void Main(string[] args)
        {
            Console.WriteLine("Creating objects...");
            
            ResourceHolder obj1 = new ResourceHolder(1);
            ResourceHolder obj2 = new ResourceHolder(2);
            
            obj1.UseResource();
            obj2.UseResource();
            
            Console.WriteLine("Objects out of scope. Garbage Collector will clean up...");
            
            // Force garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        */
    }
}

#endif

