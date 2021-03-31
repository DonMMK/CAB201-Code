namespace Life
{
    class RectangleStructure : CheckingShapes
    {
        public void FourthParam(int Width, int Height ,int XCoord, int YCoord, int Value, int[,] GameArray)
        {
            for (int X = XCoord; X <= Height; X++)
            {
                for (int Y = YCoord; Y <= Width; Y++)
                {
                    GameArray[X, Y] = Value;
                }
            }
        }
    }
}

