using System;

namespace MarioPyramid.Exceptions
{
    public class EmptyInputException : Exception
    {
        public EmptyInputException(string message) : base(message)
        {
        }
    }
}