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
        private enum typeOfLine
        {
            vertical,
            horiziontal,
        }

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
            if (x1 != x2 && y1 != y2)
                throw new ArgumentException("Only accept creating vertical and horizontal lines");

            _startPoint = new PointItem(x1, y1);
            _endPoint = new PointItem(x2, y2);
        }

        public CanvasItem ExecuteCommand()
        {
            if (_startPoint.x == _endPoint.x)
            {
                if (_startPoint.y <= _endPoint.y) CreateLine(_startPoint, _endPoint, typeOfLine.vertical);
                else CreateLine(_endPoint, _startPoint, typeOfLine.vertical);
            }
            else if (_startPoint.y == _endPoint.y)
            {
                if (_startPoint.x <= _endPoint.x) CreateLine(_startPoint, _endPoint, typeOfLine.horiziontal);
                else CreateLine(_endPoint, _startPoint, typeOfLine.horiziontal);
            }
            return _canvas;
        }

        private void CreateLine(PointItem start, PointItem end, typeOfLine type)
        {
            switch (type)
            {
                case typeOfLine.vertical:
                    for (int i = start.y; i <= end.y; i++)
                    {
                        _canvas.cells[start.x, i] = CanvasItem.lineChar;
                    }
                    break;
                case typeOfLine.horiziontal:
                    for (int i = start.x; i <= end.x; i++)
                    {
                        _canvas.cells[i, start.y] = CanvasItem.lineChar;
                    }
                    break;
                default: break;
            }
        }
    }
}
