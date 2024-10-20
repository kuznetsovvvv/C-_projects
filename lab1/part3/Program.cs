using System;

namespace CsharpProject
{



    public class Program
    {
        public static void Main(string[] args)
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3 = new Point(5, 1);
            Console.WriteLine("p1,x: {0}, y: {1}", p1.X, p2.Y);
            Figure figure = new Figure(p1, p2, p3);

            figure.PerimeterCalculator();

        }
        
    }




    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }



    public class Figure
    {
       


        public string Name;
        public Point[] vertices;



        public Figure(Point p1, Point p2, Point p3)
        {
            Name = "Треугольник";
            vertices = new Point[] { p1, p2, p3 };
        }

        public Figure(Point p1, Point p2, Point p3, Point p4) : this(p1, p2, p3)
        {
            Name = "Четырехугольник";
            vertices = new Point[] { p1, p2, p3, p4 };
        }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) : this(p1, p2, p3, p4)
        {
            Name = "Пятиугольник";
            vertices = new Point[] { p1, p2, p3, p4, p5 };
        }

     

        public double LengthSide(Point A, Point B)
        {
            double x = A.X - B.X;
            double y = A.Y - B.Y;
            return Math.Sqrt(x * x + y * y);
        }

        public double PerimeterCalculator()
        {
            double perimeter = 0;
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                perimeter += LengthSide(vertices[i], vertices[i + 1]);
            }

            perimeter += LengthSide(vertices[vertices.Length - 1], vertices[0]);
            Console.WriteLine("Периметр фигуры: {0}, Название фигуры: {1}", perimeter, Name);
            return perimeter;
        }
    }

}