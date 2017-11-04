using System.Windows.Media.Media3D;
using Stack.NET.Utility;

namespace Stack.NET.Model
{
    public sealed class Scene
    {
        public Scene()
        {
            Grid = new Grid();
        }

        public Grid Grid { get; }
        public float Scale { get; set; }
        public Padding Padding;
        public double Segment { get; set; }
        public double Length { get; set; }
        public double HalfLength => Length / 2.0D;

        public Point3D Center()
        {
            var min = Grid.Minimum();
            var max = Grid.Maximum();

            var center = new Point3D(
                MathHelper.Center(min.X, max.X + 1),
                MathHelper.Center(min.Y, max.Y + 1),
                MathHelper.Center(min.Z, max.Z + 1));

            return new Point3D
            {
                X = center.X * Segment,
                Y = center.Y * Segment,
                Z = center.Z * Segment
            };
        }

        public Point3D Position(Index3D position)
        {
            return new Point3D
            {
                X = position.X * Segment + (Segment - Length) / 2.0D,
                Y = position.Y * Segment,
                Z = position.Z * Segment + (Segment - Length) / 2.0D
            };
        }
    }
}
