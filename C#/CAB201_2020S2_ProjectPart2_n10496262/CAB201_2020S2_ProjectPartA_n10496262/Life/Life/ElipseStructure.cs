using System;
//USE ONE EQUATION
namespace Life
{

    class ElipseStructure : CheckingShapes
    {


        public void FourthParam(int Width, int Height ,int XCoord, int YCoord, int Value, int[,] GameArray)
        {


            for (int i = 0; i < GameArray.GetLength(0); i++)
            {
                for (int j = 0; j < GameArray.GetLength(1); j++)
                {

                    double FinalResult = ((4 * Math.Pow(i - (double)(Height + XCoord) / 2, 2) / Math.Pow(Height - XCoord + 1, 2)) + (4 * Math.Pow(j - (double)(Width + YCoord) / 2, 2) / Math.Pow(Width - YCoord + 1, 2)));

                    if (FinalResult <= 1)
                    {
                        GameArray[i, j] = Value;
                    }
                }
            }
        }

    }
}