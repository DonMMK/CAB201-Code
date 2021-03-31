using System;
using System.IO;

namespace WeatherAnalysis
{
    public class Rainfall
    {

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string path = args[0];
                using (TextReader reader = new StreamReader(args[0]))
                {
                    PrintRainfallSummary(path, reader);
                }
            }
            else
            {
                string path = "C:\\Path\\To\\File\\three_days_data.csv";
                string threeDaysData = @"Product code,Bureau of Meteorology station number,Year,Month,Day,Rainfall amount (millimetres),Period over which rainfall was measured (days),Quality
IDCJAC0009,040913,2012,01,01,2.4,1,N
IDCJAC0009,040913,2012,01,02,,,
IDCJAC0009,040913,2012,01,03,0.0,1,N";

                using (TextReader reader = new StringReader(threeDaysData))
                {
                    PrintRainfallSummary(path, reader);
                }
            }
        }

        /// <summary>
        ///     Parse the rainfall data and compute a summary according to 
        ///     specification. Results are written to standard output stream.
        /// <para>
        ///     Refer to question text and sample data files for specifics.
        /// </para>
        /// </summary>
        /// <param name="filePath">
        ///     A string containing the path to the data file. This is for
        ///     display purposes only. Do not attempt to open this file.
        /// </param>
        /// <param name="reader">
        ///     A TextReader which has been attached to the data file and is 
        ///     ready to parse content.
        /// </param>
        /// <returns>
        ///		This method does not return a value.
        /// </returns>
        //)

        // INSERT METHOD HERE.

        public static void PrintRainfallSummary(string path, TextReader reader)
        {

            string Year = "" ;
            double TotalRainfall = 0.0 ;
            double AverageRainfall = 0.0 ;
            double max_daily = 0.0 ;
            double MissingData = 0.0 ;
            string temp = "" ;
            double Tem = -1 ;
            double MissingDataCount = -1 ;


            Console.WriteLine("Reading data from {0}...\n", Path.GetFileName(path));

            while ((temp = reader.ReadLine()) != null)
            {
                Tem++; 
                Year = temp.Substring(18, 4);

                
                try
                {
                    string unedited_rain = temp.Substring(29);
                    unedited_rain = unedited_rain.Remove(unedited_rain.Length - 4);
                    TotalRainfall += double.Parse(unedited_rain);
                    if (double.Parse(unedited_rain) > max_daily)
                    {
                        max_daily = double.Parse(unedited_rain);
                    }
                }
                catch (Exception e)
                {
                    MissingDataCount++;
                }
            }
            AverageRainfall = TotalRainfall / (Tem - MissingDataCount);
            MissingData = (MissingDataCount / Tem) * 100;



            Console.WriteLine("Year: " + Year);

            Console.WriteLine("Total Rainfall: {0:0.00} mm", TotalRainfall);

            Console.WriteLine("Average Rainfall: {0:0.00} mm / day", AverageRainfall);

            Console.WriteLine("Maximum Daily Rainfall: {0:0.00} mm", max_daily);

            Console.WriteLine("Missing Data: {0:0.00}%", MissingData);

        }

    }
}