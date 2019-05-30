using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosCos
{
    class Program
    {
        static void Main(string[] args)
        {
            driversLicsene steven = new driversLicsene("Steven", "Schoor", "Male", 28756081);
            Console.WriteLine(steven.GetFullName());
            book blergTheBlergening = new book("Blerg the Blergening", "Steven Schoor", "Blerg Books","5000AB92", 100.99, 5000);
            Console.WriteLine("Title: " +blergTheBlergening.Title + "\nAuthors: "+blergTheBlergening.Authors + "\nPublisher: "+blergTheBlergening.Publisher + "\nSKU: " +blergTheBlergening.SKU + "\nPrice: "+blergTheBlergening.Price + "\nPages: "+blergTheBlergening.Pages);
            AirPlane FlyingFortress = new AirPlane("Boeing", "B-52", "Bomber", 5, 6);
            Console.WriteLine(FlyingFortress.DataDump());
            Console.Read();
        }
    }

    class driversLicsene
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender {get; set; }
        public int LicenseNumber { get; set; }
        public driversLicsene(string fName, string lName, string Gen, int LNumber)
        {
            FirstName = fName;
            LastName = lName;
            Gender = Gen;
            LicenseNumber = LNumber;
        }

        public string GetFullName()
        {
            string name = FirstName + " " + LastName;
            return name;
        }
    }

    class book
    {
        public String Title { get; set; }
        public String SKU { get; set; }
        public String Publisher { get; set; }
        public string[] Authors { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }

        public book(String T, String[] A, String P, String S, double Pr, int p)
        {
            Title = T;
            Authors = A;
            Publisher = P;
            SKU = S;
            Price = Pr;
            Pages = p;
        }
        public book(String T, String A, String P, String S, double Pr, int p)
        {
            Title = T;
            Authors = new string[]{ A};
            Publisher = P;
            SKU = S;
            Price = Pr;
            Pages = p;
        }

    }

    class AirPlane
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public int Capacity { get; set; }
        public int Engines { get; set; }
        
        public AirPlane(string Ma, string Mo, string v, int c, int e)
        {
            Manufacturer = Ma;
            Model = Mo;
            Variant = v;
            Capacity = c;
            Engines = e;

        }
        public string DataDump()
        {
            return "Manufacturer: " + Manufacturer + "\nModel: " + Model + "\nVariant: " + Variant + "\nCapacity: " + Capacity + "\nEngins: " + Engines;
        }

    }
}
