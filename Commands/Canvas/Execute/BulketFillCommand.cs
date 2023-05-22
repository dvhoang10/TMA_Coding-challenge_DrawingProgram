using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Canvas.Commands
{
    internal class BulketFillCommand : ICommand<CanvasItem>
    {
        private PointItem _point;
        private CanvasItem _canvas;
        private char _color;

        public BulketFillCommand(CanvasItem canvas)
        {
            if (canvas == null) throw new ArgumentNullException("Please create a canvas");
            _canvas = canvas;
        }

        public void ValidateCommand(List<string> cmd)
        {
            int x1, y1;

            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("Wrong input command");
            if (cmd.Count != 3)
                throw new ArgumentException("Only accept three arguments: x, y, color");
            if ((!int.TryParse(cmd[0], out x1) || x1 < 0)
            || (!int.TryParse(cmd[1], out y1) || y1 < 0))
                throw new ArgumentException("Only accept positive integer values");
            if (x1 == 0 || y1 == 0 || x1 > _canvas.width - 2 || y1 > _canvas.height - 2)
                throw new ArgumentException("Only accept points inside the canvas");
            if (!char.TryParse(cmd[2], out _color))
                throw new ArgumentException("Only accept color as character type");

            _point = new PointItem(x1, y1);
        }

        public CanvasItem ExecuteCommand()
        {
            Queue<PointItem> queue = new Queue<PointItem>();
            queue.Enqueue(_point);
            char targetColor = _canvas.cells[_point.x, _point.y];

            while (queue.Count > 0)
            {
                PointItem current = queue.Dequeue();

                if (current.x > 0 && current.x < _canvas.width &&
                  current.y > 0 && current.y < _canvas.height)
                {
                    if (_canvas.cells[current.x, current.y] == targetColor)
                    {
                        _canvas.cells[current.x, current.y] = _color;
                        queue.Enqueue(new PointItem(current.x - 1, current.y));
                        queue.Enqueue(new PointItem(current.x + 1, current.y));
                        queue.Enqueue(new PointItem(current.x, current.y + 1));
                        queue.Enqueue(new PointItem(current.x, current.y - 1));
                    }
                }
            }
            return _canvas;
        }
    }
}
