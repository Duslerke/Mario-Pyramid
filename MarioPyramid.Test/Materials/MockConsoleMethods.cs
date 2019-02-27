using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioPyramid;
using MarioPyramid.Utilities;

namespace MarioPyramidTest.Materials
{
    public class MockConsoleMethods : IConsoleMethods//, IDisposable
    {//can write to some outside the function empty string
        public string writeString = ""; //there is a better way than this, but I'm tired and it's late
        public string writeLineString = "\n";
        public string readLineInput; 
        public ConsoleKeyInfo readKeyInput; //use stuff like: ConsoleKey.Y

        public void Write(string message = "") { writeString += ("\n" + message); }

        public void WriteLine(string message = "") { writeLineString += message; }

        public string ReadLine() { return readLineInput; }

        public ConsoleKeyInfo ReadKey() { return readKeyInput; } //TO DO: Change all instances of "Console" into "console" once you inject the IConsole interface as a parameter into a Input helper

        public void Cleanup()
        {
            writeString = "";
            writeLineString = "";
        }
    }
}
