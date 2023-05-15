using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Canvas.Commands
{
    internal class CreateLineCommand : ICommand<CanvasItem>
    {
        private PointItem _startPoint, _endPoint;
        private CanvasItem _canvas;

        public CreateLineCommand(CanvasItem canvas)
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
            if (x1 == 0 || y1 == 0 || x2 > _canvas.width - 2 || y2 > _canvas.height - 2)
                throw new ArgumentException("Only accept points inside the canvas");

            _startPoint = new PointItem(x1, y1);
            _endPoint = new PointItem(x2, y2);
        }

        public CanvasItem ExecuteCommand()
        {
            if (_startPoint.x == _endPoint.x)
            {
                for (int i = _startPoint.y; i <= _endPoint.y; i++)
                {
                    _canvas.cells[_startPoint.x, i] = CanvasItem.lineChar;
                }
            }
            else if (_startPoint.y == _endPoint.y)
            {
                for (int i = _startPoint.x; i <= _endPoint.x; i++)
                {
                    _canvas.cells[i, _startPoint.y] = CanvasItem.lineChar;
                }
            }
            return _canvas;
        }
    }
}
