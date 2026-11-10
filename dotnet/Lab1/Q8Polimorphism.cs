using System;

namespace PolymorphismApp
{
    class Animal
    {
        public string name;
        public Animal(string n) { name = n; }
        public virtual void MakeSound() => Console.WriteLine($"{name} makes a sound");
        public virtual void Move() => Console.WriteLine($"{name} moves");
        public void Eat() => Console.WriteLine($"{name} is eating");
    }

    class Dog : Animal { public Dog(string n) : base(n) { } public override void MakeSound() => Console.WriteLine($"{name} barks: Woof! Woof!");
        public override void Move() => Console.WriteLine($"{name} runs on 4 legs"); }
    class Cat : Animal { public Cat(string n) : base(n) { } public override void MakeSound() => Console.WriteLine($"{name} meows: Meow! Meow!");
        public override void Move() => Console.WriteLine($"{name} walks silently"); }
    class Bird : Animal { public Bird(string n) : base(n) { } public override void MakeSound() => Console.WriteLine($"{name} chirps: Chirp! Chirp!");
        public override void Move() => Console.WriteLine($"{name} flies in the sky"); }
    class Snake : Animal { public Snake(string n) : base(n) { } public override void MakeSound() => Console.WriteLine($"{name} hisses: Ssss! Ssss!");
        public override void Move() => Console.WriteLine($"{name} slithers on the ground"); }
}