using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Globalization;

namespace DeterminingDNAHealth
{
    class Solution
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<string> genes = Console.ReadLine().TrimEnd().Split(' ').ToList();
            List<int> health = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(healthTemp => Convert.ToInt32(healthTemp)).ToList();

            int s = Convert.ToInt32(Console.ReadLine().Trim());
            List<DNAStrand> dna = new List<DNAStrand>();
            for (int sItr = 0; sItr < s; sItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int first = Convert.ToInt32(firstMultipleInput[0]);
                int last = Convert.ToInt32(firstMultipleInput[1]);
                string d = firstMultipleInput[2];
                DNAStrand strand = new DNAStrand(first, last, d);
                dna.Add(strand);
            }
            //Find and print unhealthiest and healthiest strands from the sample input
            PrintStats(n, genes, health, s, dna);
        }

        // Method to compare gene against the strands. 
        public static void PrintStats(int n, List<string> gene, List<int> health, int s, List<DNAStrand> strands)
        {
            int unhealthiest = int.MaxValue;
            int healthiest = int.MinValue;

            foreach (var dna in strands)
            {
                int check = 0;
                for (int i = dna.First; i <= dna.Last; i++)
                {
                    check += dna.HealthCheck(gene[i], health[i]);
                }   
                if (check < unhealthiest)
                {
                   unhealthiest = check;
                }
                if (check > healthiest)
                {
                    healthiest = check;
                }
            }
            Console.WriteLine("{0} {1}", unhealthiest, healthiest);
        }
    }

    class DNAStrand
    {
        public int First { get; set; }
        public int Last { get; set; }
        public string Strand { get; set; }
        public DNAStrand(int first, int last, string strand)
        {
            First = first;
            Last = last;
            Strand = strand;
        }

        public int HealthCheck(string geneToCheck, int hValue)
        {
            int healthValue = 0;
            //Console.WriteLine($"{geneCheck}: {checkLength}");
            //Find all instances of the current gene being searched for

            if(Strand.Contains(geneToCheck))
            {
                healthValue += hValue * CheckForMore(geneToCheck,geneToCheck.Length);
            }
            Console.WriteLine("Here " + healthValue);
            return healthValue;
        }

        public int CheckForMore(string gene, int geneLength)
        {
            int moreFound = 0;
            var token = Strand;
            
            for(int i= 0; i < token.Length; i++)
            {
                if(token[i] == gene[0])
                {
                    if(geneLength > 1)
                    {
                        int j = 1;
                        bool match = false;
                        if((i + geneLength) < token.Length)
                        {
                            while(j < geneLength)
                            {
                                if(token[i+j] == gene[j])
                                {
                                    match = true;
                                }
                                else
                                {
                                    match = false;
                                }
                                j++;
                            }
                            if(match == true)
                            {
                                moreFound++;
                            }
                        }
                    }
                    else
                    {
                        moreFound++;
                    }
                }
            }
            return moreFound;
        }
    }
}
