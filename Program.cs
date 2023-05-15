using DrawingProgram.Commands;
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

                    CommandController controller = new CommandController(CommandFactory.CreateCommand(input[0], canvas));
                    controller.Validate(input.Skip(1).ToList());
                    canvas = controller.Execute();

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
            Console.WriteLine(@"L x1 y1 x2 y2   Should create a new line from (x1, y1) to (x2, y2).
                Currently only horizontal or vertical lines are supported.
                Horizontal and vertical lines will be drawn using the 'x' character.");
            Console.WriteLine(@"R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner 
                is (x1, y1) and lower right corner is (x2, y2). 
                Horizontal and vertical lines will be drawn using the 'x' character.");
            Console.WriteLine(@"B x y c         Should fill the entire area connected to (x, y) with color c. 
                The behavior of this is the same as that of the ""bucket fill"" tool in paint programs.");
            Console.WriteLine("Q               Quit the program.");
        }
    }
}
