# InterfacesHomework
    
# Homework Lab Instructions

Run the following code and step through it using breakpoints in order to understand what is happening

~~~~
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IComparable_01
{
	class Program
	{
	    static void Main(string[] args)
	    {
	        var a = new Item();
	        var b = new Item();
	        a.Name = "Bob";
	        b.Name = "Carly";
	        Console.WriteLine("{0} compared to {1} is {2}",a.Name,b.Name,a.CompareTo(b));
	        a.Name = "Carly";
	        b.Name = "Carly";
	        Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
	        a.Name = "Edward";
	        b.Name = "Carly";
	        Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
	    }
	}
	public class Item : IComparable
	{
	    public string Name;
	    
	    public int CompareTo(object o) {
	        Item that = o as Item;
	        return this.Name.CompareTo(that.Name);
	    }
	}
}
~~~~

Bonus Lab

If you are feeling adventurous create a fresh set of two interfaces

~~~~
ICompareByName{
	int CompareByName();
}
ICompareByLength{
	int CompareByLength();
}
~~~~

Declare a class Comparison which implements both interfaces and has one string property 'Name'.

~~~~
class Comparison{
	public string Name {get; set;}
}
~~~~

Add the correct access modifiers to the code above (Visual Studio should help)

Implement the interfaces in the class then code out the two methods to permit comparison of two strings


	
	
CompareByName() : compares by alphabetical order (string.Compare() method)
	
	
	
CompareByLength() : compares by length (custom build your own code here)
	


See if you can manage to build an application which accepts two strings and compares them both alphabetically and also by length.

The output should read something like

'String1 is above/below/the same as String2 alphabetically'

'String1 is shorter/longer/the same length compared to String2'

# Implementation
## Explanation of initial code 
Declare two variables a and b of type Item and assign "Bob" and "Carly" to the Name field respectively.

To compare the two string values the CompareTo() method from the IComparable interface implemented on Item is called.

How CompareTo() works:

* if a < b return -1
* if a == b return 0
* if a > b return 1
