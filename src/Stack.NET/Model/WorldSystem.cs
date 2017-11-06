using System.Windows.Media.Media3D;
using Stack.NET.Utility;

namespace Stack.NET.Model
{
    public sealed class WorldSystem
    {
        public Padding Padding { get; set; }
        public double Length { get; set; }
        public double Half => Length / 2.0D;

        public Point3D Get(Index3D position)
        {
            return new Point3D
            {
                X = position.X * (Length + Padding.Horizontal) + Padding.Left,
                Y = position.Y * (Length + Padding.Vertical)  + Padding.Down,
                Z = position.Z * (Length + Padding.Depth) + Padding.Backward
            };
        }

        public Point3D Center(Index3D min, Index3D max)
        {
            var posMin = Get(min);
            var posMax = Get(max);
            return new Point3D
            {
                X = posMin.X + (posMax.X - posMin.X),
                Y = posMin.Y + (posMax.Y - posMin.Y),
                Z = posMin.Z + (posMax.Z - posMin.Z),
            };
        }
    }
}
