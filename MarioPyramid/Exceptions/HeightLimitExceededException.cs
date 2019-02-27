using System;

namespace MarioPyramid.Exceptions
{
    internal class HeightLimitExceededException : Exception
    {
        public HeightLimitExceededException(string message) : base(message)
        {

        }
    }
}