namespace Stack.NET.Model
{
    /// <summary>
    /// 
    /// </summary>
    public struct Dimensions
    {
        public int Width { get; }
        public int Length { get; }
        public int Height { get; }

        public Dimensions(int width, int length, int height)
        {
            Width = width;
            Length = length;
            Height = height;
        }
    }
}
