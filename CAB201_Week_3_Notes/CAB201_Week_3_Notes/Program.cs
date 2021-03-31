
creating an array
    double[] sales;
sales = new double[20];
//Assigning a value to an array element
sales[0] = 2100.00;
//Printing an element value
WriteLine(sales[19]);


using System;

namespace CAB201_Week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Declaring array
            sales[0] = 2100.00

            //Display an array
            WriteLine(sales[19]);

            //Arrays used within the class System.Array
            //Initializer list for an array
            int[] myScores = new int[5] { 100, 76, 88, 100, 90 };
                //size must be mentioned
            int[] myScores = new int[] { 100, 76, 88, 100, 90 };
                //when initialized with values size not needed
            int[] myScores = { 100, 76, 88, 100, 90 };
                //new is not needed

            //Accessing Array Elements
            For(int sub = 0; sub < 5; ++sub)
                myScores[sub] += 3;

            //using the length properly
            int[] myScores = { 100, 76, 88, 100, 90 };
            WriteLine("Array size {0}, myScores.Length ");
            for (int x = 0; x < myScores.Length; ++x)
                WriteLine(myScores[x]);

            //using foreach
            double[] payRate = { 6.00, 7.35, 8.12, 12.45, 22.22 };
            foreach (double money in payRate)
            //same type as array element //money is an object 
                WriteLine("{0}", money.ToString("C"));




        }
    }
}


 * CAB201 Prac
 * Same type of data in the array
 * Specifiy the type
 * eg. int[] array = new int [] { 1, 4, 2, 6, 7 };
 * eg. int[] array = new int [5] //filled with zeros //
 *          << collection of integers  << name of variable << new data and which type number of slots
 *          0 is the default of numbers
 *          for string array the default is >> null >> its not an empty string
 *          
 *          int[] array = new int[7];
 *          
 *          for (int i = 0; i < array.Length; i++) {
 *              Console.WriteLine(array[i]);
 *          }
 *          
 *          method >> is a function > something that can do some tasks > put it in the function
 *           the for loop in line 49 >> prints the array to the console
 *          
 *          function that will format the elements of the array into string
 *                    
*/


using System;

{
        class Program
        static void Main(string[] args)
        {
           int[] array = new int[7];
           Console.WriteLine(ArrayToString(array))

        }
}
//private >> it cant be used by other classes
//static  >> in the context of a variable is shared between all instances of the class


bool ArrayToString(int[] array)
{
    throw new NotImplementedException();
}

*/


