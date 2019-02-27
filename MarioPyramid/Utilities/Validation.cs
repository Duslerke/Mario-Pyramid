using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioPyramid.Exceptions;


namespace MarioPyramid.Utilities
{
    public class Validation : IValidation
    {
        private string numerals { get; }
        public int errorCount { get; set; }

        public Validation()
        {
            errorCount = 0;
            numerals = "0123456789";
        }

        public bool? ExitLogic(ConsoleKey key)
        {
            if (key == ConsoleKey.Y) { return true; }
            else if (key == ConsoleKey.N) { return false; }
            else { return null; }
        }

        public void checkNumeric(string uInput)
        {
            if (uInput == "") { errorCount++; throw new EmptyInputException("Empty Input!"); }
            else
            {
                foreach (char c in uInput)
                {
                    if (!numerals.Contains(c)) { errorCount++; throw new NotANumberException("That is not a number!"); }
                }
            }
        }

        public void checkInRange(int aheight)
        {
            if (aheight > 23) { errorCount++; throw new HeightLimitExceededException("Height can't be greater than 23!"); }
            else if (aheight < 0) { errorCount++; throw new HeightCannotBeNegativeException("Height can't be negative!"); }
        }

        public void checkForCat()
        {
            Console.WriteLine(errorCount);
            if (errorCount >= 20) { throw new CatOnTheKeyboardException("Please remove cat from the keyboard!"); };
        }
    }
}
