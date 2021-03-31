using System;
using static System.Console;


class MilesPerGallon2

{
    static void Main()
    {
        int milesDriven;
        int gallonsOfGas;
        int mpg;

        try
        {
            Write("Enter miles driven");
            milesDriven = Convert.ToInt32(ReadLine());
            Write("Enter gallons of gas purchased ");
            gallonsOfGas = Convert.ToInt32(ReadLine());
            mpg = milesDriven / gallonsOfGas;

        }
        catch (Exception e)
        {
            mpg = 0;
            WriteLine("You attempted to divide by zero");
        }
        WriteLine("You got {0} miles per gallon", mpg);
    }
}



// For any exception 
// Catch any exception and e is an object of the object class
// Divide by zero error >> goes into the catch and stops the program from crashing
// Maybe you want to give the user
// Give the user a loop

// If you enter string that still catches the same error

// ToString() method system will produce a error message
class MilesPerGallon3

{
    static void Main()
    {
        int milesDriven;
        int gallonsOfGas;
        int mpg;

        try
        {
            Write("Enter miles driven");
            milesDriven = Convert.ToInt32(ReadLine());
            Write("Enter gallons of gas purchased ");
            gallonsOfGas = Convert.ToInt32(ReadLine());
            mpg = milesDriven / gallonsOfGas;

        }
        catch (Exception e)
        {
            mpg = 0;
            WriteLine(e.ToString()); // This will display the system's error message instead of the hard coded one
        }
        WriteLine("You got {0} miles per gallon", mpg);
        ReadLine();
    }
}

// getType()
// use WriteLine(e.Message);
class MilesPerGallon4

{
    static void Main()
    {
        int milesDriven;
        int gallonsOfGas;
        int mpg;

        try
        {
            Write("Enter miles driven");
            milesDriven = Convert.ToInt32(ReadLine());
            Write("Enter gallons of gas purchased ");
            gallonsOfGas = Convert.ToInt32(ReadLine());
            mpg = milesDriven / gallonsOfGas;

        }
        catch (Exception e)
        {
            mpg = 0;
            WriteLine(e.Message); // This will display the system's error message instead of the hard coded one
        }
        WriteLine("You got {0} miles per gallon", mpg);
        ReadLine();
    }
}


// Creating multiple exceptions >>
class TwoErrors

{
    static void Main()
    {
        int num = 13, demon = 0, result;
        int[] array = { 22, 33, 44 };

        try
        {
            result = num / demon;
            result = array[num];

        }
        catch (DivideByZeroException error)
        {
            WriteLine("In first catch block: ");
            WriteLine(error.Message);
        }
        catch (IndexOutOfRangeException error)
        {
            WriteLine("In second catch block: ");
            WriteLine(error.Message);
        }
        ReadLine();
    }
}

// Re order the lines and have the array reference first (result = array[num];)
class TwoErrors2

{
    static void Main()
    {
        int num = 13, demon = 0, result;
        int[] array = { 22, 33, 44 };

        try
        {
            result = array[num];
            result = num / demon;

        }
        catch (DivideByZeroException error)
        {
            WriteLine("In first catch block: ");
            WriteLine(error.Message);
        }
        catch (IndexOutOfRangeException error)
        {
            WriteLine("In second catch block: ");
            WriteLine(error.Message);
        }
        ReadLine();
    }
}



// Instead of two different catch only one. And prints whatever error message
class TwoErrors3

{
    static void Main()
    {
        int num = 13, demon = 0, result;
        int[] array = { 22, 33, 44 };

        try
        {
            result = array[num];
            result = num / demon;

        }
        catch (Exception error)
        {
            WriteLine(error.Message);
        }
        ReadLine();
    }
}


// Poor coding for one method to throw all the exception then the method is doing a lot
// Make sure there isnt "UnreachaBLE" code when writing multiple methods

// Using TryParse and Try and Catch

//  if(!int.TryParse(inputString, out number))   if parsing failed the number gets the default value
//  number = DEFAULT_VALUE;
  
 

// Examining the TryParse method ??


public static bool TryParse(string inputString, out int number)
{
    bool wasSuccessful = true;
    try
    {
        number = Convert.ToInt32(inputString);
    }
    catch (FormatException e)
    {
        wasSuccessful = false;
        number = 0;
    }
    return wasSuccessful;
}


// using the finally block
// If you dont catch all the excpetion the program will bomb
// Always executed and used to tidy up the tasks

/*
try
{
    // Statements that might cause the exception
}
catch (someException anException instance)
    {
    // What to do about it 
}
finally
{
    // Statements here execute
    // whether an Exception occured or not
}
*/

// You can handle exceptions thrown from other methods
// Putting it in a loop so that the user will keep trying until user enters the correct answer.

// Tracing through the call stack
// StackTrace property

// Creating our own exception classes
class NegativeBalanceException : Exception
{
    private static string msg = "Bank balance is negative.";
    public NegativeBalanceException() : base(msg) // This is a constructor 
    {

    }
}

class BankAccount
{
    private double balance;
        public int AccountNum { get; set; }
    public double Balance
    {
        get
        {
            return balance;
        }
        set
        {
            if (value < 0)
            {
                NegativeBalanceException nbe = new NegativeBalanceException();
                throw (nbe);
            }
            balance = value;
        }
    }
}

// Re throwing an exception
