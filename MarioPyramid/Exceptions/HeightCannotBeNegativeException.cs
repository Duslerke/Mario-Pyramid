using System;

namespace MarioPyramid.Exceptions
{
    public class HeightCannotBeNegativeException : Exception
    {
        public HeightCannotBeNegativeException(string message) : base(message)
        {

        }
    }
}