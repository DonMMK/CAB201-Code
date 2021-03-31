using System;

class MatrixLibrary
{
    // Write your methods here...
    public static string MatrixToString(int[,] Array)
    {
        string output = "";
        int row;
        int col;

        // temporary int variable
        int temp;
        // string variable
        string bowwow;

        for(row = 0; row < Array.GetLength(0); ++row)
        {
            for (col = 0; col < Array.GetLength(1); ++col)
            {
                // hold the position element in a temporary variable int
                temp = Array[row, col];

                // convert and string format that variable to a string
                bowwow = string.Format($"{temp,4}");
                // add it to the string matrix
                output += bowwow;
            }

            // add a linefeed character to to the string matrix
            output += ("\n");
        }

        // return the string matrix
        return output;
    }

    public static int[,] MatrixAdd(int[,] ArrayA, int[,] ArrayB)
    {
        int[,] outputAdd = new int[ArrayA.GetLength(0), ArrayA.GetLength(1)];
        int row;
        int col;

        for (row = 0; row < ArrayA.GetLength(0); ++row)
        {
            for (col = 0; col < ArrayA.GetLength(1); ++col)
            {
                outputAdd[row, col] = ArrayA[row, col] + ArrayB[row, col];
            }
        }

        return outputAdd;
    }

    public static int[,] MatrixTranspose(int[,] ArrayA)
    {
        int[,] outputTranspose = new int[ArrayA.GetLength(1), ArrayA.GetLength(0)];
        int row;
        int col;

        for (row = 0; row < ArrayA.GetLength(1); ++row)
        {
            for (col = 0; col < ArrayA.GetLength(0); ++col)
            {
                outputTranspose[row, col] = ArrayA[col, row];
            }
        }

        return outputTranspose;
    }

    public static void Main()
    {
        int[,] A = new int[3, 2] {
            { 0, 1 },
            { 2, 3 },
            { 4, 5 }
        };

        Console.WriteLine($"Original Matrix (A):\n\n{MatrixToString(A)}\n");

        int[,] A2 = MatrixAdd(A, A);

        Console.WriteLine($"A + A:\n\n{MatrixToString(A2)}\n");

        int[,] AT = MatrixTranspose(A);

        Console.WriteLine($"A Transposed:\n\n{MatrixToString(AT)}\n");
    }
}