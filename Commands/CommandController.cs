using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System.Collections.Generic;

namespace DrawingProgram.Commands
{
    internal class CommandController
    {
        private ICommand<CanvasItem> _command;

        public CommandController(ICommand<CanvasItem> command)
        {
            _command = command;
        }

        public void Validate(List<string> cmd)
        {
            _command.ValidateCommand(cmd);
        }

        public CanvasItem Execute()
        {
            return _command.ExecuteCommand();
        }
    }
}
