using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarioPyramid;
using MarioPyramid.Utilities;
using MarioPyramidTest.Materials;
using Xunit;

namespace MarioPyramid.Test
{
    public class InputTests //how to separate out namespaces in xUnit?
    {
        [Fact]
        public void ExitLogic_ShouldReturn_True_When_Y_IsPressed()
        {
            Validation validation = new Validation();
            ConsoleKey key = ConsoleKey.Y;
            bool? expected = true;

            bool? actual = validation.ExitLogic(key);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExitLogic_ShouldReturn_False_When_N_IsPressed()
        {
            Validation validation = new Validation();
            ConsoleKey key = ConsoleKey.N;
            bool? expected = false;

            bool? actual = validation.ExitLogic(key);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(ConsoleKey.F)]
        [InlineData(ConsoleKey.UpArrow)]
        [InlineData(ConsoleKey.F12)]
        [InlineData(ConsoleKey.Backspace)]
        public void ExitLogic_ShouldReturn_Null_When_NotSpecifiedKey_IsPressed(ConsoleKey consoleKey)
        {
            Validation validation = new Validation();
            ConsoleKey key = consoleKey;
            bool? expected = null;

            bool? actual = validation.ExitLogic(key);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PromptForExit_ShouldReturn_True_When_Y_IsPressed()
        {
            //Arange

            MockConsoleMethods console = new MockConsoleMethods();
            Validation gateKeeper = new Validation();
            InputHelper input = new InputHelper(console, gateKeeper);

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo('y', ConsoleKey.Y,  false,  false,  false); //no need to check for alt, shift, ctrl because I'm extacting only the console key out of all this other available informations

            console.readKeyInput = keyInfo;
            bool expected = true;

            //Act

            bool actual = input.PromptForExit();

            //Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PromptForExit_ShouldReturn_False_When_N_IsPressed()
        {
            //Arange
            MockConsoleMethods console = new MockConsoleMethods();
            Validation gateKeeper = new Validation();
            InputHelper input = new InputHelper(console, gateKeeper);

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo('n', ConsoleKey.N, false, false, false);

            console.readKeyInput = keyInfo;
            bool expected = false;

            //Act
            bool actual = input.PromptForExit();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData('o', ConsoleKey.O)]
        [InlineData(' ', ConsoleKey.UpArrow)]
        [InlineData('z', ConsoleKey.Z)]
        [InlineData(' ', ConsoleKey.F11)]
        [InlineData('4', ConsoleKey.D4)]
        public void PromptForExit_ShouldRequestInputAgain_If_NotSpecifiedKey_IsPressed(char keyChar, ConsoleKey consoleKey)
        {
            //Arange
            MockConsoleMethods console = new MockConsoleMethods();
            Validation gateKeeper = new Validation();
            InputHelper input = new InputHelper(console, gateKeeper);

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo(keyChar, consoleKey, false, false, false);

            void ExitInfiniteLoop()
            {
                console.readKeyInput = new ConsoleKeyInfo('n', ConsoleKey.N, false, false, false);
            }

            new Thread(() =>
            {
                Thread.Sleep(70);
                ExitInfiniteLoop();
            }).Start();

            console.readKeyInput = keyInfo;
            int expected_moreThan = 1;

            //Act
            input.PromptForExit();
            int actual = console.timesInputed;

            //Assert
            Assert.True(actual > expected_moreThan);
        }
    }
}
