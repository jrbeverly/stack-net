namespace Stack.NET.Model
{
    public struct Padding
    {
        public double Left;
        public double Right;
        public double Up;
        public double Down;
        public double Forward;
        public double Backward;

        public double Horizontal => Left + Right;
        public double Vertical => Up + Down;
        public double Depth => Forward + Backward;

        public Padding(double value = 0.0)
        {
            Left = Right = Up = Down = Forward = Backward = value;
        }
    }
}