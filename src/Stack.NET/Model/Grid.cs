using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Stack.NET.Utility;

namespace Stack.NET.Model
{
    using Position = Index3D;

    /// <summary>
    /// Represents a loosely structured 3-dimensional grid.
    /// </summary>
    public sealed class Grid
    {
        //TODO: Index3D as Strongly Typed Position
        private readonly Dictionary<Position, Cube> _cubes;

        public Grid()
        {
            _cubes = new Dictionary<Position, Cube>();
        }

        //TODO: Remove this from the model
        public Color Surface { get; set; }

        public IReadOnlyCollection<Cube> Cubes => _cubes.Values;

        public double Segment { get; set; }
        public double Length { get; set; }
        public double HalfLength => Length / 2.0D;

        public void Place(int x, int y, int z, Color color)
        {
            var point = new Position(x, y, z);

            if (!_cubes.TryGetValue(point, out var cube))
            {
                cube = new Cube(new Position(x, y, z), color);
                _cubes.Add(point, cube);
            }

            cube.Surface = color;
        }

        public void Destroy(int x, int y, int z)
        {
            var point = new Position(x, y, z);
            _cubes.Remove(point);
        }

        public void Range(out Position min, out Position max)
        {
            var vmax = new Position(int.MinValue, int.MinValue, int.MinValue);
            var vmin = new Position(int.MaxValue, int.MaxValue, int.MaxValue);

            foreach (var index in Cubes)
            {
                vmin = Index3D.Min(vmin, index.Position);
                vmax = Index3D.Max(vmax, index.Position);
            }

            min = vmin;
            max = vmax;
        }

        public Position Maximum()
        {
            var vmax = new Index3D(int.MinValue, int.MinValue, int.MinValue);
            return Cubes.Aggregate(vmax, (current, index) => Index3D.Max(current, index.Position));
        }

        public Position Minimum()
        {
            var vmin = new Index3D(int.MaxValue, int.MaxValue, int.MaxValue);
            return Cubes.Aggregate(vmin, (current, index) => Index3D.Min(current, index.Position));
        }

        public Point3D Center()
        {
            Range(out var min, out var max);

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