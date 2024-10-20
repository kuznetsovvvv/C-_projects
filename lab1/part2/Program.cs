using System;
namespace CsharpProject
{


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите длину :");
            double sideA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите ширину:");
            double sideB = Convert.ToDouble(Console.ReadLine());

            Rectangle obj = new Rectangle(sideA, sideB);

            Console.WriteLine("Площадь прямоугольника: {0}",obj.Area);
            Console.WriteLine("Периметр прямоугольника: {0}", obj.Perimeter);
        }
    }



    class Rectangle
    {
        public double sideA;
        public double sideB;

        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        private double CalculateArea()
        {
            Console.WriteLine("Area = ", sideA * sideB);
            return sideA * sideB;
        }

        private double CalculatePerimeter()
        {
            Console.WriteLine("Perimeter = ", (sideA+sideB)*2);
            return 2 * (sideA + sideB);
        }

        public double Area
        {
            get { return CalculateArea(); }
        }

        public double Perimeter
        {
            get { return CalculatePerimeter(); }
        }
    }

   
}