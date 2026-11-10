using System;

namespace InterfaceApp
{
    interface IShape { double CalculateArea(); void Display(); }
    interface IColor { string Color { get; set; } void ShowColor(); }
    interface IDrawable { void Draw(); }

    class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Rectangle(double l, double b) { Length = l; Breadth = b; }
        public double CalculateArea() => Length * Breadth;
        public void Display() => Console.WriteLine($"Rectangle: Length={Length}, Breadth={Breadth}, Area={CalculateArea()}");
    }

    class Circle : IShape, IColor, IDrawable
    {
        public double Radius { get; set; }
        public string Color { get; set; }
        public Circle(double r, string color) { Radius = r; Color = color; }
        public double CalculateArea() => Math.PI * Radius * Radius;
        public void Display() => Console.WriteLine($"Circle: Radius={Radius}, Area={CalculateArea():F2}");
        public void ShowColor() => Console.WriteLine($"Color: {Color}");
        public void Draw() => Console.WriteLine("Drawing circle...");
    }

    class Triangle : IShape, IDrawable
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double b, double h) { Base = b; Height = h; }
        public double CalculateArea() => 0.5 * Base * Height;
        public void Display() => Console.WriteLine($"Triangle: Base={Base}, Height={Height}, Area={CalculateArea()}");
        public void Draw() => Console.WriteLine("Drawing triangle...");
    }
}