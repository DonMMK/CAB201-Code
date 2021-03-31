//How to make the debugger work ??????

/*
using System;
using static System.Console;

class NestedDecision
{
    public static void Main()
    {
        const int HIGH = 10, LOW = 5;
        string numberString;
        int number;
        Write("Enter an integer");
        numberString = ReadLine();
        number = Convert.ToInt32(numberString);
        if (number > LOW)
        {
            if (number < HIGH)
                WriteLine("{0} is between {1} and {2}", number, LOW, HIGH);
        }
    }
}


using static System.Console;
class MovieDiscount
{
    static void Main()
    {
        int age = 10;
        char rating = 'R';
        const int CHILD_AGE = 12;
        const int SENIOR_AGE = 65;
        WriteLine("When age is {0} and rating is {1}", age, rating);
        if ((age <= CHILD_AGE || age >= SENIOR_AGE) && rating == 'G') //note: no short circuit on &&
            WriteLine("Discount applies");
        else
            WriteLine("Full price");
        ReadLine();
    }
}



using System;

namespace BonusCalculator
{
    class Program
    {
        static void Main()
        {
            string inValue;
            decimal salesForYear;
            decimal bonusAmount = 0M;

            Console.WriteLine("Do you get a bonus this year?");
            Console.WriteLine();
            Console.WriteLine("You may be due for one!");
            Console.WriteLine();
            Console.Write("Enter your gross sales figure: ");

            inValue = Console.ReadLine();
            salesForYear = decimal.Parse(inValue);

            if (salesForYear > 500000.00M)
            {
                Console.WriteLine();
                Console.WriteLine("You get a bonus!");
                bonusAmount = 1000.00M;
            }

            Console.WriteLine();
            Console.WriteLine("Bonus for the year: {0:C}", bonusAmount);

            Console.WriteLine();
            Console.Write("Press any key to exit program...");
            Console.ReadLine();
        }
    }
}
*/

/*
using System;

class IncomeTax
{
    public static void Main()
    {
        double Income;
        double Deduct;
        double Taxed_Amount;
        string SDeduct;
        string SIncome;
        //While loop until correct answer entered
        while (true)
        {
            Console.Write("Enter your taxable income: ");
            SIncome = Console.ReadLine();

            //Check the validity of the input
            if (double.TryParse(SIncome, out Income))
                if (Income > 0)
                    break;
                else
                    Console.WriteLine("WARNING: You must enter a positive value.");
            else
            Console.WriteLine("WARNING: You must enter a valid number.");
        }

        //While loop until correct answer entered
        while (true)
        {
            Console.Write("Enter your tax deduction: ");
            SDeduct = Console.ReadLine();

            //Check the validity of the input
            if (double.TryParse(SDeduct, out Deduct))
                if (Deduct > 0)
                    break;
                else
                    Console.WriteLine("WARNING: You must enter a positive value.");
            else
                Console.WriteLine("WARNING: You must enter a valid number.");
        }

        //rounded down to nearest whole dollar before calc tax
        Income = Math.Floor(Income);
        Deduct = Math.Floor(Deduct);
        //Income - Deduct before calc Taxed_Amount
        Income = Income - Deduct;

        //If number entered is acceptable
        if (Income >= 0 && Income < 18200)
                Taxed_Amount = 0;
            else if (Income >= 18201 && Income < 37000)
                Taxed_Amount = 0.19 * (Income - 18200);
            else if (Income >= 37001 && Income < 90000)
                Taxed_Amount = 3572 + 0.325 * (Income - 37000);
            else if (Income >= 90001 && Income < 180000)
                Taxed_Amount = 20797 + 0.37 * (Income - 90000);
            else
            Taxed_Amount = 54097 + 0.45 * (Income - 180000);

        Console.Write("Your tax after deductions is: {0:C2}",Taxed_Amount);

    }//END MAIN
}//END SYSTEM



 using System;

public class StringConversion
{
public static void Main()
{
   string input = String.Empty;
   try
   {
       int result = Int32.Parse(input);
       Console.WriteLine(result);
   }
   catch (FormatException)
   {
       Console.WriteLine($"Unable to parse '{input}'");
   }
   // Output: Unable to parse ''

   try
   {
        int numVal = Int32.Parse("-105");
        Console.WriteLine(numVal);
   }
   catch (FormatException e)
   {
       Console.WriteLine(e.Message);
   }
   // Output: -105

    if (Int32.TryParse("-105", out int j))
        Console.WriteLine(j);
    else
        Console.WriteLine("String could not be parsed.");
    // Output: -105

    try
    {
        int m = Int32.Parse("abc");
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
    }
    // Output: Input string was not in a correct format.

    string inputString = "abc";
    if (Int32.TryParse(inputString, out int numValue))
        Console.WriteLine(inputString);
    else
        Console.WriteLine($"Int32.TryParse could not parse '{inputString}' to an int.");
    // Output: Int32.TryParse could not parse 'abc' to an int.
 }
}
*/

/*
using System;

class ConversionTable
{
 
    public static void Main()
    {
        double KPH;
        double MPH = 15;
        //bool BInput;
        //char or string rows;
        Console.Write("Enter the number of rows (q to quit):");
        string input = Console.ReadLine();
        int rows = int.Parse(input);

       
        //int count = 0;
        Console.WriteLine("MPH\tKPH");
        while (true)
        {
            //convert to bool
           
            //break if q entered
            if (input == "q")
                break;
            else
            //Display the conversion
            KPH = 0.62137 * MPH;
            //use the \t to add tab
            Console.WriteLine("{0}\t{1}",MPH, KPH );
            MPH = MPH + 10;
        }
       
    }
}


using static System.Console;

using static System.Convert;



class ConversionTable

{

    public static void Main()

    {

        double KPH;

        double MPH = 15;

        string rows;



        while (true)

        {
            Write("Enter the number of rows (q to quit): ");
            rows = (ReadLine());

            if (rows == "q")

                break;



            else
                if (count )
            {
                WriteLine("MPH\tKPH");
                KPH = 0.62137 * MPH;

                WriteLine("{0}\t{1}", MPH, KPH);

                MPH += 10;
            }
        }
    }

}
*/

using static System.Console;



class ConversionTable

{

    public static void Main()

    {

        double KPH;

        double MPH = 15.00;

        string rows;



        while (true)

        {
            Write("Enter the number of rows (q to quit): ");
            rows = ReadLine();

            if (rows == "q")

                break;



            else
                WriteLine("MPH\tKPH");

            for (int i = 0; i < int.Parse(rows); ++i)
            {
                KPH = 1.609347 * MPH;
                WriteLine("{0}\t{1:F2}", MPH, KPH);
                MPH += 10;
            }

            MPH = 15.00;

        }
    }

}