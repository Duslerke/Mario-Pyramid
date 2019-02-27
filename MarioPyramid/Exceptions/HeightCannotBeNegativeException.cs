using System;

namespace MarioPyramid.Exceptions
{
    internal class HeightCannotBeNegativeException : Exception
    {
        public HeightCannotBeNegativeException(string message) : base(message)
        {

        }
    }
}