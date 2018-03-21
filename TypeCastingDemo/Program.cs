using System;

namespace TypeCastingDemo
{
    internal class Program
    {
        private static void Main()
        {
            ComplexNumber z = Math.PI;
            Console.WriteLine($"complex value = {z:G3};");

            var value = (Double) z;
            Console.WriteLine($"real number = {value:G3};");
        }
    }
}
