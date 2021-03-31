using System;
using System.IO;

using static System.Console;

namespace Simulation
{
    public class Die
    {
        // INSERT THE CONTENTS OF YOUR SOLUTION TO THE PREVIOUS EXERCISE HERE
        // generator.
        private int faces;
        private int currentface;
        private Random randomnumber;

        /// <summary>
        /// Initialise, assigning default values. Number of faces should be
        /// 5, and current face should be 1. 
        /// </summary>
        /// <param name="random">
        ///     Reference to a System.Random object which will be used to 
        ///     simulate dice rolls.
        /// </param>
        public Die(Random random)
        {
            faces = 5;
            currentface = 1;
            randomnumber = random;
        }
        /// <summary>
        /// Initialise, assigning the designated number of faces, and setting 
        /// current face to 1. 
        /// </summary>
        /// <param name="random">
        ///     Reference to a System.Random object which will be used to 
        ///     simulate dice rolls.
        /// </param>
        /// <param name="faces">
        ///     An integer which stipulates the number of faces. If the number 
        ///     of faces requested is less than 3, then the requested number 
        ///     should be ignored and the default number of faces (5) should be 
        ///     assigned instead.
        /// </param>
        public Die(Random rand, int givenfaces)
        {
            if (givenfaces < 3)
            {

                faces = 5;
                currentface = 1;
            }
            else
            {
                faces = givenfaces;
                currentface = 1;
            }
            randomnumber = rand;
        }

        /// <summary>
        /// Get the number of faces.
        /// </summary>
        /// <returns>
        ///     The number of faces.
        /// </returns>
        public int GetMaxFace()
        {
            return faces;
        }

        /// <summary>
        /// Roll the die by generating a random number between 1 and the 
        /// number of faces, inclusive.
        /// </summary>
        public void RollDie()
        {
            currentface = randomnumber.Next(1, faces + 1);
        }

        /// <summary>
        /// Get the current face.
        /// </summary>
        /// <returns>The current face.</returns>
        public int GetCurrentFace()
        {
            return currentface;
        }
    }

    public class Dice
    {
        // Private variable: an array or list of Die objects.
        // INSERT VARIABLES HERE
        private int faces;
        private int currentface;
        private Random randomnumber;
        private int[] dicenumbers;


        /// <summary>
        /// Initialise, creating the required number of Die objects
        /// having the default number of faces. 
        /// </summary>
        /// <param name="random">
        ///     Reference to a System.Random object which will be used to 
        ///     simulate dice rolls.
        /// </param>
        /// <param name="numDice">
        ///     The number of dice to create and use. This quantity is 
        ///     guaranteed to be equal to or greater than 1. 
        /// </param>
        // INSERT CODE HERE
        public Dice(Random random, int numDice)
        {
            randomnumber = random;
            faces = 5;
            currentface = 1;
            dicenumbers = new int[numDice];

            for (int i = 0; i < dicenumbers.Length; i++)
            {
                dicenumbers[i] = 1;
            }
        }


        /// <summary>
        /// Initialise, creating the required number of Die objects
        /// having the designated number of faces. 
        /// </summary>
        /// <param name="random">
        ///     Reference to a System.Random object which will be used to 
        ///     simulate dice rolls.
        /// </param>
        /// <param name="numDice">
        ///     The number of dice to create and use. This quantity is 
        ///     guaranteed to be equal to or greater than 1. 
        /// </param>
        /// <param name="numFaces">
        ///     An integer which stipulates the number of faces. If the number 
        ///     of faces requested is less than 3, then the requested number 
        ///     should be ignored and the default number of faces (5) should be 
        ///     assigned instead.
        /// </param>
        // INSERT CODE HERE
        public Dice(Random random, int numDice, int givenfaces)
        {
            if (givenfaces < 3)
            {
                faces = 5;
                currentface = 1;
            }
            else
            {
                faces = givenfaces;
                currentface = 1;
            }
            randomnumber = random;

            dicenumbers = new int[numDice];

            for (int i = 0; i < dicenumbers.Length; i++)
            {
                dicenumbers[i] = 1;

            }
        }

        /// <summary>
        /// Roll all dice in this collection.
        /// </summary>
        public void RollDice()
        {
            for (int i = 0; i < dicenumbers.Length; i++)
            {
                dicenumbers[i] = randomnumber.Next(1, faces + 1);
            }
        }

        /// <summary>
        /// Get the sum of the current face values of the individual dice in the
        /// collection.
        /// </summary>
        /// <returns>The sum of the current face values of the individual dice in the
        /// collection.</returns>
        // INSERT CODE HERE
        public int GetTotalValue()
        {
            int facecount = 0;
            for (int i = 0; i < dicenumbers.Length; i++)
            {
                facecount += dicenumbers[i];
            }
            return facecount;
        }

        /// <summary>
        ///     Test driver for Simulation.Die.
        ///     Interactively queries user for deposit amount, withdrawal amount,
        ///     and interest rate, applies operation and displays results.
        /// </summary>
        public static void Main()
        {
            Random generator = new Random(733109);
            int numDice = 2;
            int numFaces = 6;
            Dice dice = new Dice(generator, numDice, numFaces);
            bool finished = false;

            while (!finished)
            {
                Write(menu);
                var line = ReadLine();

                if (line == null) break;

                var fields = line.Trim().ToLower().Split(' ');

                if (fields.Length > 0 && fields[0].Length > 0)
                {
                    switch (fields[0][0])
                    {
                        case 'd':
                            switch (fields.Length)
                            {
                                case 1:
                                    numDice = 2;
                                    dice = new Dice(generator, numDice);
                                    break;
                                case 2:
                                    numDice = int.Parse(fields[1]);
                                    dice = new Dice(generator, numDice);
                                    break;
                                case 3:
                                    numDice = int.Parse(fields[1]);
                                    numFaces = int.Parse(fields[2]);
                                    dice = new Dice(generator, numDice, numFaces);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 'r':
                            dice.RollDice();
                            break;
                        case 'q':
                            finished = true;
                            break;
                        default:
                            break;
                    }
                }

                if (!finished)
                {
                    int currTotal = dice.GetTotalValue();
                    WriteLine($"After operation: current total = {currTotal}");
                }
            }
        }

        static readonly string menu =
            "Enter option:\n   d = new bunch of dice;  r = roll;  q = exit.\n==> ";
    }
}
