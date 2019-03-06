
namespace MarioPyramid.Utilities
{
    public class PyramidHelper : IPyramidHelper
    {
        private IConsoleMethods _console { get; set; }

        public PyramidHelper(IConsoleMethods console)
        {
            _console = console;
        }

        public void DrawPyramid(int height)
        {
            string airblocks = GenerateAir(height);
            string pyramidblocks = "#";

            for (int i = height - 1; i >= 0; i--)
            {
                airblocks = airblocks.Remove(airblocks.Length - 1);
                pyramidblocks += "#";
                _console.WriteLine((airblocks + pyramidblocks));
            }
        }

        public string GenerateAir(int height)
        {
            string airStack = "";
            for (int i = 1; i < (height + 1); i++) { airStack += " "; }
            return airStack;
        }
    }
}
