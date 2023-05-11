using DrawingProgram.Canvas;
using DrawingProgram.Canvas.Commands;
using DrawingProgram.Interfaces;
using System;

namespace DrawingProgram
{
    internal class CanvasFactory
    {
        public static ICommand<CanvasItem> CreateCanvas(string cmd, CanvasItem canvas)
        {
            switch (cmd.ToUpper())
            {
                case "C":
                    return new CreateCanvasCommand();
                case "Q":
                    Environment.Exit(0);
                    return null;
                default:
                    throw new ArgumentException("Command is not supported!");
            }
        }
    }
}
