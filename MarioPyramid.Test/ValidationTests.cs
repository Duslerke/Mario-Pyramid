using System;
using MarioPyramid.Utilities;
using MarioPyramid.Exceptions;
using Xunit;

namespace MarioPyramid.Test
{
    public class ValidationTests
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
        public void checkNumeric_ShouldThrow_EmptyInputException_WhenUserEntersNoInput()
        {
            Validation validation = new Validation();

            Action action = () => validation.checkNumeric("");

            Assert.Throws<EmptyInputException>(action);
        }

        [Theory]
        [InlineData("three")]
        [InlineData("22x")]
        [InlineData("2.7")]
        [InlineData("2^170")]
        [InlineData("15A2")]
        public void checkNumeric_ShouldThrow_NotANumberException_WhenUserEntersNaN(string input)
        {
            Validation validation = new Validation();

            Action action = () => validation.checkNumeric(input);

            Assert.Throws<NotANumberException>(action);
        }

        [Fact]
        public void checkNumeric_ShouldThrowNoException_WhenUserEntersAnInteger()
        {
            Validation validation = new Validation();
            string expected = "No error thrown.";
            string actual;

            try { validation.checkNumeric("21"); actual = expected; }
            catch (Exception e) { actual = e.Message; }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void checkInRange_ShouldThrow_HeightLimitExceededException_WhenInputHigherThan_23()
        {
            Validation validation = new Validation();

            Action action = () => validation.checkInRange(24);

            Assert.Throws<HeightLimitExceededException>(action);
        }

        [Fact]
        public void checkInRange_ShouldThrow_HeightCannotBeNegativeException_WhenInputLowerThan_0()
        {
            Validation validation = new Validation();

            Action action = () => validation.checkInRange(-1);

            Assert.Throws<HeightCannotBeNegativeException>(action);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(23)]
        public void checkInRange_ShouldThrowNoException_WhenUserEntersANumberBetween_0and23(int input)
        {
            Validation validation = new Validation();
            string expected = "No error thrown.";
            string actual;

            try { validation.checkInRange(input); actual = expected; }
            catch (Exception e) { actual = e.Message; }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void checkForCat_ShouldThrow_CatOnTheKeyboardException_When_20orMore_ExceptionsWereThrown()
        {
            Validation validation = new Validation();
            validation.errorCount = 20;

            Action action = () => validation.checkForCat();

            Assert.Throws<CatOnTheKeyboardException>(action);
        }

        [Fact]
        public void checkForCat_ShouldThrowNoException_When_LessThan20_ExceptionsWereThrown()
        {
            Validation validation = new Validation();
            validation.errorCount = 19;
            string expected = "No error thrown.";
            string actual;

            try { validation.checkForCat(); actual = expected; }
            catch (Exception e) { actual = e.Message; }

            Assert.Equal(expected, actual);
        }
    }
}
