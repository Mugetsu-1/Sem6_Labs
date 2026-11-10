using System;

namespace InheritanceApp
{
    class Animal
    {
        public string name;
        public Animal(string n) { name = n; }
        public void Eat() => Console.WriteLine($"{name} is eating.");
        public void Sleep() => Console.WriteLine($"{name} is sleeping.");
    }

    class Dog : Animal { public Dog(string n) : base(n) { } public void Bark() => Console.WriteLine($"{name} is barking."); }
    class Bird : Animal { public Bird(string n) : base(n) { } public void Fly() => Console.WriteLine($"{name} is flying."); }
    class Fish : Animal { public Fish(string n) : base(n) { } public void Swim() => Console.WriteLine($"{name} is swimming."); }
    class Mammal : Animal { public Mammal(string n) : base(n) { } public void FeedMilk() => Console.WriteLine($"{name} is feeding milk."); }
    class Human : Mammal { public Human(string n) : base(n) { } public void Speak() => Console.WriteLine($"{name} is speaking."); }

    class Student : Human
    {
        public int rollNo;
        public Student(string n, int roll) : base(n) { rollNo = roll; }
        public void Study() => Console.WriteLine($"{name} (Roll: {rollNo}) is studying.");
    }
}