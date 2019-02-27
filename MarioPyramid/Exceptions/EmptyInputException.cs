using System;

namespace MarioPyramid.Exceptions
{
    internal class EmptyInputException : Exception
    {
        public EmptyInputException(string message) : base(message)
        {
        }
    }
}