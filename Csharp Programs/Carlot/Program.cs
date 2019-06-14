using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlot
{
    class Carlot
    {
        public string Name;
        public List<Vehicle> Inventory;
        public Carlot(string name)
        {
            Name = name;
            Inventory = new List<Vehicle>();
        }
        public Carlot(string name, List<Vehicle> list)
        {
            Inventory = new List<Vehicle>();
            Name = name;
            foreach (Vehicle x in list)
                Inventory.Add(x);
        }
        public void AddInventory(Vehicle x)
        {
            Inventory.Add(x);
        }
        public void PrintInventory()
        {
            Console.Write($"{Name}\n" +
                          $"--------------------\n");
            int items = 1;
            foreach (Vehicle x in Inventory)
            {
                Console.Write($"{items}. ");
                x.DataDump();
                items++;
            }
        }
    }
    abstract class Vehicle
    {
        protected string License;
        protected string Make;
        protected string Model;
        protected double Price;

        public Vehicle(string license, string make, string model, double price)
        {
            License = license;
            Make = make;
            Model = model;
            Price = price;
        }
         public virtual void DataDump()
        {
            Console.Write($"License: {License}   Model: {Model}   Make: {Make}   Price: {Price}\n");
        }

    }

    class Car : Vehicle
    {
        string Type { get; }
        int Doors { get; }

        public Car(string lic, string make, string model, double price, string type, int doors):base(lic, make, model, price)
        {
            Type = type;
            Doors = doors;
        }
        public override void DataDump()
        {
            Console.Write($"License: {License}   Model: {Model}   Make: {Make}   Type: {Type}   Doors: {Doors}   Price: {Price}\n");
        }
    }

    class Truck : Vehicle
    {
        string BedSize;

        public Truck(string lic, string make, string model, double price, string bedsize):base(lic, make, model, price)
        {
            BedSize = bedsize;
        }

        public override void DataDump()
        {
            Console.Write($"License: {License}   Model: {Model}   Make: {Make}   Bed size: {BedSize}   Price: {Price}\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List <Vehicle> Generic = new List<Vehicle>();
            Generic.Add(new Car("DBG8D966", "Chevoltet", "Tracker", 9999.99, "Sedan", 4));
            Generic.Add(new Truck("DBG8D967", "Ford", "F-150", 1000.01, "Medium"));
            Generic.Add(new Car("DBG8D968", "Toyota", "Camrie", 5.01, "Hatchback", 1));
            Carlot EarlsBustedJunk = new Carlot("Earls Busted Junk");
            Carlot GenericMcGenericson = new Carlot("Generic McGenericSon", Generic);
            EarlsBustedJunk.AddInventory(new Car("DBG8D966", "Chevoltet", "Tracker", 9999.99, "Sedan", 4));
            EarlsBustedJunk.AddInventory(new Truck("DBG8D967", "Ford", "F-150", 1000.01, "Medium"));
            EarlsBustedJunk.AddInventory(new Car("DBG8D968", "Toyota", "Camrie", 5.01, "Hatchback", 1));
            EarlsBustedJunk.PrintInventory();
            Console.WriteLine("");
            GenericMcGenericson.PrintInventory();
            Console.ReadLine();

        }
    }
}
