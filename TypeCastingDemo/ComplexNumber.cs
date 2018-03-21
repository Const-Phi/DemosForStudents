using System;
using System.Globalization;

namespace TypeCastingDemo
{
    internal class ComplexNumber : IFormattable
    {
        private readonly Double real;

        private readonly Double imaginary;

        public ComplexNumber(Double re = 0, Double im = 0)
        {
            real = re;
            imaginary = im;
        }

        public override String ToString() => 
            $"<{real}; {imaginary}>";

        public String ToString(String format) => 
            ToString(format, NumberFormatInfo.CurrentInfo);

        public String ToString(String format, IFormatProvider formatProvider) =>
            $"<{real.ToString(format, formatProvider)}; {imaginary.ToString(format, formatProvider)}>";

        // неявное приведение типа
        public static implicit operator ComplexNumber(Double value) => 
            new ComplexNumber(value);

        // явное приведение типа
        public static explicit operator Double(ComplexNumber value) =>
            value.real;
    }
}