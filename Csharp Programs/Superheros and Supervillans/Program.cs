using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheros_and_Supervillans
{
    class Person
    {
        public string Name { get; set; }
        public string NickName { get; set; }


        public Person(string x, string y)
        {
            Name = x;
            NickName = y;
        }
        public override string ToString()
        {
            return $"{Name}: ";
        }
        public virtual string PrintGreeting()
        {
            return $"Hi, my name is {Name}, you can call me {NickName}.";
        }
    }
    class Superhero : Person
    {
        public string RealName { get; set; }
        public string SuperPower { get; set; }

        public Superhero(string name, string superpower, string realname) : base( name, null )

        {
            SuperPower = superpower;
            RealName = realname;
        }
        public override string PrintGreeting()
        {
            return $"I am {RealName}. When I am {Name}, my super power is {SuperPower}!";
        }
    }
    class SuperVillan: Person
    {
        public string Nemesis { get; set; }

        public SuperVillan(string name, string nemesis): base(name, null)
        {
            Nemesis = nemesis;
        }

        public override string PrintGreeting()
        {
            return $"I am the {Name}. Have you seen {Nemesis}?";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> citizens = new List<Person>();
            Person temp = new Person("William", "Bill");
            citizens.Add(temp);
            temp = new Superhero("Mr Incredible", "super strength", "Wade Turner");
            citizens.Add(temp);
            temp = new SuperVillan("The Joker", "Batman");
            citizens.Add(temp);
            foreach (Person x in citizens)
            {
                Console.WriteLine($"{x.ToString()}{x.PrintGreeting()}");
            }
            Console.Read();

        }
    }
}
