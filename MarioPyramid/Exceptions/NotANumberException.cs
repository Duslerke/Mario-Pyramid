using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPyramid.Exceptions
{
    internal class NotANumberException : Exception
    {
        public NotANumberException(string message) : base(message)
        {

        }
    }
}
