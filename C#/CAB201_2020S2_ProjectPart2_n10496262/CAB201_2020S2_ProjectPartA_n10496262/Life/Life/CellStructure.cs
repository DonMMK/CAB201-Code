namespace Life
{

    class CellStructure : CheckingShapes
    {


        public void CellStruct(int XCoord, int YCoord, ref int[,] GameArray, int Value)
        {
            SecondParam(ref GameArray, XCoord, YCoord, Value);
        }
    }
}