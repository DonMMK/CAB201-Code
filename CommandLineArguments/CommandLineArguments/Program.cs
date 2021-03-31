using System;

class CommandLineArguments
{
    public static void Main(string[] args)
    {
        int i = 0;

        if (args.Length == 0)
        {
            Console.WriteLine("WARNING: No command line arguments provided.");
        }
        else if (args[i].Substring(0, 2) != "--" && args[i].Substring(0, 1) != "-")
        {
            Console.WriteLine("WARNING: Parameters must be provided after options.");
        }
        else
        {
            //For loop that checks every element in the array
            while (i < args.Length)
            {


                if ((args[i].Substring(0, 2) == "--") || (args[i].Substring(0, 1) == "-"))
                {
                    Console.Write(args[i]);
                    i++;
                    if (i == args.Length)
                    {
                        break;
                    }
                    else


                    if (args[i].Substring(0, 1) == "p")
                    {
                        Console.Write(": { ");
                        Console.Write(args[i]);
                        i++;
                        if (i == args.Length)
                        {
                            Console.WriteLine(" }");
                            break;
                        }
                        while (args[i].Substring(0, 1) == "p")
                        {
                            Console.Write(", " + args[i]);
                            i++;
                            if (i == args.Length)
                            {
                                break;
                            }
                        }
                    
                    Console.WriteLine(" }");
                }
                else
                {
                    Console.WriteLine();
                }
            }


            else
                {
                    Console.WriteLine(args[i]);
                    i++;
                    if (i == args.Length)
                    {
                        break;
                    }
                }

            }
        }
    }
}




//(args[i].Substring(0, 1) == "p") && 