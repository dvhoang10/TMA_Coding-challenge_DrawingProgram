using System.Collections.Generic;

namespace DrawingProgram.Interfaces
{
    internal interface ICommand<T> where T : class
    {
        void ValidateCommand(List<string> cmd);
        T ExecuteCommand();
    }
}
