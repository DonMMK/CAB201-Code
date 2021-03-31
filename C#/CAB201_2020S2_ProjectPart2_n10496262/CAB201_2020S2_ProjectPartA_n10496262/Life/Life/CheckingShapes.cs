namespace Life
{
    abstract class CheckingShapes
    {
        virtual public void FourthParam(int XCoord, int YCoord, int Width, int Height, int Value, ref int[,] GameArray  )
        {

        }
        public void SecondParam(ref int[,] GameArray, int XCoord, int YCoord, int Value)
        {
            GameArray[XCoord , YCoord] = Value;
        } 
    }
}