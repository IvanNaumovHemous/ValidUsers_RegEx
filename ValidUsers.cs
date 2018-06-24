using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace KeyReplacer
{
    class ValidUsers
    {
        static void Main(string[] args)
        {
            var RegexMatches = GetRegexMatches();
            var ListOfRegexMatches = GetListOfRegexMatches(RegexMatches);
            var ListofMaxSumByPair = GetListofMaxSumByPair(ListOfRegexMatches);
            PrintAnswer(ListofMaxSumByPair);


        }

        private static void PrintAnswer(List<string> listofMaxSumByPair)
        {
            int count = 0;
            while (count < 2)
            {
                Console.WriteLine(listofMaxSumByPair[count]);
                count++;
            }
        }

        private static List<string> GetListofMaxSumByPair(List<string> listOfRegexMatches)
        {
            int count = 0;
            int maxCount = 0;
            var MaxCountList = new List<string>();

            for (int i = 0; i < listOfRegexMatches.Count - 1; i++)
            {
                count = listOfRegexMatches[i].Length + listOfRegexMatches[i + 1].Length;

                if (count > maxCount)
                {
                    maxCount = count;
                    MaxCountList.Insert(0, listOfRegexMatches[i + 1]);
                    MaxCountList.Insert(0, listOfRegexMatches[i]);

                }
                count = 0;
            }

            return MaxCountList;
        }

        private static List<string> GetListOfRegexMatches(MatchCollection regexMatches)
        {

            var ListOfMatches = new List<Match>();

            foreach (Match item in regexMatches)
            {
                ListOfMatches.Add(item);
            }

            var tempList = ListOfMatches.Cast<Match>().Select(m => m.Value).ToList();

            return tempList;
        }

        private static MatchCollection GetRegexMatches()
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=[ \/\\,])[A-Za-z]\w{3,25}";
            var matches = Regex.Matches(text, pattern);

            return matches;
        }
    }
}

