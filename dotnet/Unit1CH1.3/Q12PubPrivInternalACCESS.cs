#if false
using System;

namespace Unit1CH1._3
{
    class ParentClass
    {
        // Public - accessible everywhere
        public string publicField = "Public Field";

        // Private - accessible only within this class
        private string privateField = "Private Field";

        // Protected - accessible within this class and derived classes
        protected string protectedField = "Protected Field";

        // Internal - accessible within same assembly
        internal string internalField = "Internal Field";

        // Public method
        public void PublicMethod()
        {
            Console.WriteLine("Public Method");
            Console.WriteLine("Accessing all fields within same class:");
            Console.WriteLine(publicField);
            Console.WriteLine(privateField);
            Console.WriteLine(protectedField);
            Console.WriteLine(internalField);
        }

        // Private method
        private void PrivateMethod()
        {
            Console.WriteLine("Private Method - only accessible inside this class");
        }

        // Protected method
        protected void ProtectedMethod()
        {
            Console.WriteLine("Protected Method - accessible in derived class");
        }

        // Internal method
        internal void InternalMethod()
        {
            Console.WriteLine("Internal Method - accessible within same assembly");
        }
    }

    // Derived class to demonstrate protected access
    class ChildClass : ParentClass
    {
        public void TestAccess()
        {
            Console.WriteLine("\nInside ChildClass:");
            
            // Can access public
            Console.WriteLine("Public: " + publicField);
            
            // Cannot access private - compile error
            // Console.WriteLine(privateField);
            
            // Can access protected (inherited)
            Console.WriteLine("Protected: " + protectedField);
            
            // Can access internal (same assembly)
            Console.WriteLine("Internal: " + internalField);
            
            // Can call protected method
            ProtectedMethod();
        }
    }

    internal class PrivPubIntAccess
    {
        /*
        static void Main(string[] args)
        {
            ParentClass parent = new ParentClass();
            
            Console.WriteLine("Accessing from Program class:");
            
            // Can access public
            Console.WriteLine("Public: " + parent.publicField);
            
            // Cannot access private - compile error
            // Console.WriteLine(parent.privateField);
            
            // Cannot access protected (not derived class)
            // Console.WriteLine(parent.protectedField);
            
            // Can access internal (same assembly)
            Console.WriteLine("Internal: " + parent.internalField);
            
            // Can call public method
            parent.PublicMethod();
            
            // Cannot call private method
            // parent.PrivateMethod();
            
            // Cannot call protected method
            // parent.ProtectedMethod();
            
            // Can call internal method
            parent.InternalMethod();
            
            // Test from derived class
            ChildClass child = new ChildClass();
            child.TestAccess();
        }
        */
    }
}

#endif

