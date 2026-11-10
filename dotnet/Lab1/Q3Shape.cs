using System;

namespace ShapeApp
{
    class Shape
    {
        public double length, breadth, height;

        public Shape(double l, double b) { length = l; breadth = b; height = 0; }
        public Shape(double l, double b, double h) { length = l; breadth = b; height = h; }

        public void FindAreaRectangle() => Console.WriteLine($"Area of Rectangle = {length * breadth}");

        public void FindVolumeBox() => Console.WriteLine($"Volume of Box = {length * breadth * height}");
    }
}