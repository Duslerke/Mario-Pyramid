using System;

namespace MarioPyramid.Utilities
{
    public interface IConsoleMethods
    {
        void Write(string message = "");
        void WriteLine(string message = "");
        string ReadLine();
        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool suppress);
    }
}
