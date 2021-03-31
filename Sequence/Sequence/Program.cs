using System;

class Sequence
{
    // Code goes here...
    public static string[] Kmers(int k, params string[] sequence)
    {
        string array = "";
            for (int num = 0; num < sequence.Length; num++)
        {
            array += sequence[num];
        }
            string[] x = new string[array.Length - (k - 1)];
        string tempo;

        int number = array.Length;
        for (int i = 0; i <= number - k; ++i)
        {
            tempo = array.Substring(i, k);
            x[i] = tempo;
        }
        return x;
    }
    public static void ReverseComplement(ref string s2)
    {
        string secondarray = "";
        for (int i = s2.Length - 1; i >= 0; --i)
        {
            //secondarray += hi.Substring(i,1);
            if (s2.Substring(i, 1) == "A")
            {
                secondarray += "T";
            }
            if (s2.Substring(i, 1) == "G")
            {
                secondarray += "C";
            }
            if (s2.Substring(i, 1) == "T")
            {
                secondarray += "A";
            }
            if (s2.Substring(i, 1) == "C")
            {
                secondarray += "G";
            }
        }
        s2 = secondarray;
    }
    public static bool Dyad(string s2, int s21 = 5)
    {
        string stringend = s2;
        ReverseComplement(ref stringend);

        if (s2.Substring(0, s21) == stringend.Substring(0, s21))
        {
           return true;
        }
        else
        {
           return false;
        }
    }
    public static void Main(string[] args)
    {
       Console.WriteLine(Dyad("ACTGATCAGT", 4));
    }
}