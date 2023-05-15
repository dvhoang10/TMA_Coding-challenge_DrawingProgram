using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;
using System.Collections.Generic;

namespace DrawingProgram.Canvas.Commands
{
    internal class QuitProgramCommand : ICommand<CanvasItem>
    {
        public void ValidateCommand(List<string> cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException("Wrong input command");
        }

        public CanvasItem ExecuteCommand()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
