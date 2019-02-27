using System;
using MarioPyramid.Exceptions;

namespace MarioPyramid.Utilities
{
    public class InputHelper : IInputHelper
    {
        private IConsoleMethods _console { get; set; }

        public InputHelper(IConsoleMethods console)
        {
            _console = console;
        }

        public bool PromptForExit()
        {
            _console.Write("\nQuit the program? (y/n) ");
            while (true)
            {
                ConsoleKey key = _console.ReadKey().Key;
                _console.WriteLine("\n");
                if (key == ConsoleKey.Y) { return true; }
                else if (key == ConsoleKey.N) { return false; }
            }
        }

        public int GetUserInput()
        {
            int errorCount = 0;
            int userInput;

            while (true)
            {
                try
                {
                    try
                    {
                        _console.Write("Provide integer for height: ");
                        int aheight = Convert.ToInt32(_console.ReadLine());

                        if (aheight > 23) { throw new HeightLimitExceededException("Height can't be greater than 23!"); }
                        else if (aheight < 0) { throw new HeightCannotBeNegativeException("Height can't be negative!"); }
                        else { userInput = aheight; break; }

                    }
                    catch (Exception e)
                    {
                        errorCount++;
                        if (errorCount >= 20) { throw new CatOnTheKeyboardException("Please remove cat from the keyboard!"); };
                        _console.WriteLine($"{e.Message} Try again.");
                    }
                }
                catch (Exception e) { _console.WriteLine($"{e.Message} Try again."); }
                finally { _console.WriteLine(); }
            }
            return userInput;
        }
    }
}
