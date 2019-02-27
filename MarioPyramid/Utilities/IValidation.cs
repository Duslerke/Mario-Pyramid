using System;

namespace MarioPyramid.Utilities
{
    public interface IValidation
    {
        int errorCount { get; set; }

        void checkNumeric(string uInput);
        void checkInRange(int aheight);
        void checkForCat();

        bool? ExitLogic(ConsoleKey key);
    }
}