using System;

namespace MarioPyramid.Exceptions
{
    public class CatOnTheKeyboardException : Exception
    {
        public CatOnTheKeyboardException(string message) : base(message)
        {
            //This is what's going to lose me the challenge. But it's fine :-)
        }
    }
}
