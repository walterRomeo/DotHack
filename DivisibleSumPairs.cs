using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DivisibleSumPairs
{
    class Program
    {
        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int dsp = 0;
            for (int j = n-1; j > 0; j--)
            {
                int i = j;
                int sum;

                while (--i >= 0)
                {
                    sum = ar[i] + ar[j];
                    if (sum % k == 0)
                    {
                        dsp++;
                    }
                }
            }
            return dsp;
        }

        static int divsum2(int n, int k, int[] ar)
        {
            int[] bucket = new int[k];
            int count = 0;

            foreach(int value in ar)
            {
                int remainder = value % k;
                
                count += bucket[(k - remainder )% k];
                bucket[remainder]++;
                Console.WriteLine(count + "adding "+bucket[(k - remainder )% k]);

            }
            return count;

        }
        static void Main(string[] args)
        {
           string [] nk = Console.ReadLine().Split(' ');
           int n = Convert.ToInt32(nk[0]);
           int k = Convert.ToInt32(nk[1]);
           int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
           int result = divisibleSumPairs(n,k,ar);
           Console.WriteLine(result);
           Console.WriteLine(divsum2(n,k,ar));
        }
    }
}
