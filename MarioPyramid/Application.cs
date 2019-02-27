using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPyramid
{
    public class Application : IApplication
    {
        private IProgramLogic _programLogic;

        public Application(IProgramLogic programLogic)
        {
            _programLogic = programLogic;
        }

        public void Run()
        {
            _programLogic.LaunchPyramidProgram();
        }
    }
}
