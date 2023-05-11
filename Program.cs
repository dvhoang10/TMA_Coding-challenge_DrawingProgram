using DrawingProgram.Draws;
using DrawingProgram.Interfaces;
using DrawingProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CanvasItem canvas = null;
            DisplayDescription();
            while (true)
            {
                try
                {
                    Console.Write("\nPlease enter the command: ");
                    List<string> input = Console.ReadLine().Split(' ').ToList();

                    ICommand<CanvasItem> command = CanvasFactory.CreateCanvas(input[0], canvas);
                    command.ValidateCommand(input.Skip(1).ToList());
                    canvas = command.ExecuteCommand();

                    CanvasDraw canvasDraw = new CanvasDraw();
                    Console.WriteLine(canvasDraw.Draw(canvas));
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DisplayDescription()
        {
            Console.WriteLine("Instruct");
            Console.WriteLine("C w h           Should create a new canvas of width w and height h.");
            Console.WriteLine("L x1 y1 x2 y2   Should create a new line from (x1, y1) to (x2, y2).\n" +
                "\t\tCurrently only horizontal or vertical lines are supported.\n" +
                "\t\tHorizontal and vertical lines will be drawn using the 'x' character.");
            Console.WriteLine("Q               Quit the program");
        }
    }
}
