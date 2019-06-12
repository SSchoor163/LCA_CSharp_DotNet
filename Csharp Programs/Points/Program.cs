using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public class Point2D
    {
       public int Y { set; get; }
       public int X { set; get; }

        public Point2D()
        {
            X = 0;
            Y = 0;

        }
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
            {
                Point2D temp = (Point2D)obj;
                if (temp.X == X && temp.Y == Y)
                    return true;
                else return false;
            }
            else return false;
        }
    }

    public class Point3D : Point2D
    {

        int Z { get; }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;

        }
        public Point3D(int x, int y, int z) : base(x, y)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
            {
                Point3D temp = (Point3D)obj;
                if (temp.X == X && temp.Y == Y && temp.Z == Z)
                    return true;
                else return false;
            }
            else return false;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Point2D p1 = new Point2D(), p2 = new Point2D(7, 5), p3 = new Point2D(-2, 4), p4 = new Point2D(7, 5);

            Console.WriteLine($"p1 = {p1}");
            Console.WriteLine($"p2 = {p2}");
            Console.WriteLine($"p3 = {p3}");
            Console.WriteLine($"p4 = {p4}");

            Console.WriteLine($"p2 == p3? {p2==p3}");
            Console.WriteLine($"p2.Equals(p3)? {p2.Equals(p3)}");
            Console.WriteLine($"p2 == p4? {p2==p4}");
            Console.WriteLine($"p2.Equals(p4)? {p2.Equals(p4)}");

            Console.WriteLine("============");

            Point3D p5 = new Point3D(), p6 = new Point3D(7, 5, 12), p7 = new Point3D(-2, 4, -4), p8 = new Point3D(7, 5, 12);

            Console.WriteLine($"p5 = {p5}");
            Console.WriteLine($"p6 = {p6}");
            Console.WriteLine($"p7 = {p7}");
            Console.WriteLine($"p8 = {p8}");

            Console.WriteLine($"p6 == p7? {p6 == p7}");
            Console.WriteLine($"p6.Equals(p7)? {p6.Equals(p7)}");
            Console.WriteLine($"p6 == p8? {p6 == p8}");
            Console.WriteLine($"p6.Equals(p8)? {p6.Equals(p8)}");

            Console.WriteLine("============");
            Console.Read();
        }

       
    }
}
