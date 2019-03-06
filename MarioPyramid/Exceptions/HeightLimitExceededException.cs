using System;

namespace MarioPyramid.Exceptions
{
    public class HeightLimitExceededException : Exception
    {
        public HeightLimitExceededException(string message) : base(message)
        {

        }
    }
}