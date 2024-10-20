
using System.Drawing;

namespace ConsoleApp3.UnitTests
{
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
        public string name;
        public Point[] vertices;



        public Figure(Point p1, Point p2, Point p3)
        {
            name = "Треугольник";
            vertices = new Point[] { p1, p2, p3 };
        }

        public Figure(Point p1, Point p2, Point p3, Point p4) : this(p1, p2, p3)
        {
            name = "Четырехугольник";
            vertices = new Point[] { p1, p2, p3, p4 };
        }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) : this(p1, p2, p3, p4)
        {
            name = "Пятиугольник";
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
            Console.WriteLine("Периметр фигуры: {0}, Название фигуры: {1}", perimeter, name);
            return perimeter;
        }
    }


    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void Rectangle1()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3= new Point(4, 4);
            Figure figure = new Figure(p1, p2,p3);

            string result = figure.name;

            Assert.AreEqual("Треугольник",figure.name,"{0} Should be equal {1}", "Треугольник", figure.name);
        }

        [TestMethod]
        public void Rectangle2()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3 = new Point(4, 4);
            Point p4 = new Point(6, 7);
            Figure figure = new Figure(p1, p2, p3,p4);

            string result = figure.name;

            Assert.AreEqual("Четырехугольник", figure.name, "{0} Should be equal {1}", "Четырехугольник", figure.name);
        }


        [TestMethod]
        public void Rectangle3()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3 = new Point(4, 4);
            Point p4 = new Point(6, 7);
            Point p5 = new Point(7, 8);
            Figure figure = new Figure(p1, p2, p3, p4, p5);

            string result = figure.name;

            Assert.AreEqual("Пятиугольник", figure.name, "{0} Should be equal {1}", "Пятиугольник", figure.name);
        }

        [TestMethod]
        public void LengthSideTest()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3 = new Point(4, 4);
            Figure figure = new Figure(p1,p2,p3);

            double result = figure.LengthSide(p1, p2);

            Assert.AreEqual((2.8284271247461903), result, "{0} Should be equal {1}", (2.8284271247461903), result);


        }


            [TestMethod]
        public void PerimeterCalculatorTest()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(3, 3);
            Point p3 = new Point(5, 1);
            Figure figure = new Figure(p1, p2, p3);

            double result = figure.PerimeterCalculator();

            Assert.AreEqual(result, (9.65685424949238), "{0} Should be equal {1}", result, (9.65685424949238));
        }
    }

    
}
