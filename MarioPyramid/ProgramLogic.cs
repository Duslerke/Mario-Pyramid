using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioPyramid.Utilities;

namespace MarioPyramid
{
    public class ProgramLogic : IProgramLogic
    {
        private IInputHelper _input;
        private IPyramidHelper _pyramid;

        public ProgramLogic(IInputHelper input, IPyramidHelper pyramid)
        {
            _input = input;
            _pyramid = pyramid;
        }

        public void LaunchPyramidProgram()
        {
            do
            {
                int height = _input.GetUserInput();
                _pyramid.DrawPyramid(height);

                Console.WriteLine("\n");
            } while (!_input.PromptForExit());
        }
    }
}
