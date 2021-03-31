using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Display;


namespace Life
{
    class Program
    {
        /// <summary>
        /// Checks the parameters the user has input for the dimensions of the simulation
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <param name="CheckAllConditions"></param>
        static void CheckDimensions(ref string[] args, ref int count, ref int Rows,
                                ref int Columns, ref bool CheckAllConditions)
        {

            if (args[count] == "--dimensions")
            {
                try
                {
                    if (int.Parse(args[count + 1]) >= 4 & int.Parse(args[count + 1]) <= 48)
                    {
                        Rows = int.Parse(args[count + 1]);
                    }
                    else
                    {
                        Console.WriteLine("Error in input for rows. Please enter a number between 4 and 48");
                        CheckAllConditions = false;
                    }

                    if (int.Parse(args[count + 2]) > 3 & int.Parse(args[count + 2]) < 49)
                    {
                        Columns = int.Parse(args[count + 2]);
                    }
                    else
                    {
                        Console.WriteLine("Error in input for columns. Please enter a number between 4 and 48");
                        CheckAllConditions = false;
                    }

                }
                catch
                {
                    Console.WriteLine("Error. Please enter numerical inputs");
                    CheckAllConditions = false;
                }
            }
        }

        /// <summary>
        /// Checks if the user has input if the simulation should behave periodically
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="PeriodicBehaviour"></param>
        static void CheckPeriodic(ref string[] args, ref int count, ref bool PeriodicBehaviour)
        {

            if (args[count] == "--periodic")
            {
                PeriodicBehaviour = true;
            }
        }

        /// <summary>
        /// Checks the user input for the randomness of live cells in the simulation
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="RandFactor"></param>
        /// <param name="CheckAllConditions"></param>
        static void CheckRandomFactor(ref string[] args, ref int count, ref double RandFactor,
                                                                    ref bool CheckAllConditions)
        {

            if (args[count] == "--random")
            {
                try
                {
                    if (double.Parse(args[count + 1]) >= 0 & double.Parse(args[count + 1]) <= 1)
                    {
                        RandFactor = double.Parse(args[count + 1]);
                    }
                    else
                    {
                        Console.WriteLine("Error in input. Please enter a value between 0 and 1 for the random factor");
                        CheckAllConditions = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Error in input. Please enter a number as the random factor");
                    CheckAllConditions = false;
                }
            }
        }

        /// <summary>
        /// Checks the seed file given by the user. 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="InputFile"></param>
        /// <param name="CheckAllConditions"></param>
        static void CheckSeedfile(ref string[] args, ref int count, ref string InputFile, ref bool CheckAllConditions)
        {

            if (args[count] == "--seed")
            {

                if (args[count + 1].EndsWith(".seed"))
                {
                    InputFile = args[count + 1];

                }
                else
                {
                    Console.WriteLine("The input needs to be a seed file. Please check again");
                    CheckAllConditions = false;
                }

            }
        }




        /// <summary>
        /// Checks if user has inputted parameters for number of generations in the simulation
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="Generations"></param>
        /// <param name="CheckAllConditions"></param>
        static void GenerationMethod(ref string[] args, ref int count, ref int Generations, ref bool CheckAllConditions)
        {

            if (args[count] == "--generations")
            {
                try
                {
                    if (int.Parse(args[count + 1]) > 0)
                    {
                        Generations = int.Parse(args[count + 1]);
                    }
                    else
                    {
                        Console.WriteLine("Error in input. Please enter a non zero positive integer");
                        CheckAllConditions = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Error in input please enter a number as the value for generations");
                    CheckAllConditions = false;
                }
            }
        }

        /// <summary>
        /// Checks the update rate given by the user.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="MaxUpdateRate"></param>
        /// <param name="CheckAllConditions"></param>
        static void MaxUpdaterate(ref string[] args, ref int count, ref double MaxUpdateRate, ref bool CheckAllConditions)
        {

            if (args[count] == "--max-update")
            {
                try
                {
                    if (double.Parse(args[count + 1]) >= 1 & double.Parse(args[count + 1]) <= 30)
                    {
                        MaxUpdateRate = double.Parse(args[count + 1]);
                    }
                    else
                    {
                        Console.WriteLine("Error in input. Please enter a number between 1 and 30");
                        CheckAllConditions = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Error in input. Please enter a proper value for max update rate");
                    CheckAllConditions = false;
                }
            }
        }

        /// <summary>
        /// Checks if step mode needs to be enabled
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="StepMode"></param>
        static void StepModeMethod(ref string[] args, ref int count, ref bool StepMode)
        {

            if (args[count] == "--step")
            {
                StepMode = true;
            }
        }

        /// <summary>
        /// Allocates seed file into array and checks the seed file. Unless
        /// coordinate size is oo big or file doesnt existi that case random assigning is done.
        /// </summary>
        /// <param name="InputFile"></param>
        /// <param name="Columns"></param>
        /// <param name="Rows"></param>
        /// <param name="GameArray"></param>
        /// <param name="RandFactor"></param>
        static void RandomnessMethod(ref string InputFile, ref int Columns, ref int Rows,
            ref int[,] GameArray, ref double RandFactor)
        {
            if (InputFile != "")
            {
                StreamReader Streamreader;
                string StreamValue = "";

                try
                {
                    Streamreader = new StreamReader(InputFile);
                    Streamreader.ReadLine();
                    StreamValue = Streamreader.ReadToEnd();
                }
                catch
                {
                    Console.WriteLine("File doenst exist. Please check");
                }


                string[] Contents = StreamValue.Split("\n");

                int rowsMax = 0;

                int columnsMax = 0;

                List<int> rowsList = new List<int>();

                List<int> columnsList = new List<int>();

                bool ExceedSize = false;

                for (int index = 0; index < Contents.Length - 1; index++)
                {
                    columnsList.Add(int.Parse(Contents[index].Split(' ')[1]));

                    rowsList.Add(int.Parse(Contents[index].Split(' ')[0]));

                    if (columnsList[index] > Columns && columnsList[index] > columnsMax)
                    {
                        //ExceedSize = true;

                        columnsMax = columnsList[index];
                    }

                    if (rowsList[index] > Rows && rowsList[index] > rowsMax)
                    {
                        //ExceedSize = true;

                        rowsMax = rowsList[index];
                    }


                }
                for (int itera = 0; itera < rowsList.Count; ++itera)
                {
                    GameArray[rowsList[itera], columnsList[itera]] = 1;

                }

                if (ExceedSize)
                {
                    Console.WriteLine("The size of it is to big. " +
                        "The appropriate values are {0}, {1}", rowsMax, columnsMax);
                }

                else
                {

                }

            }
            else
            {
                Random random = new Random();
                int R = 0;

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        R = random.Next(0, 100);
                        if (R < RandFactor * 100)
                        {
                            GameArray[i, j] = 1;

                        }
                    }

                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GameArray"></param>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <param name="output"></param>
        static void OutputFileLogic(ref int[,] GameArray, int Rows, int Columns, string output)
        {

            {
                if (output != "N/A")
                {
                    StreamWriter OutputFileWritten = new StreamWriter(output);
                    using (OutputFileWritten)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            for (int i = 0; i < Rows; i++)
                            {
                                if (GameArray[i, j] == 1)
                                {
                                    OutputFileWritten.WriteLine("(o) cell: " + i + ", " + j);
                                }
                            }
                        }
                    }
                }
            }





        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AliveOrDead"></param>
        /// <param name="ChangeLocation"></param>
        /// <param name="GameState"></param>
        /// <param name="KnowStep"></param>
        /// <param name="Birth"></param>
        /// <param name="Survival"></param>
        static void NeighbourCells(ref int AliveOrDead, ref int ChangeLocation, int GameState, bool KnowStep, List<int> Birth, List<int> Survival)
        {
            if (AliveOrDead != 1)
            {


                if (Birth.Contains(GameState))
                {
                    ChangeLocation = 1;
                }
                else
                {
                    if (KnowStep)
                    {
                        if (AliveOrDead == 2)
                        {
                            ChangeLocation = 3;
                        }
                        else if (AliveOrDead == 3)
                        {
                            ChangeLocation = 4;
                        }
                        else
                        {
                            ChangeLocation = 0;
                        }
                    }
                    else
                    {
                        ChangeLocation = 0;
                    }
                }
            }


            else if (AliveOrDead == 1)
            {
                if (Survival.Contains(GameState))
                {
                    ChangeLocation = 1;
                }
                else
                {
                    if (KnowStep)
                    {
                        ChangeLocation = 2;
                    }
                    else
                    {
                        ChangeLocation = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GameArray"></param>
        /// <param name="CheckAllConditions"></param>
        /// <param name="streamReader"></param>
        /// <returns></returns>
        static bool Seed(ref int[,] GameArray, ref bool CheckAllConditions, StreamReader streamReader)
        {
            int XMax = 0;
            int YMax = 0;

            const int Minimum = 3;

            string Readall = streamReader.ReadToEnd();

            string[] Liine = Readall.Split('\n');

            int[] XCoordinate = new int[Liine.Length - 1];
            int[] YCoordinate = new int[Liine.Length - 1];

            for (int num = 1; num < Liine.Length; num++)
            {
                XCoordinate[num - 1] = int.Parse(Liine[num - 1].Split(' ')[0]);
                YCoordinate[num - 1] = int.Parse(Liine[num - 1].Split(' ')[1]);

                if (XCoordinate[num - 1] > XMax)
                {
                    XMax = XCoordinate[num - 1];
                }
                if (YCoordinate[num - 1] > YMax)
                {
                    YMax = YCoordinate[num - 1];
                }
            }


            if (YMax > GameArray.GetLength(1) - 1 || XMax > GameArray.GetLength(0) - 1)
            {
                if (YMax < Minimum)
                {
                    YMax += Minimum;
                }
                if (XMax < Minimum)
                {
                    XMax += Minimum;
                }
                CheckAllConditions = false;

                Console.WriteLine("The seed file exceeds the specifications. The recomended size is " + (XMax + 1) + ", " + (YMax + 1) + "The game will use default settings instead");

                return false;
            }
            else
            {
                CellStructure CellStruct = new CellStructure();


                for (int num = 0; num < XCoordinate.Length; num++)
                {
                    CellStruct.SecondParam(ref GameArray, XCoordinate[num], YCoordinate[num], 1);
                }


                return true;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GameArray"></param>
        /// <param name="CheckAllConditions"></param>
        /// <param name="streamreader"></param>
        /// <returns></returns>
        public static bool SeedFile02(ref int[,] GameArray, ref bool CheckAllConditions, StreamReader streamreader)
        {
            string Readall = streamreader.ReadToEnd().Trim();

            //split by number of co-ordinates
            string[] Liine = Readall.Split('\n');
            string[] splited = new string[Liine.Length];

            int[] Height = new int[Liine.Length];
            int[] Width = new int[Liine.Length];
            int[] XCoordinate = new int[Liine.Length];
            int[] YCoordinate = new int[Liine.Length];
            string[] GameState = new string[Liine.Length];


            //Assigning values from seed to arrays
            for (int num = 0; num < Liine.Length; num++)
            {

                //split each line to their x and y
                splited[num] = Liine[num].Split(",")[0];
                YCoordinate[num] = int.Parse(Liine[num].Split(",")[1]);

                GameState[num] = splited[num].Split(":")[0];
                XCoordinate[num] = int.Parse(splited[num].Split(":")[1]);


                if (!Liine[num].Contains("cell"))
                {
                    Height[num] = int.Parse(Liine[num].Split(",")[2]);
                    Width[num] = int.Parse(Liine[num].Split(",")[3]);
                }
                Console.WriteLine(Width[num] + " " + Height[num] + " " + XCoordinate[num] + " " + YCoordinate[num] + " " + GameState[num]);
            }

            for (int num = 0; num < Liine.Length; num++)
            {

                if (GameState[num].Contains("cell"))
                {

                    if (ToCheckCells(XCoordinate, YCoordinate, ref CheckAllConditions, GameArray.GetLength(0), GameArray.GetLength(1)))
                    {
                        return false;
                    }
                }

                else
                {
                    if (ToCheckNOTCells(ref XCoordinate, YCoordinate, Width, Height, ref CheckAllConditions, GameArray.GetLength(0), GameArray.GetLength(1)))
                    {
                        return false;
                    }
                }
            }

            for (int num = 0; num < XCoordinate.Length; num++)
            {

                if (GameState[num].Contains("cell"))
                {
                    CellStructure CellStruct = new CellStructure();

                    if (GameState[num].Contains("(o)"))
                    {
                        CellStruct.SecondParam(ref GameArray, XCoordinate[num], YCoordinate[num], 1);
                    }
                    else
                    {
                        CellStruct.SecondParam(ref GameArray, XCoordinate[num], YCoordinate[num], 0);
                    }
                }

                else if (GameState[num].Contains("rectangle"))
                {
                    RectangleStructure RectStruct = new RectangleStructure();

                    if (GameState[num].Contains("(o)"))
                    {
                        RectStruct.FourthParam(Width[num], Height[num], XCoordinate[num], YCoordinate[num], 1, ref GameArray);

                    }
                    else
                    {
                        RectStruct.FourthParam(Width[num], Height[num], XCoordinate[num], YCoordinate[num], 0, ref GameArray);
                    }
                }

                else
                {
                    ElipseStructure Ellipse = new ElipseStructure();

                    if (GameState[num].Contains("(o)"))
                    {
                        Ellipse.FourthParam(Width[num], Height[num], XCoordinate[num], YCoordinate[num], 1, ref GameArray);

                    }
                    else
                    {
                        Ellipse.FourthParam(Width[num], Height[num], XCoordinate[num], YCoordinate[num], 0, ref GameArray);

                    }
                }
            }


            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="Neighbourhood"></param>
        /// <param name="NeighbourhoodOrder"></param>
        /// <param name="IsCenterCounted"></param>
        /// <param name="Columns"></param>
        /// <param name="Rows"></param>
        /// <param name="CheckAllConditions"></param>
        static void WhichNeighbourhood(ref string[] args, ref int count, ref string Neighbourhood
            , ref int NeighbourhoodOrder, ref bool IsCenterCounted, ref int Columns, ref int Rows, ref bool CheckAllConditions)
        {
            if (args[count] == "--neighbour")
            {
                int NumberOfErrors = 0;
                try
                {
                    //What are the given command after neighbourhood
                    if (args[count + 1].Contains("--"))
                    {
                        Console.WriteLine("If neighbourhood implemented it should be followed by the neighbouhood type, " +
                            " and order must" +
                            "  be less than half of the smallest dimensions, enter if the center should be counted ");
                        // Defualt setttings are used
                        Neighbourhood = "Moore";
                        NeighbourhoodOrder = 1;
                        IsCenterCounted = false;
                        CheckAllConditions = false;
                    }
                    // Keep checking the user input parameters for neighbourhoods
                    if (args[count + 2].Contains("--"))
                    {
                        Console.WriteLine("The neighbourhood order must be within the range of 1 and 10 (included) order must" +
                            " also be less than half of the smallest dimensions, enter if the center should be counted");

                        Neighbourhood = args[count + 1];
                        NeighbourhoodOrder = 1;
                        IsCenterCounted = false;
                        CheckAllConditions = false;
                    }
                    if (args[count + 3].Contains("--"))
                    {
                        Console.WriteLine("Enter true or false if center is counted");
                        Neighbourhood = args[count + 1];
                        NeighbourhoodOrder = int.Parse(args[count + 2]);
                        IsCenterCounted = false;
                        CheckAllConditions = false;
                    }
                    if (!args[count + 2].Contains("--") && !args[count + 1].Contains("--") && !args[count + 3].Contains("--"))
                    {
                        if (!int.TryParse(args[count + 2], out NeighbourhoodOrder))
                        {
                            Console.WriteLine("Please enter the order of the neighbourhoods as number");
                            NeighbourhoodOrder = 1;
                            NumberOfErrors = NumberOfErrors + 1;
                            CheckAllConditions = false;
                        }
                        if (NumberOfErrors == 0)
                        {
                            if (args[count + 1].ToLower() == "moore")
                            {
                                Neighbourhood = "Moore";
                            }
                            else if (args[count + 1].ToLower() == "vonneuman")
                            {
                                Neighbourhood = "vonNeumann";
                            }
                            else
                            {
                                Console.WriteLine("Please enter either moore or vonNeuman as the neighbourhood");
                                CheckAllConditions = false;
                            }

                            int SmallestDimensions = 0;
                            if (Columns >= Rows)
                            {
                                SmallestDimensions = Rows;
                            }
                            else
                            {
                                SmallestDimensions = Columns;
                            }


                            NeighbourhoodOrder = int.Parse(args[count + 2]);
                            if (NeighbourhoodOrder < 0 || NeighbourhoodOrder >= 10 || NeighbourhoodOrder > (SmallestDimensions / 2))
                            {
                                NeighbourhoodOrder = 1;
                                Console.WriteLine("The Neighbourhood order should be a value between 1 and 10 included and must be less than half of lowest dimension size");
                                //Settings = false
                            }
                            if (args[count + 3].ToLower() == "true")
                            {
                                IsCenterCounted = true;
                            }
                            else if (args[count + 3].ToLower() == "false")
                            {
                                IsCenterCounted = false;
                            }
                            else
                            {
                                Console.WriteLine("The option to count th center must be entered as either true or false");
                                //Setings = false;
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Neighbourhood parameters must be provided. Please check input");
                    //Setings = false;

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="XCoordinate"></param>
        /// <param name="YCoordinate"></param>
        /// <param name="CheckAllConditions"></param>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <returns></returns>
        static bool ToCheckCells(int[] XCoordinate, int[] YCoordinate, ref bool CheckAllConditions, int Rows, int Columns)
        {
            //Seed file values 

            int XMax = 0;
            int YMax = 0;

            //minimum co-ordinate needed for grid to function
            const int Minimum = 3;

            for (int num = 0; num < XCoordinate.Length; num++)
            {
                //identify the highest x and y cordinate 
                if (XCoordinate[num] > XMax)
                {
                    XMax = XCoordinate[num];
                }
                if (YCoordinate[num] > YMax)
                {
                    YMax = YCoordinate[num];
                }
            }
            //recommend larger dimension size if the current dimension is too small 
            if (YMax > Columns - 1 || XMax > Rows - 1)
            {
                Console.WriteLine(XMax + ", " + YMax);
                //Recommend a functionable row and column size that fits within the game limits
                if (YMax < Minimum)
                {
                    YMax += Minimum;
                }
                if (XMax < Minimum)
                {
                    XMax += Minimum;
                }

                CheckAllConditions = false;

                Console.WriteLine("Seed file has specifications out of dimensions" +
                       "The recomended size is: " + (XMax + 1) + ", " + (YMax + 1) + " Default settings will be used ");

                return true;   /////////////////////////////////////////////////////
            }
            else
            {
                return false; //////////////////////////////////////////////////////
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="XCoordinate"></param>
        /// <param name="YCoordinate"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="CheckAllConditions"></param>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <returns></returns>
        static bool ToCheckNOTCells(ref int[] XCoordinate, int[] YCoordinate, int[] Width, int[] Height, ref bool CheckAllConditions, int Rows, int Columns)
        {
            //Highest coordinates in given seed file
            int XMax = 0;
            int YMax = 0;

            //minimum co-ordinate needed for grid to function
            const int Minimum = 3;

            for (int num = 0; num < XCoordinate.Length; num++)
            {
                //identify the highest x and y cordinate 
                if (Height[num] > XMax)
                {
                    XMax = Height[num];
                }
                if (Width[num] > YMax)
                {
                    YMax = Width[num];
                }
            }
            //recommend larger dimension size if the current dimension is too small 
            if (XMax > Columns - 1 || YMax > Rows - 1)
            {
                //Recommend a functionable row and column size that fits within the game limits
                if (YMax < Minimum)
                {
                    YMax += Minimum;
                }
                if (XMax < Minimum)
                {
                    XMax += Minimum;
                }

                CheckAllConditions = false;
                Console.WriteLine("Seed file has specifications out of dimensions" +
                       "The recomended size is: " + (XMax + 1) + ", " + (YMax + 1) + " Default settings will be used ");

                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="SurvivalLawSpecified"></param>
        /// <param name="BirthLawSpecified"></param>
        /// <param name="SurvivalLaw"></param>
        /// <param name="BirthLaw"></param>
        static void SurvivalandBirth(ref string[] args, ref int count, ref string SurvivalLawSpecified, ref string BirthLawSpecified, ref List<int> SurvivalLaw, ref List<int> BirthLaw)
        {
            // Check survival
            if (args[count] == "--survival")
            {


                int ii = 0; int LOWCELL = 0; int HIGHCELL = 0;

                while (count + ii < args.Length - 1)
                {
                    try
                    {
                        if (!args[count + ii + 1].Contains("--"))
                        {
                            SurvivalLawSpecified += args[count + ii + 1] + " ";

                            if (args[count + 1 + ii].Contains("..."))
                            {
                                LOWCELL = int.Parse(args[(count + 1) + ii].Split("...")[0]);
                                HIGHCELL = int.Parse(args[(count + 1) + ii].Split("...")[1]);
                                for (int jj = LOWCELL; jj <= HIGHCELL; jj++)
                                {
                                    SurvivalLaw.Add(jj);
                                }
                            }
                            else
                            {
                                if (int.Parse(args[count + 1] + ii) < -1)
                                {
                                    Console.WriteLine("Error found with the number entered for survival refer" + (ii + 1) + " index");
                                }
                                else
                                {
                                    SurvivalLaw.Add(int.Parse(args[count + ii + 1]));
                                }
                            }
                            ii++;
                        }
                        else
                        {
                            break;
                        }
                    }


                    catch
                    {
                        Console.WriteLine("Numbers entered for surival wrong and should be reentered as: startnumber...end, the error is at" + (ii + 1) + "index");
                        ii++;
                    }
                }
            }


            if (args[count] == "--birth")
            {
                int ii = 0; int LOWCELL = 0; int HIGHCELL = 0;

                while (count + ii < args.Length - 1)
                {
                    try
                    {
                        if (!args[count + ii + 1].Contains("--"))
                        {
                            BirthLawSpecified += args[count + ii + 1] + " ";

                            if (args[count + 1 + ii].Contains("..."))
                            {
                                LOWCELL = int.Parse(args[(count + 1) + ii].Split("...")[0]);
                                HIGHCELL = int.Parse(args[(count + 1) + ii].Split("...")[1]);
                                for (int jj = LOWCELL; jj <= HIGHCELL; jj++)
                                {
                                    BirthLaw.Add(jj);
                                }

                            }
                            else
                            {
                                if (int.Parse(args[count + ii + 1]) < -1)
                                {
                                    Console.WriteLine("Error found with the number entered for birth refer" + (ii + 1) + " index");
                                }
                                else
                                {
                                    BirthLaw.Add(int.Parse(args[count + ii + 1]));
                                }
                            }
                            ii++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Numbers entered for birth wrong and should be reentered as: startnumber...end, the error is at" + (ii + 1) + "index");
                        ii++;
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="memory"></param>
        static void GenerationalMemory(ref string[] args, ref int count, ref int memory, ref bool CheckAllConditions)
        {
            if (args[count] == "--memory")
            {
                try
                {
                    if (int.Parse(args[count + 1]) >= 4 && int.Parse(args[count + 1]) <= 512)
                    {
                        memory = int.Parse(args[count + 1]);
                    }
                    else
                    {
                        Console.WriteLine(" Input for memeory must be between 4 and 512");
                        //Settings = false
                    }
                }
                catch
                {
                    Console.WriteLine("Please provide a value for memory");
                    //settings = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="output"></param>
        static void OutputFile(ref string[] args, ref int count, ref string output)
        {
            if (args[count] == "--output")
            {
                try
                {
                    if (args[count + 1].Contains("--"))
                    {
                        Console.WriteLine("Please provide a value for output");
                        //Settings = false
                    }
                    else
                    {
                        if (args[count + 1].EndsWith(".seed"))
                        {
                            output = args[count + 1];
                        }
                        else
                        {
                            Console.WriteLine("please use a .seed as output file");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please provide a value for output");
                    //Settings = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="count"></param>
        /// <param name="GhostMode"></param>
        static void GhostModeMethod(ref string[] args, ref int count, ref bool GhostMode)
        {
            if (args[count] == "ghost")
            {
                GhostMode = true;
            }
        }

        /// <summary>
        /// Contains the code displayed before simulation is started. This contains the inputs of the user
        /// </summary>
        /// <param name="CheckAllConditions"></param>
        /// <param name="InputFile"></param>
        /// <param name="Generations"></param>
        /// <param name="MaxUpdateRate"></param>
        /// <param name="PeriodicBehaviour"></param>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <param name="StepMode"></param>
        /// <param name="RandFactor"></param>
        static void DispUserInput(ref bool CheckAllConditions, ref string InputFile, ref int Generations,
            ref double MaxUpdateRate, ref bool PeriodicBehaviour, ref int Rows,
            ref int Columns, ref bool StepMode, ref double RandFactor, ref int memory, ref string output,
            ref List<int> SurvivalLaw, ref List<int> BirthLaw, ref string SurvivalLawSpecified, ref string BirthLawSpecified, ref bool GhostMode)
        {
            if (CheckAllConditions == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success: Command line arguments processed.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (CheckAllConditions == false)
            {
                Console.WriteLine("Failed: One or more command line argments failed to " +
                    "implement therefore code will use the default values.");
            }
            Console.WriteLine("The program will use the following settings:\n");

            if (InputFile == "")
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", "InputFile:", "N/A"));
            }
            else
            {
                Console.WriteLine(String.Format("{0,20} {1,-15}", "Input File:", InputFile));
            }

            if (output == "")
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", "InputFile:", "N/A"));
            }
            else
            {
                Console.WriteLine(String.Format("{0,20} {1,-15}", "Output File:", output));
            }


            Console.WriteLine(String.Format("{0, 20} {1, -15}", "Generations:", Generations));

            Console.WriteLine(String.Format("{0, 20} {1, -15}", "Memory:", memory));



            Console.WriteLine(String.Format("{0, 20} {1, -15}", "Refresh Rate:", MaxUpdateRate + " updates/s"));




            if (SurvivalLaw.Count == 2 && SurvivalLaw[0] == 2 && SurvivalLaw[1] == 3)
            {
                Console.Write(String.Format("{0, 20} {1, -15}", "Rules: S( ", " 2...3"));
            }
            else
            {
                Console.Write(String.Format("{0, 20} {1, -15}", "Rules: S( ", SurvivalLawSpecified));
            }


            if (BirthLaw.Count == 1 && BirthLaw[0] == 3)
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", ") B ( ", "3)"));
            }
            else
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", ") B ( ", BirthLawSpecified + ")"));
            }




            if (PeriodicBehaviour == true)
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", "Periodic:", "Yes"));
            }
            else
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", "Periodic:", "No"));
            }

            Console.WriteLine(String.Format("{0, 20} {1, -15}", "Rows:", Rows));
            Console.WriteLine(String.Format("{0, 20} {1, -15}", "Columns:", Columns));

            Console.WriteLine(String.Format("{0, 20} {1, -1} {2, 0}", "Random Factor:", RandFactor * 100.00, "%"));

            if (StepMode == false)
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", "Step Mode:", "No"));
            }
            else
            {
                Console.WriteLine(String.Format("{0, 20} {1, -15}", "Step Mode:", "Yes"));
            }


            Console.WriteLine(String.Format("{0, 20} {1, -15}", "Ghost Mode:", GhostMode));



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Columns"></param>
        /// <param name="Rows"></param>
        /// <param name="XChecking"></param>
        /// <param name="YChecking"></param>
        /// <param name="GameArray"></param>
        /// <param name="AliveNumber"></param>
        /// <param name="PeriodicBehaviour"></param>
        static void HowManyAlive(int Columns, int Rows, int XChecking, int YChecking, int[,] GameArray, ref int AliveNumber, bool PeriodicBehaviour)
        {
            if (PeriodicBehaviour)
            {


                int Y = YChecking;

                if (YChecking >= Columns)
                {
                    Y = YChecking - Columns;
                }

                else if (YChecking <= -1)
                {
                    Y = YChecking + Columns; ;
                }

                int X = XChecking;
                if (XChecking >= Rows)
                {
                    X = XChecking - Rows;
                }
                else if (XChecking <= -1)
                {
                    X = XChecking + Rows;
                }

                if (GameArray[X, Y] == 1)
                {
                    AliveNumber += 1;

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GameArray"></param>
        /// <param name="XChecking"></param>
        /// <param name="YChecking"></param>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <param name="PeriodicBehaviour"></param>
        /// <param name="order"></param>
        /// <param name="AliveNumber"></param>
        static void GameLogicHelper(ref int[,] GameArray, int XChecking, int YChecking, int Rows, int Columns, bool PeriodicBehaviour, int order, ref int AliveNumber)
        {
            if (XChecking < Rows && XChecking > -1 && YChecking > -1 && YChecking < Columns)
            {
                if (GameArray[XChecking, YChecking] == 1)
                {
                    AliveNumber += 1;
                }
            }
            else
            {
                HowManyAlive(Columns, Rows, XChecking, YChecking, GameArray, ref AliveNumber, PeriodicBehaviour);
            }

        }

        /// <summary>
        /// Contains code for the rules of life, checking the neighbours and code checking for periodic behaviour
        /// </summary>
        /// <param name="Rows"></param>
        /// <param name="Columns"></param>
        /// <param name="GameArray"></param>
        /// <param name="ThreeCount"></param>
        /// <param name="PeriodicBehaviour"></param>
        /// <param name="TempArray"></param>
        static void ActualGame(ref int Rows, ref int Columns, ref int[,] GameArray, ref int ThreeCount,
            ref bool PeriodicBehaviour, ref int[,] TempArray, int XChecking, int YChecking, ref int NeighbourhoodOrder,
            ref int GenCount, ref string Neighbourhood, ref List<int> SurvivalLaw, ref List<int> BirthLaw, ref bool IsCenterCounted, ref bool GhostMode)
        {

            //INSERT NEW GAME LOGIC 

            //while (Genenerations > GenCount)
            // {
            //    GenCount++;
            /*
            //Checking each Cell state  
            for (int CheckRows = 0; CheckRows < GameArray.GetLength(0); CheckRows++)
                {
                    for (int CheckColumns = 0; CheckColumns < GameArray.GetLength(1); CheckColumns++)
                    {

                        //count for amount of alive cell neighbours
                        int AliveNumber = 0;

                        //checking extra cells deepending on neighbourhood
                        if (Neighbourhood == "Moore")
                        {
                            //changing checking area depending on neighbourhood order
                            for (int x = 1; x <= NeighbourhoodOrder; x++)
                            {
                                for (int y = 1; y <= NeighbourhoodOrder; y++)
                                {
                                    GameLogicHelper(ref AliveNumber, CheckRows - x, CheckColumns + y, Rows, Columns, PeriodicBehaviour, GameArray, x);

                                    GameLogicHelper(ref AliveNumber, CheckRows + x, CheckColumns + y, Rows, Columns, PeriodicBehaviour, GameArray, x);

                                    GameLogicHelper(ref AliveNumber, CheckRows + x, CheckColumns - y, Rows, Columns, PeriodicBehaviour, GameArray, x);

                                    GameLogicHelper(ref AliveNumber, CheckRows - x, CheckColumns - y, Rows, Columns, PeriodicBehaviour, GameArray, x);
                                }

                                GameLogicHelper(ref AliveNumber, CheckRows, CheckColumns - x, Rows, Columns, PeriodicBehaviour, GameArray, x);

                                GameLogicHelper(ref AliveNumber, CheckRows, CheckColumns + x, Rows, Columns, PeriodicBehaviour, GameArray, x);

                                GameLogicHelper(ref AliveNumber, CheckRows - x, CheckColumns, Rows, Columns, PeriodicBehaviour, GameArray, x);

                                GameLogicHelper(ref AliveNumber, CheckRows + x, CheckColumns, Rows, Columns, PeriodicBehaviour, GameArray, x);

                            }
                        }
                        else
                        {
                            int AreaConsidered = 0;
                            for (int x = 0; x < NeighbourhoodOrder; x++)
                            {
                                for (int y = 0; y <= NeighbourhoodOrder - AreaConsidered; y++)
                                {
                                    if (x > 0 && y > 0)
                                    {
                                        GameLogicHelper(ref AliveNumber, CheckRows + x, CheckColumns + y, Rows, Columns, PeriodicBehaviour, GameArray,ref x);

                                        GameLogicHelper(ref AliveNumber, CheckRows - x, CheckColumns - y, Rows, Columns, PeriodicBehaviour, GameArray,ref x);

                                        GameLogicHelper(ref AliveNumber, CheckRows + x, CheckColumns - y, Rows, Columns, PeriodicBehaviour, GameArray,ref x);

                                        GameLogicHelper(ref AliveNumber, CheckRows - x, CheckColumns + y, Rows, Columns, PeriodicBehaviour, GameArray, ref x);
                                    }
                                }

                                GameLogicHelper(ref AliveNumber, CheckRows, CheckColumns + (x + 1), Rows, Columns, PeriodicBehaviour, GameArray, ref x);

                                GameLogicHelper(ref AliveNumber, CheckRows + (x + 1), CheckColumns, Rows, Columns, PeriodicBehaviour, GameArray, ref x);

                                GameLogicHelper(ref AliveNumber, CheckRows - (x + 1), CheckColumns, Rows, Columns, PeriodicBehaviour, GameArray, ref x);

                                GameLogicHelper(ref AliveNumber, CheckRows, CheckColumns - (x + 1), Rows, Columns, PeriodicBehaviour, GameArray, ref x);

                                AreaConsidered++;
                            }
                        }

                        //Implement Is Center counted
                        if (IsCenterCounted)
                        {
                            if (GameArray[CheckRows, CheckColumns] == 1)
                            {
                                AliveNumber += 1;
                            }
                        }

                        NeighbourCells(AliveNumber, ref TempArray[CheckRows, CheckColumns], GameArray[CheckRows, CheckColumns], SurvivalLaw, BirthLaw, GhostMode);
                    }
                }
            */

            //}

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BirthLaw"></param>
        /// <param name="Neighbourhood"></param>
        /// <param name="NeighbourhoodOrder"></param>
        /// <param name="CheckAllConditions"></param>
        /// <param name="SurvivalLaw"></param>
        static void Neighbourhoodtype(ref List<int> BirthLaw, ref string Neighbourhood, ref int NeighbourhoodOrder, ref bool CheckAllConditions, ref List<int> SurvivalLaw)
        {


            for (int num = 0; num < BirthLaw.Count; num++) //????????????
            {
                if (Neighbourhood == "Moore")
                {
                    if (BirthLaw[num] > ((4 * NeighbourhoodOrder) + ((4 * NeighbourhoodOrder) * NeighbourhoodOrder)))
                    {
                        CheckAllConditions = false;
                        Console.WriteLine("Birth law value must be less than the amount of neighbours" +
                            ", current neighbour amount: " + ((4 * NeighbourhoodOrder) + ((4 * NeighbourhoodOrder) * NeighbourhoodOrder)));
                    }
                }
                else
                {

                    //CHANGE THE LOCAL VARIABLES
                    int neighbourcount = 0;
                    int AreaConsidered = 0;
                    for (int rows = 0; rows < NeighbourhoodOrder; rows++)
                    {
                        for (int y = 0; y <= NeighbourhoodOrder - AreaConsidered; y++)
                        {
                            if (num > 0 && y > 0)
                            {
                                neighbourcount += 4;
                            }
                        }
                        neighbourcount += 4;
                        AreaConsidered++;
                    }

                    if (BirthLaw[num] > neighbourcount)
                    {
                        CheckAllConditions = false;
                        Console.WriteLine("Birth law value must be less than the amount of neighbours" +
                            ", current neighbour amount: " + neighbourcount);
                    }
                }
            }








            for (int num = 0; num < SurvivalLaw.Count; num++)
            {
                if (Neighbourhood == "Moore")
                {
                    if (SurvivalLaw[num] > ((4 * NeighbourhoodOrder) + ((4 * NeighbourhoodOrder) * NeighbourhoodOrder)))
                    {
                        CheckAllConditions = false;
                        Console.WriteLine("Survival law value must be less than the amount of neighbours" +
                            ", current neighbour amount: " + ((4 * NeighbourhoodOrder) + ((4 * NeighbourhoodOrder) * NeighbourhoodOrder)));
                    }
                }
                else
                {
                    int neighbourcount = 0;
                    int AreaConsidered = 0;
                    for (int rows = 0; rows < NeighbourhoodOrder; rows++)
                    {
                        for (int y = 0; y <= NeighbourhoodOrder - AreaConsidered; y++)
                        {
                            if (num > 0 && y > 0)
                            {
                                neighbourcount += 4;
                            }
                        }
                        neighbourcount += 4;
                        AreaConsidered++;
                    }

                    if (SurvivalLaw[num] > neighbourcount)
                    {
                        CheckAllConditions = false;
                        Console.WriteLine("survival law value must be less than the amount of neighbours" +
                            ", current neighbour amount: " + neighbourcount);
                    }
                }
            }

        }

        /// <summary>
        /// Main Function which contains all code that wasn't put into methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Declaring the variables
            int Rows = 16; // Default: 16. Change as required for testing. 
            int Columns = 16; // Default: 16. Change as required for testing.
            bool PeriodicBehaviour = false; // Default: false. Change as required for testing
            double RandFactor = 0.5; // Default: 0.5. Change as required for testing
            string InputFile = ""; // Default: NO input. Change as required for testing
            int Generations = 50; // Default: 50. Change as required fo testing
            double MaxUpdateRate = 5; // Default: 5. Change as required for testing
            bool StepMode = false; // Default: NOT step mode. Change as required for testing
            bool CheckAllConditions = true; //Checking all the parameters

            // From Part 2
            string Neighbourhood = "Moore";
            int NeighbourhoodOrder = 1;

            bool GhostMode = false;
            int memory = 16;
            bool IsCenterCounted = false;

            string output = "N/A";
            List<int> SurvivalLaw = new List<int>();
            List<int> BirthLaw = new List<int>();

            string BirthLawSpecified = "3";
            string SurvivalLawSpecified = "2";



            //Put the steady state stuff if you're doing that




            //To count the number of generations
            int GenCount = 0;

            Stopwatch watch = new Stopwatch();


            // Checking the user input
            for (int count = 0; count < args.Length; count++)
            {
                //Checking the dimensions of the game
                CheckDimensions(ref args, ref count, ref Rows, ref Columns, ref CheckAllConditions);

                //Checking if the game will have periodic behaviour
                CheckPeriodic(ref args, ref count, ref PeriodicBehaviour);

                //Checking Random factor
                CheckRandomFactor(ref args, ref count, ref RandFactor, ref CheckAllConditions);

                //Checking the input file
                CheckSeedfile(ref args, ref count, ref InputFile, ref CheckAllConditions);

                //Checking the generations
                GenerationMethod(ref args, ref count, ref Generations, ref CheckAllConditions);

                //Checking the max update rate
                MaxUpdaterate(ref args, ref count, ref MaxUpdateRate, ref CheckAllConditions);

                //Checking step mode
                StepModeMethod(ref args, ref count, ref StepMode);

                //Checking ghost mode
                GhostModeMethod(ref args, ref count, ref GhostMode);

                //Checking neighbours
                WhichNeighbourhood(ref args, ref count, ref Neighbourhood, ref NeighbourhoodOrder, ref IsCenterCounted, ref Columns, ref Rows, ref CheckAllConditions);

                //Survival and Birth
                SurvivalandBirth(ref args, ref count, ref SurvivalLawSpecified, ref BirthLawSpecified, ref SurvivalLaw, ref BirthLaw);

                //Memory
                GenerationalMemory(ref args, ref count, ref memory, ref CheckAllConditions);

                //Output
                OutputFile(ref args, ref count, ref output);


            }

            //Which nighbourhood type
            Neighbourhoodtype(ref BirthLaw, ref Neighbourhood, ref NeighbourhoodOrder, ref CheckAllConditions, ref SurvivalLaw);

            //Game array which stores the cell coordinates
            int[,] GameArray = new int[Rows, Columns];

            //Temporary Array to store the neighbours
            int[,] TempArray = new int[Rows, Columns];

            // Construct grid...
            Grid grid = new Grid(Rows, Columns);


            //Checking randomness if no seed file given
            RandomnessMethod(ref InputFile, ref Columns, ref Rows, ref GameArray, ref RandFactor);

            //Displaying user uput
            DispUserInput(ref CheckAllConditions, ref InputFile, ref Generations,
        ref MaxUpdateRate, ref PeriodicBehaviour, ref Rows,
        ref Columns, ref StepMode, ref RandFactor, ref memory, ref output,
        ref SurvivalLaw, ref BirthLaw, ref SurvivalLawSpecified, ref BirthLawSpecified, ref GhostMode);

            // Wait for user to press a key...
            Console.WriteLine("Press spacebar to start simulation");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;



            // Game
            // Initialize the grid window (this will resize the window and buffer
            grid.InitializeWindow();

            // Set the footnote (appears in the bottom left of the screen).
            grid.SetFootnote("Life " + GenCount);

            // Declaring variable to see if neighbouring cells are active for next generation
            int ThreeCount = 0;

            // For each of the cells...
            for (int i = 0; i < GameArray.GetLength(0); i++)
            {
                for (int j = 0; j < GameArray.GetLength(1); j++)
                {
                    if (GameArray[i, j] == 1)
                    {
                        // Update grid with a new cell...
                        grid.UpdateCell(i, j, CellState.Full);
                    }
                    else
                    {
                        grid.UpdateCell(i, j, CellState.Blank);
                    }
                }
            }

            // Timer for Life game
            watch.Restart();
            while (watch.ElapsedMilliseconds < (1000 / MaxUpdateRate)) ;

            grid.Render();

            //Increasing the generations
            while (Generations >= GenCount)
            {
                /*
                //Checking the neighbours of the cells
                ActualGame(ref Rows, ref Columns, ref GameArray,
            ref PeriodicBehaviour, ref TempArray, ref int XChecking, ref int YChecking, ref NeighbourhoodOrder,
            ref GenCount, ref Neighbourhood, ref SurvivalLaw, ref BirthLaw, ref IsCenterCounted, ref GhostMode);
                 */



                //Step function holding answer till space is pressed
                if (StepMode == true)
                {
                    while (Console.ReadKey().Key != ConsoleKey.Spacebar) ;
                }
                grid.SetFootnote("Life " + GenCount);

                // For each of the cells...
                for (int i = 0; i < GameArray.GetLength(0); i++)
                {
                    for (int j = 0; j < GameArray.GetLength(1); j++)
                    {
                        if (TempArray[i, j] == 1)
                        {
                            // Update grid with a new cell...
                            grid.UpdateCell(i, j, CellState.Full);
                            GameArray[i, j] = TempArray[i, j];
                        }
                        else
                        {
                            grid.UpdateCell(i, j, CellState.Blank);
                            GameArray[i, j] = 0;

                        }
                        TempArray[i, j] = 0;

                    }
                }

                // Timer for Life Game
                watch.Restart();
                while (watch.ElapsedMilliseconds < (1000 / MaxUpdateRate)) ;
                // Render updates to the console window...
                grid.Render();
                GenCount++;
            }

            // Set complete marker as true
            grid.IsComplete = true;

            grid.Render();

            Console.ReadKey();

            grid.RevertWindow();
        }
    }
}

