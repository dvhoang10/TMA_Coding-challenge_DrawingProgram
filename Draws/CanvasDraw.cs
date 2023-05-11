using DrawingProgram.Canvas;
using DrawingProgram.Interfaces;
using System.Text;

namespace DrawingProgram.Draws
{
    internal class CanvasDraw : IDraw<CanvasItem>
    {
        public string Draw(CanvasItem cv)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cv.height; i++)
            {
                for (int j = 0; j < cv.width; j++)
                {
                    sb.Append(cv.cells[j, i]);
                }
                if (i < cv.height - 1) sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
