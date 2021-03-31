using System;

public class RandomArray
{
    // Write your methods here...


       public static int[] Unique(int size)
    {
        int[] RandomInt = new int[size];

        Random rand = new Random();

        for (int i = 0; i < size; ++i)
        {
            int bowwow = rand.Next(1, size + 1); 
            while (Array.IndexOf(RandomInt, bowwow) != -1)
            {
                bowwow = rand.Next(0, size + 1); 
            }

            RandomInt[i] = bowwow; 
        }
        return RandomInt;
    }

    // Main

      public static void Main()
    {
        int size = 50;

        int[] RandomInt = Unique(size);

        for (int i = 0; i < size; ++i)
        {
            Console.WriteLine(RandomInt[i]);
        }
    }
}
