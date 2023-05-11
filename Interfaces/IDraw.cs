namespace DrawingProgram.Interfaces
{
    internal interface IDraw<T> where T : class
    {
        string Draw(T shape);
    }
}
