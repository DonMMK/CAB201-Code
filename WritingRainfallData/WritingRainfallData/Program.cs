using System;
using System.IO;

namespace WeatherAnalysis
{
    public class MonthlyRainfall
    {
        /// <summary>
        /// Enumeration used to translate month numbers in 1..12 to month names. 
        /// </summary>
        enum Month
        {
            January = 0,
            February = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11
        }

        public static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                string inPath = args[0];
                string outPath = args[1];
                using (TextReader reader = new StreamReader(inPath))
                {
                    using (TextWriter writer = new StreamWriter(outPath))
                    {
                        MonthlyRainfallSummary(reader, writer);
                    }
                }
            }
            else
            {
                Console.Error.WriteLine($"Expected two arguments: inPath and outPath.");
            }
        }
        public static void MonthlyRainfallSummary(TextReader reader, TextWriter writter)
        {
            writter.WriteLine("Month,TotalRainfall(mm),AverageRainfall(mm/day),MaximumDailyRainfall(mm),MissingData(%)");
            string te = "";

            double[] TotalRain = new double[12];
            double[] AverageRain = new double[12];
            double[] MaxRain = new double[12];
            double[] MissingData = new double[12];
            double[] count = new double[12];
            string[] Months = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            string unedited = "";
             while ((te = reader.ReadLine()) != null)
            {
                for (int x = 0; x < Months.Length; x++)
                {
                    if (te.Substring(23, 2) == Months[x])
                    {
                        count[x]++;
                        try
                        {
                            unedited = te.Remove(te.Length - 4).Substring(29);
                            TotalRain[x] += double.Parse(unedited);

                            if (MaxRain[x] < double.Parse(unedited))
                            {
                                MaxRain[x] = double.Parse(unedited);
                            }
                        }
                        catch (Exception e)
                        {
                            MissingData[x] += 1;
                        }
                    }
                }
            }
            for (int x = 0; x < 12; x++)
            {
                AverageRain[x] = TotalRain[x] / (count[x] - MissingData[x]);

                MissingData[x] = (MissingData[x] / count[x]) * 100;

                writter.Write("{0},", Enum.GetName(typeof(Month), x));

                writter.Write("{0:0.00},", TotalRain[x]);

                writter.Write("{0:0.00},", AverageRain[x]);

                writter.Write("{0:0.00},", MaxRain[x]);

                writter.Write("{0:0.00}\n", MissingData[x]);

            }
        }
    }
}
