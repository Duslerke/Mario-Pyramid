using System;
using MarioPyramid.Utilities;

namespace MarioPyramidTest.Materials
{
    public class MockConsoleMethods : IConsoleMethods//, IDisposable
    {//can write to some outside the function empty string
        public string writeString = ""; //there is a better way than this, but I'm tired and it's late
        public string writeLineString = "";
        public string readLineInput; 
        public ConsoleKeyInfo readKeyInput; //use stuff like: ConsoleKey.Y
        public int timesInputed;

        public void Write(string message = "") { writeString += message; }

        public void WriteLine(string message = "")
        {
            if(writeLineString != "") { writeLineString += "\n"; }
            writeLineString +=  message;
        }

        public string ReadLine() { timesInputed++; return readLineInput; }

        public ConsoleKeyInfo ReadKey() { timesInputed++; return readKeyInput; } //TO DO: Change all instances of "Console" into "console" once you inject the IConsole interface as a parameter into a Input helper

        public ConsoleKeyInfo ReadKey(bool suppress) { timesInputed++; return readKeyInput; } //TO DO: Change all instances of "Console" into "console" once you inject the IConsole interface as a parameter into a Input helper

        public void Cleanup()
        {
            writeString = "";
            writeLineString = "";
        }
    }
}
