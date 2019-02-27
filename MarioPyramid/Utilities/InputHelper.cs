using System;
using MarioPyramid.Exceptions;

namespace MarioPyramid.Utilities
{
    public class InputHelper : IInputHelper
    {
        private IConsoleMethods _console { get; set; }
        private IValidation _gateKeeper { get; set; }

        public InputHelper(IConsoleMethods console, IValidation gateKeeper)
        {
            _console = console;
            _gateKeeper = gateKeeper;
        }

        public bool PromptForExit()
        {
            while (true)
            {
                _console.Write("\nQuit the program? (y/n) ");

                ConsoleKey key = _console.ReadKey(true).Key;
                Console.Clear();
                bool? output = _gateKeeper.ExitLogic(key);

                if (output != null) { return (bool)output; }
            }
            
        }

        public int GetUserInput()
        {
            while (true)
            {
                try
                {
                    try
                    {
                        _console.Write("Provide integer for height: ");
                        string input = _console.ReadLine();

                        _gateKeeper.checkNumeric(input);

                        int intInput = Convert.ToInt32(input);

                        _gateKeeper.checkInRange(intInput);

                        _gateKeeper.errorCount = 0;
                        return intInput;
                    }
                    catch (Exception e)
                    {
                        _gateKeeper.checkForCat();
                        _console.WriteLine($"{e.Message} Try again.");
                    }
                }
                catch (Exception e) { _console.WriteLine($"{e.Message} Try again."); }
                finally { _console.WriteLine(); }
            }
        }
    }
}
