using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRentables
{
    public interface IRentables
    {
        void GetDailyRate();
         string GetDescription();
    }

    class Boat:Rentable, IRentables
    {
        string Name;
        double HourlyRate;
        double DailyRate;
        public Boat( string name, double rate):base()
        {
            Name = name;
            HourlyRate = rate;
            GetDailyRate();
        }
        public void GetDailyRate()
        {
            DailyRate = Math.Round(HourlyRate * 24, 2);
        }
        public override string GetDescription()
        {
            return $"Type: Boat({Name})   Daily Rate: ${DailyRate}";
        }
    }
    abstract class Rentable
    {
        public virtual string GetDescription()
        {
            return "";
        }
    }
    class House:Rentable,IRentables
    {
        string Name;
        double WeeklyRate;
        private double DailyRate;
        public House(string name, double rate):base()
        {
            Name = name;
            WeeklyRate = rate;
            GetDailyRate();
        }
        public void GetDailyRate()
        {
            DailyRate = Math.Round(WeeklyRate/7,2);
        }
        public override string GetDescription()
        {
            return $"Type: House({Name})   Daily Rate: ${DailyRate}";
        }

    }
    class Car : Rentable,IRentables
    {
        string Name;
        public double DailyRate;
        public Car(string name, double rate):base()
        {
            Name = name;
            DailyRate = rate;
            GetDailyRate();
        }
        public void GetDailyRate()
        {
            DailyRate = Math.Round(DailyRate, 2);
        }
        public override string GetDescription()
        {
            return $"Type: Car({Name})   Daily Rate: ${DailyRate}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Rentable> list = new List<Rentable>();
            list.Add(new Car("Chevolet Tracker", 100.99));
            list.Add(new Boat("Speedy", 15.202));
            list.Add(new House("Bed n Breakfast", 300.49));
            foreach(Rentable x in list)
            {
                Console.WriteLine(x.GetDescription());
            }
            Console.Read();
        }
    }
}
