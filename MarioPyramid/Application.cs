
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
