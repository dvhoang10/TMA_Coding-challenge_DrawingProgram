using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Canvas.Commands
{
    internal class CreateCanvasCommand : ICommand<CanvasItem>
    {
        private int _width;
        private int _height;

        public void ValidateCommand(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Wrong input command");
            if (cmd.Count != 2)
                throw new ArgumentException("Only accept two arguments: width, height");
            if ((!int.TryParse(cmd[0], out _width) || _width < 0)
                || (!int.TryParse(cmd[1], out _height) || _height < 0))
                throw new ArgumentException("Only accept positive integer values");
        }

        public CanvasItem ExecuteCommand()
        {
            return new CanvasItem(_width, _height);
        }
    }
}
