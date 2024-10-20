using System;


namespace CsharpProject
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Plane: ");
            Plane plane = new(1,2,2000000,450,2007,10000,132);
            plane.Print();
            Console.WriteLine("Car: ");
            Car car = new Car(100,322,400000,200,2004);
            car.Print();
            Console.WriteLine("Ship: ");
            Ship ship = new(3859.43, 45332.45, 120000000, 60, 1996, 32, "Port San-Marino");
            ship.Print();


        }


    }

    public class Vehicle
    {
        public double x, y;
        public double value;
        public int speed;
        public int year;


        public Vehicle(double x,double y,double value,int speed,int year) {
        this.x = x;
            this.y = y; 
            this.value = value; 
            this.speed = speed;
            this.year = year;
        
        }

        public virtual void Print()
        {
            Console.WriteLine("X: {0} y: {1}",x,y);
            Console.WriteLine("Value of Vehicle: {0}",value);
            Console.WriteLine("Speed of Vehicle: {0}", speed);
            Console.WriteLine("Year of creation: {0}", year);

        }


    }

    public class Plane : Vehicle
    {
        private double high;
       private int amount;

        public Plane(double r, double t, double value, int speed, int year,double high,int amount) : base(r, t, value, speed, year)
        {
            this.high = high;
            this.amount = amount;

        }
        public override void Print() {
          
            Console.WriteLine("X: {0} Y: {1} high: {2}", x, y,high);
            Console.WriteLine("Value of Plane: {0}", value);
            Console.WriteLine("Speed of Plane: {0}", speed);
            Console.WriteLine("Year of creation: {0}", year);
            Console.WriteLine("Amount of People: {0}", amount);
        }
    }

    public class Car : Vehicle
    {
       public Car(double r, double t, double value, int speed, int year) : base(r,t,value,speed,year) { }

        public override void Print()
        {
            Console.WriteLine("X: {0} Y: {1}", x, y);
            Console.WriteLine("Value of Car: {0}", value);
            Console.WriteLine("Speed of Car: {0}", speed);
            Console.WriteLine("Year of creation: {0}", year);
        }


    }

    public class Ship : Vehicle
    {
        
        private int passengers;
        private string port;
        public Ship(double r, double t, double value, int speed, int year,int passengers,string port) : base(r, t, value, speed, year)
        {
            this.passengers = passengers;
            this.port = port;
        }
        public override void Print()
        {

            Console.WriteLine("X: {0} Y: {1}", x, y);
            Console.WriteLine("Value of Ship: {0}", value);
            Console.WriteLine("Speed of Ship: {0}", speed);
            Console.WriteLine("Year of creation: {0}", year);
            Console.WriteLine("Amount of passengers: {0}", passengers);
            Console.WriteLine("Port of registration: {0}", port);
        }



    }


}