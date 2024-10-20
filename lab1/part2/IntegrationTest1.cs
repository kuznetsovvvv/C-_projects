namespace ConsoleApp2.UnitTests
{

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
            Console.WriteLine("Perimeter = ", (sideA + sideB) * 2);
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


    [TestClass]
    public class IntegrationTest1
    {



        [TestMethod]
        public void TestArea()
        {
            double x = 1, y = 2;
            Rectangle obj1 = new Rectangle(x, y);

            double result = obj1.Area;

            Assert.AreEqual(2, result,"{0} Should be equal {1}", 2, result);

        }



        [TestMethod]
        public void TestPerimeter()
        {
            double x = 1, y = 2;
            Rectangle obj1 = new Rectangle(x, y);

            double result = obj1.Perimeter;

            Assert.AreEqual(6, result, "{0} Should be equal {1}", 6, result);

        }




    }
}
