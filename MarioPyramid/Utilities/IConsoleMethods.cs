using System;
using System.Collections.Generic;
using System.Text;

namespace MarioPyramid.Utilities
{
    public interface IConsoleMethods
    {
        void Write(string message = "");
        void WriteLine(string message = "");
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
