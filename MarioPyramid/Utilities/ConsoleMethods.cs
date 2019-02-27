using System;
using System.Collections.Generic;
using System.Text;

namespace MarioPyramid.Utilities
{
    public class ConsoleMethods : IConsoleMethods
    {
        public void Write(string message = "") { Console.Write(message); }
        public void WriteLine(string message = "") { Console.WriteLine(message); }
        public string ReadLine() { return Console.ReadLine(); }
        public ConsoleKeyInfo ReadKey() { return Console.ReadKey(); }
        public ConsoleKeyInfo ReadKey(bool suppress) { return Console.ReadKey(suppress); }

    }
}
