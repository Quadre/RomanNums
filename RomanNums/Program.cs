using System;

namespace RomanNums
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please supplay an argument. It should be case insensitive string with  IVXLCDM letters, that represents Roman number with max value of " + int.MaxValue);
                Console.WriteLine("Example: IX, will return 9");
                return -1;
            }

            try
            {
                Roman r = new Roman();
                if (r.isCompliant(args[0]))
                {
                    return r.Covnvert(args[0]);
                }
                else
                {
                    Console.WriteLine("ERROR: '{0}' not Roman-compliant string.", args[0]);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: '{0}'.", ex.Message);
                return -1;
            }
        }
    }
}
