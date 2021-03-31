/*********************************************************************
 LECTURE EXAMPLES
**********************************************************************/
/*
using static System.Console;
class DisplaySomeMoney2
{
    static void Main()
    {
        // double someMoney = 39.45;
        //Write("The money is $");
        //WriteLine(someMoney);
    }
}


using static System.Console;
class DisplaySomeMoney3
{
    static void Main()
    {
        double someMoney = 39.45;
        Write("The money is ${0} exactly", someMoney);
    }
}
*/

/*
using static System.Console;

namespace CAB201_Week_1__Exercise_1_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
        WriteLine("Hello World!");
        //Format vectors
        WriteLine("{0,5}",4);
        WriteLine("{0,5}",56);
        WriteLine("{0,5}",789);
        WriteLine("{0,-8}{1,-8}","Richard","Lee");
        WriteLine("{0,-8}{1,-8}","Marci","Parker");
        WriteLine("{0,-8}{1,-8}","Ed","Tompkins");
        }
    }
}
*/

//using System;

//public class Clas
//{
//    static void Main()
//    {
//        string a;
//        Console.WriteLine("Enter Data");
//        a = Console.ReadLine();
//        Console.WriteLine("Your name is {0}", a);
//        Console.WriteLine("Your name is " + a);
//        Console.ReadLine();
//    }
//}




/*
    using System;
    public class Example3
{
    public static void Main()
    {
        //data type
        //int byte short long sbyte
        //understanding where to use each data type

        string word = "water";
        word.Substring(0, 1); is "w"
        word.Substring(0, 2); is "wa"




    }
}
*/
/*
using System;
using static System.Console;
class InteractiveSalesTax
{
static void Main()
{
  const double TAX_RATE = 0.06;
  string itemPriceAsString;
  double itemPrice;
  double total;
  Console.Write("Enter the price of an item >> ");
  itemPriceAsString = Console.ReadLine();
  itemPrice = Convert.ToDouble(itemPriceAsString);
  total = itemPrice * TAX_RATE;
  Console.WriteLine("With a tax rate of {0}, a {1} item " +
     "costs {2} more.", TAX_RATE, itemPrice.ToString("C"),
     total.ToString("C"));
}
}
*/
/*
using static System.Console;
class CompareNames1
{
   static void Main()
   {
      string name1 = "Amy";
      string name2 = "Amy";
      string name3 = "Matthew";
      WriteLine("compare {0} to {1}: {2}",
         name1, name2, name1 == name2);
      WriteLine("compare {0} to {1}: {2}",
         name1, name3, name1 == name3);
   }
}

*/
/*
using System;
using static System.Console;
using static System.String;
class CompareNames2
{
   static void Main()
   {
      string name1 = "Amy";
      string name2 = "Amy";
      string name3 = "Matthew";
      WriteLine("{0} and {1}; Equals() method gives {2}",
         name1, name2, name1.Equals(name2));
      WriteLine("{0} and {1}; Equals() method gives {2}",
         name1, name3, name1.Equals(name3));
      WriteLine("{0} and {1}; CompareTo() method gives {2}",
         name1, name2, name1.CompareTo(name2));
      WriteLine("{0} and {1}; CompareTo() method gives {2}",
         name1, name3, name1.CompareTo(name3));
      WriteLine("{0} and {1}; Compare() method gives {2}",
         name1, name2, Compare(name1, name2));
      WriteLine("{0} and {1}; Compare() method gives {2}",
         name1, name3, Compare(name1, name3));
   }
}

*/


/*********************************************************************
 Week 1 Practical
**********************************************************************/
/*
using System; //directive which namespace to take code from
namespace Hello_world //
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
 
*/

/*********************************************************************
 Week 1 AMS
**********************************************************************/

//using System;

//public class HelloWorld
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Hello World - Welcome to CAB201");
//    }
//}

/*
using System;

public class HelloWorld2
{
    public static void Main()
    {
        // Declare a 'string' variable called 'name' to hold the user's name
        string name;

        // Display the message "Please enter your name:  ".
        Console.Write("Please enter your name: ");

        // Use Console.ReadLine to read what the user types into the 'name'
        // variable
        name = Console.ReadLine();

        // Write a single blank line
        Console.WriteLine();

        // Write "Hello {name goes here} - Welcome to CAB201" on a line by
        // itself. Instead of {name goes here} you should put in the name
        // the user gave you.
        // ...
        Console.WriteLine("Hello " + name + " - Welcome to CAB201");
    }
}

*/
/*
using System;

public class StringOrder
{
    enum Order { Precedes = -1, Equals = 0, Follows = 1 };

    public static void Main()
    {
        string nameA;
        string nameB;
        Console.WriteLine("What is name A?");
        nameA = Console.ReadLine();
        Console.WriteLine("What is name B?");
        nameB = Console.ReadLine();
        int num;
        num = String.Compare(nameA, nameB);
        if (num == -1)
        {
            Console.WriteLine(nameA.Substring(6)+" Precedes "+nameB.Substring(6));
        }
        else if (num == 0)
        {
            Console.WriteLine(nameA.Substring(6)+" Equals "+nameB.Substring(6));
        }

        else if (num == 1)
        {
            Console.WriteLine(nameA.Substring(6) + " Follows "+nameB.Substring(6));
        }

        Console.ReadLine();

    }
}

*/

/***************************************************************************************************************
 CHIRAN EXAMPLE
 **************************************************************************************************************
 using System;

public class StringOrder
{
    enum Order { Precedes = -1, Equals = 0, Follows = 1 };

    public static void Main()
    {
        string A, B;
        Console.WriteLine("What is name A?");
        A = Console.ReadLine();
        Console.WriteLine("What is name B?");
        B = Console.ReadLine();
        int C = String.Compare(A, B);
        //enumeration (enum) is used here instead of 'if' and 'switch' statements
        Order result = (Order)C;
        Console.WriteLine("{1} {0} {2}", result, A.Substring(6), B.Substring(6));
    }

}

 */
using System;

public class Matrix
{
    public static void Main()
    {
        int c, r, num, ccount, rcount;
        Console.WriteLine("What is the matrix row count?");
        rcount = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the matrix column count?");
        ccount = int.Parse(Console.ReadLine());
        Console.WriteLine("What is your number?");
        num = int.Parse(Console.ReadLine());

        r = num / ccount;
        c = num % ccount;

        Console.WriteLine(num + " is in row " + r + " and column " + c);
        Console.ReadLine();
    }
}