using System;


namespace MarioPyramid.Test.Materials
{
    static class Utility
    {
        public static int NumberOfHashtags(int pyramidHeight)
        {
            int h = pyramidHeight; //easier to the read formula
            int sum = (h*h + 3*h) / 2; //arithmetic progression
            return sum;
        }

        public static string[] SplitThisBy(string multiLine, string splitBy)
        {
            string[] lines = multiLine.Split(
                new[] { splitBy },
                StringSplitOptions.None
            );
            return lines;
        }

        public static int CountInstances(string thatContains, char instance)
        {
            int count = 0;
            foreach(char c in thatContains) { if(c == instance) { count++; } }
            return count;
        }
    }
}
