using System;
using raminrahimzada;


namespace Praktika
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal accuracy = 0.00001M; 
            decimal a = 1;
            decimal b = 2;

            Console.WriteLine("Метод дихотомии:" +
                              "\nМинимальное значение: " + dihot(a, b, accuracy, function(1)).Item1 + "\nИтераций: " + dihot(a, b, accuracy, function(1)).Item2 + "\n");
        }
        static decimal function(decimal x)
        {
            return 4 * DecimalMath.Cos(4 * x) + 2 * DecimalMath.Sin(8 * x) - x; 
        }

        static (decimal, int) dihot(decimal a, decimal b, decimal accuracy, decimal f)
        {
            int k = 0;
            decimal c, f1, f2;

            while (DecimalMath.Abs(a - b) > accuracy)
            {
                k++;
                c = (a + b) / 2;
                f1 = function(c - accuracy);
                f2 = function(c + accuracy);
                if (f1 > f2)
                {
                    a = c;
                } 
                else if (f2 > f1)
                {
                    b = c;
                }
                else
                {
                    a = c - accuracy;
                    b = c + accuracy;
                }
            }
            return ((a + b) / 2, k);
        }
    }
}
