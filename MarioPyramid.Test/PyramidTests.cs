using MarioPyramid.Test.Materials;
using MarioPyramid.Utilities;
using MarioPyramidTest.Materials;
using Xunit;

namespace MarioPyramid.Test
{
    public class PyramidTests
    {
        [Fact]
        public void GenerateAir_ShouldGenerate_EqualAmountOfAirBlocks_ToPyramidHeight()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);
            int height = 5;
            int expected = 5;

            string airBlocks = pyramid.GenerateAir(height);
            int actual = airBlocks.Length;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Ok, so the Pyramid tests are a bit tricky due to how I approached the problem, but it's still testable, if you test each criteria seperately:
        /// 
        /// 1) Pyramid should consist of h amount of floors, which corresponds to users inputed pyramid height h.
        /// 2) From Top to Down every subsequent floor should have 1 more hashtag in it.
        /// 3) From Top to Down every subsequent floor should have 1 less space in it.
        /// 4) The top floor of the pyramid should contain 2 hashtags.
        /// 5) The length of each floor should remain unchanging.
        /// 6) Hashtags are always on the right side of the spaces
        /// 7) The length of the pyramid is 1 greater than it's height
        /// 
        /// These 7 criteria objectively define the half pyramyd in the challenge.
        /// 
        /// 1) If the shape is being draw according to these criteria, the result will be the pyramid.
        /// 2) If a function is drawing a shape based on these criteria, then it means it draws the pyramid.
        /// 3) If DrawPyramid(h) passes the tests that check the implementation of these criteria, then it means it draws the pyramid.
        /// 
        /// </summary>

        [Fact]
        public void DrawPyramid_ShouldGenerate_PyramidOfHeight_EqualToInputHeight()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);
            int height = 7;
            int expected = 7;

            pyramid.DrawPyramid(height);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");
            int actual = floorsArray.Length;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DrawPyramid_ShouldIncrease_TheAmountofHashtags_By1_everySubsequentLine()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);

            pyramid.DrawPyramid(5);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");

            for(int i=0; i<floorsArray.Length-1; i++)
            {
                int hashCountAbove = Utility.CountInstances(floorsArray[i], '#');
                int hashCountBellow = Utility.CountInstances(floorsArray[i+1], '#');

                Assert.True(hashCountBellow > hashCountAbove);
            }
        }

        [Fact]
        public void DrawPyramid_ShouldDecrease_TheAmountofAirBlocks_By1_everySubsequentLine()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);

            pyramid.DrawPyramid(5);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");

            for (int i = 0; i < floorsArray.Length - 1; i++)
            {
                int hashCountAbove = Utility.CountInstances(floorsArray[i], ' ');
                int hashCountBellow = Utility.CountInstances(floorsArray[i + 1], ' ');

                Assert.True(hashCountBellow < hashCountAbove);
            }
        }

        [Fact]
        public void DrawPyramid_TopLineShouldContain_TwoHashtags()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);
            int expected = 2;

            pyramid.DrawPyramid(5);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");
            string topFloor = floorsArray[0];
            int actual = Utility.CountInstances(topFloor, '#');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DrawPyramid_SumLengthOf_PyramidAndAirBlocks_ShouldRemainConstant()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);

            pyramid.DrawPyramid(5);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");

            int expected = floorsArray[0].Length;

            for (int i = 1; i < floorsArray.Length; i++)
            {
                int actual = floorsArray[i].Length;


                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void DrawPyramid_ShouldDraw_HashtagsToTheRightOfSpaces()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);

            pyramid.DrawPyramid(8);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");

            for (int i = 1; i < floorsArray.Length; i++)
            {
                int indexHash = floorsArray[i].IndexOf('#');
                string left = floorsArray[i].Substring(0, indexHash);
                string right = floorsArray[i].Substring(indexHash);

                foreach(char c in left) { Assert.Equal(' ', c); } //every symbol has to be space
                foreach (char c in right) { Assert.Equal('#', c); } //every symbol has to be hashtag
            }
        }

        [Fact]
        public void DrawPyramid_ShouldDrawPyramidOfWidth_1GreaterThanHeight()
        {
            MockConsoleMethods console = new MockConsoleMethods();
            PyramidHelper pyramid = new PyramidHelper(console);
            int height = 12;
            int expected = height + 1;

            pyramid.DrawPyramid(height);
            string[] floorsArray = Utility.SplitThisBy(console.writeLineString, "\n");

            int actual = floorsArray[0].Length; //since we tested before that every line is of the same length, then I need only 1 test

            Assert.Equal(expected, actual);
        }
    }
}
