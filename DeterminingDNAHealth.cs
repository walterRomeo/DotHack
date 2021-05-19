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

            PrintStats(n, genes, health, s, dna);
        }

        public static void PrintStats(int n, List<string> gene, List<int> health, int s, List<DNAStrand> strands)
        {
            int unhealthiest = int.MaxValue;
            int healthiest = int.MinValue;

            foreach (var dna in strands)
            {
                Dictionary<string, int> genesToSearch = new Dictionary<string, int>();
                for (int i = dna.First; i <= dna.Last; i++)
                {
                    genesToSearch.TryAdd(gene[i], health[i]);
                }
                int check = dna.HealthCheck(genesToSearch);
                if (check < unhealthiest)
                {
                    unhealthiest = check;
                }
                if (check > healthiest)
                {
                    healthiest = check;
                }
            }
            Console.WriteLine("{0} {1}",unhealthiest, healthiest);

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

        public int HealthCheck(Dictionary<string, int> gene)
        {
            int healthValue = 0;
            foreach (var gh in gene)
            {
                string geneCheck = gh.Key;
                int healthStat = gh.Value;
                int checkLength = geneCheck.Length;
                Console.WriteLine($"{geneCheck}: {checkLength}");
                //Find all instances of the current gene being searched for
                if(Strand.Contains(geneCheck))
                {
                    healthValue += healthStat;
                }
            }

            return healthValue;
        }
    }
}
