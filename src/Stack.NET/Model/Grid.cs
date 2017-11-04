using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Stack.NET.Utility;

namespace Stack.NET.Model
{
    using Position = Index3D;

    /// <summary>
    /// Represents a loosely structured 3-dimensional grid.
    /// </summary>
    public sealed class Grid
    {
        private readonly Dictionary<Position, Cube> _cubes;

        /// <summary>
        /// Initializes a new instance of a <see cref="Grid"/>.
        /// </summary>
        public Grid()
        {
            _cubes = new Dictionary<Position, Cube>();
            Dimensions = new Dimensions();
        }

        /// <summary>
        /// Gets a collection containing the cubes of the grid.
        /// </summary>
        public IReadOnlyCollection<Cube> Cubes => _cubes.Values;

        /// <summary>
        /// Gets a collection containing the cube positions.
        /// </summary>
        public IReadOnlyCollection<Position> Positions => _cubes.Keys;

        public IReadOnlyDictionary<Position, Cube> Values => _cubes;

        public Dimensions Dimensions { get; }
        
        /// <summary>
        /// Places a cube with the specified color.
        /// </summary>
        /// <param name="x">The x-component of the index.</param>
        /// <param name="y">The y-component of the index.</param>
        /// <param name="z">The z-component of the index.</param>
        /// <param name="color">The cube color.</param>
        public void Place(int x, int y, int z, Color color)
        {
            var point = new Position(x, y, z);

            if (!_cubes.TryGetValue(point, out var cube))
            {
                cube = new Cube(color);
                _cubes.Add(point, cube);
            }

            cube.Surface = color;
        }

        /// <summary>
        /// Places a cube at the specified position.
        /// </summary>
        /// <param name="x">The x-component of the index.</param>
        /// <param name="y">The y-component of the index.</param>
        /// <param name="z">The z-component of the index.</param>
        /// <param name="cube">The cube.</param>
        public void Place(int x, int y, int z, Cube cube)
        {
            Place(new Position(x, y, z), cube);
        }

        /// <summary>
        /// Places a cube at the specified position.
        /// </summary>
        /// <param name="position">The position of the cube.</param>
        /// <param name="cube">The cube.</param>
        public void Place(Position position, Cube cube)
        {
            _cubes[position] = cube;
        }

        /// <summary>
        /// Removes the cube at the specified position.
        /// </summary>
        /// <param name="x">The x-component of the index.</param>
        /// <param name="y">The y-component of the index.</param>
        /// <param name="z">The z-component of the index.</param>
        public void Destroy(int x, int y, int z)
        {
            Destroy(new Position(x, y, z));
        }

        /// <summary>
        /// Removes the cube at the specified position.
        /// </summary>
        /// <param name="position">The position of the cube.</param>
        public void Destroy(Position position)
        {
            _cubes.Remove(position);
        }

        public Position Maximum()
        {
            var vmax = new Index3D(int.MinValue, int.MinValue, int.MinValue);
            return _cubes.Keys.Aggregate(vmax, Index3D.Max);
        }

        public Position Minimum()
        {
            var vmin = new Index3D(int.MaxValue, int.MaxValue, int.MaxValue);
            return _cubes.Keys.Aggregate(vmin, Index3D.Min);
        }
    }
}