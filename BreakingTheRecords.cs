using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace BreakingTheRecords
{
    class Solution{

        static int [] breakingRecords(int[] scores)
        {
            int min, max;
            min = scores[0];
            max = scores[0];
            int tMinBroken = 0, tMaxBroken = 0;
            for(int game = 1; game < scores.Length; game++ )
            {
                if(scores[game] < min )
                {
                    min = scores[game];
                    tMinBroken++;
                }
                else if(scores[game]>max)
                {
                    max = scores[game];
                    tMaxBroken++;
                }
            }
            return new int[]{tMaxBroken,tMinBroken};
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] scores  = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int[] result = breakingRecords(scores);
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
