namespace DrawingProgram.Canvas
{
    internal class CanvasItem
    {
        public static char horizontalChar = '-';
        public static char verticalChar = '|';
        public int width { get; }
        public int height { get; }
        public char[,] cells { get; }

        public CanvasItem(int width, int height)
        {
            this.width = width + 2;
            this.height = height + 2;

            cells = new char[this.width, this.height];
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (i == 0 || i == this.height - 1) cells[j, i] = horizontalChar;
                    else if (j == 0 || j == this.width - 1) cells[j, i] = verticalChar;
                    else cells[j, i] = ' ';
                }
            }
        }
    }
}
