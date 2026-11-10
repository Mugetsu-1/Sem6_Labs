using System;

namespace AbstractApp
{
    abstract class Shape
    {
        public string Color { get; set; }
        public abstract double CalculateArea();
        public abstract void Display();
        public void ShowColor() => Console.WriteLine($"Color: {Color}");
    }

    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Rectangle(double length, double breadth, string color) { Length = length; Breadth = breadth; Color = color; }
        public override double CalculateArea() => Length * Breadth;
        public override void Display() => Console.WriteLine($"Rectangle\nLength: {Length}, Breadth: {Breadth}\nArea: {CalculateArea()}");
    }

    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius, string color) { Radius = radius; Color = color; }
        public override double CalculateArea() => Math.PI * Radius * Radius;
        public override void Display() => Console.WriteLine($"Circle\nRadius: {Radius}\nArea: {CalculateArea():F2}");
    }

    class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double baseLength, double height, string color) { Base = baseLength; Height = height; Color = color; }
        public override double CalculateArea() => 0.5 * Base * Height;
        public override void Display() => Console.WriteLine($"Triangle\nBase: {Base}, Height: {Height}\nArea: {CalculateArea()}");
    }
}