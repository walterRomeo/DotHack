using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace ExtraLongFactorials
{
    class Program
    {

        static void extraLongFactorials(int n )
        {
            var factorial = Factorial(n);
            Console.WriteLine(factorial);
        }

        static BigInteger Factorial(long n)
        {
            if(n == 1)
            {
                return n;
            }
            return n*Factorial(n-1);
        }
        static void Main(string[] args)
        {
            int n  = Convert.ToInt32(Console.ReadLine());
            extraLongFactorials(n);
        }
    }
}
