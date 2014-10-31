namespace BitArrayI
{
    using System;
    using System.Diagnostics;

    class BitArrayMain
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            BitArray arr1 = new BitArray();
            arr1[7] = 1;

            Console.WriteLine(arr1);
            timer.Stop();
            Console.WriteLine(timer.Elapsed);

            timer.Reset();
            timer.Start();

            BitArray arr2 = new BitArray();
            arr2[0] = 1;
            arr2[1] = 1;
            arr2[4] = 1;
            arr2[7] = 1;
            arr2[9] = 1;
            arr2[13] = 1;
            arr2[16] = 1;
            arr2[19] = 1;
            arr2[20] = 1;
            arr2[22] = 1;
            arr2[24] = 1;
            arr2[25] = 1;
            arr2[26] = 1;
            arr2[27] = 1;
            arr2[29] = 1;
            arr2[31] = 1;
            arr2[32] = 1;
            arr2[35] = 1;
            arr2[36] = 1;
            arr2[38] = 1;
            arr2[41] = 1;
            arr2[43] = 1;
            arr2[44] = 1;
            arr2[46] = 1;
            arr2[48] = 1;
            arr2[49] = 1;
            arr2[52] = 1;
            arr2[54] = 1;
            arr2[56] = 1;
            arr2[58] = 1;
            arr2[60] = 1;
            arr2[62] = 1;

            Console.WriteLine(arr2);

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }
    }
}