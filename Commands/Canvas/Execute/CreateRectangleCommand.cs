using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Canvas.Commands
{
    internal class CreateRectangleCommand : ICommand<CanvasItem>
    {
        private PointItem _startPoint, _endPoint;
        private CanvasItem _canvas;

        public CreateRectangleCommand(CanvasItem canvas)
        {
            if (canvas == null) throw new ArgumentNullException("Please create a canvas");
            _canvas = canvas;
        }

        public void ValidateCommand(List<string> cmd)
        {
            int x1, y1, x2, y2;

            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Wrong input command");
            if (cmd.Count != 4)
                throw new ArgumentException("Only accept four arguments: x1 y1 x2 y2");
            if ((!int.TryParse(cmd[0], out x1) || x1 < 0)
                || (!int.TryParse(cmd[1], out y1) || y1 < 0)
                || (!int.TryParse(cmd[2], out x2) || x2 < 0)
                || (!int.TryParse(cmd[3], out y2) || y2 < 0))
                throw new ArgumentException("Only accept positive integer values");
            if (x1 > x2 || y1 > y2)
                throw new ArgumentException("Please enter x1 < x2 & y1 < y2");
            if (x1 == 0 || y1 == 0 || x2 > _canvas.width - 2 || y2 > _canvas.height - 2)
                throw new ArgumentException("Only accept points inside the canvas");

            _startPoint = new PointItem(x1, y1);
            _endPoint = new PointItem(x2, y2);
        }

        public CanvasItem ExecuteCommand()
        {
            for (int i = _startPoint.y; i <= _endPoint.y; i++)
            {
                for (int j = _startPoint.x; j <= _endPoint.x; j++)
                {
                    if (i == _startPoint.y || i == _endPoint.y
                        || j == _startPoint.x || j == _endPoint.x)
                    {
                        _canvas.cells[j, i] = CanvasItem.lineChar;
                    }
                    else _canvas.cells[j, i] = ' ';
                }
            }
            return _canvas;
        }
    }
}
