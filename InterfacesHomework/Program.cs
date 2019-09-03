using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Comparison firstComparison = new Comparison();
            Comparison secondComparison = new Comparison();
            Display outputDisplay = new Display();

            Console.WriteLine("Please enter your first string");
            firstComparison.Name = Console.ReadLine();
            Console.WriteLine("Please enter your second string");
            secondComparison.Name = Console.ReadLine();

            Console.WriteLine("{0} {1} {2} alphabetically", firstComparison.Name, outputDisplay.DisplayOutput(firstComparison.CompareByName(secondComparison)), secondComparison.Name); 
            Console.WriteLine("{0} {1} length compared to {2}", firstComparison.Name, outputDisplay.DisplayOutput(firstComparison.CompareByLength(secondComparison)),secondComparison.Name); 
        }

        // Step through to understand what is happening
        static void Lab1()
        {
            var a = new Item();
            var b = new Item();
            a.Name = "Bob";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b)); // a < b returns -1
            a.Name = "Carly";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b)); // a == b returns 0
            a.Name = "Edward";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b)); // a > b returns 1

            var c = new Comparison();
            var d = new Comparison();
            c.Name = "Bob";
            d.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", c.Name, d.Name, c.CompareByName(d)); // c < d returns -1
            Console.WriteLine("{0} compared to {1} is {2}", c.Name, d.Name, c.CompareByLength(d)); // c < d returns -1
            c.Name = "Carly";
            d.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", c.Name, d.Name, c.CompareByName(d)); // c == d returns 0
            Console.WriteLine("{0} compared to {1} is {2}", c.Name, d.Name, c.CompareByLength(d)); // c == d returns 0
            c.Name = "Edward";
            d.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", c.Name, d.Name, c.CompareByName(d)); // c > d returns 1
            Console.WriteLine("{0} compared to {1} is {2}", c.Name, d.Name, c.CompareByLength(d)); // c > d returns 1
        }
    }
    public class Item : IComparable
    {
        public string Name;

        public int CompareTo(object o)
        {
            Item that = o as Item;
            return this.Name.CompareTo(that.Name);
        }
    }

    class Display
    {
        public string DisplayOutput(int value)
        {
            switch (value)
            {
                case -1:
                    return "is below";

                case 0:
                    return "is the same as";

                case 1:
                    return "is above";

                default:
                    return "invalid";
            }
        }
    }

    class Comparison : ICompareByName, ICompareByLength
    {
        public string Name { get; set; }

        public int CompareByLength(object o)
        {
            Comparison that = o as Comparison;
            int thisLength = this.Name.ToString().Length;
            int thatLength = that.Name.ToString().Length;
            return thisLength.CompareTo(thatLength);
        }

        // compares by alphabetical order (string.Compare() method)
        public int CompareByName(object o)
        {
            Comparison that = o as Comparison;
            return string.Compare(this.Name, that.Name);
        }        
    }

    interface ICompareByName
    {
        int CompareByName(object o);
    }
    interface ICompareByLength
    {
        int CompareByLength(object o);
    }
}