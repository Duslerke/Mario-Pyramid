using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
