namespace Stack.NET.Model
{
    public struct Padding
    {
        public float Left;
        public float Right;
        public float Forward;
        public float Up;
        public float Down;
        public float Backward;

        public Padding(float padding)
        {
            Left = Right = Forward = Up = Down = Backward = padding;
        }

        public float All { set => Left = Right = Forward = Up = Down = Backward = value; }
    }
}
