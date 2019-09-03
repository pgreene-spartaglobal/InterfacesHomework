using System;
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

    class Comparison : ICompareByName, ICompareByLength
    {
        public string Name { get; set; }

        public int CompareByLength(object o)
        {
            return 0;
        }

        // compares by alphabetical order (string.Compare() method)
        public int CompareByName(object o)
        {
            Comparison that = o as Comparison;
            return String.Compare(this.Name, that.Name);
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