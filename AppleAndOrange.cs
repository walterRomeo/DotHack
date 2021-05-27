using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;



namespace AppleAndOrange
{
    class Program
    {
        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int orangesLanded = 0;
            int applesLanded = 0;

            for(int count = 0; count< apples.Length; count++)
            {
                int landed = a + apples[count];
                if( landed >= s && landed <= t)
                {
                    applesLanded++;
                }
            }
            for(int count = 0; count< oranges.Length; count++)
            {
                int landed = b + oranges[count];
                if( landed >= s && landed <= t)
                {
                    orangesLanded++;
                }
            }
            Console.WriteLine("{0}\n{1}",applesLanded,orangesLanded);
        }

    

        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(st[0]);
            int t = Convert.ToInt32(st[1]);
            string[] ab = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(ab[0]);
            int b = Convert.ToInt32(ab[1]);
            string[] mn = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(mn[0]);
            int n = Convert.ToInt32(mn[1]);
            int [] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));
            int [] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp));

            countApplesAndOranges(s,t,a,b,apples,oranges);
        }
    }
}
