using DrawingProgram.Canvas.Commands;
using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;

namespace DrawingProgram
{
    internal class CommandFactory
    {
        public static ICommand<CanvasItem> CreateCommand(string cmd, CanvasItem canvas)
        {
            switch (cmd.ToUpper())
            {
                case "C":
                    return new CreateCanvasCommand();
                case "L":
                    return new CreateLineCommand(canvas);
                case "R":
                    return new CreateRectangleCommand(canvas);
                case "B":
                    return new BulketFillCommand(canvas);
                case "Q":
                    return new QuitProgramCommand();
                default:
                    throw new ArgumentException("Command is not supported!");
            }
        }
    }
}
