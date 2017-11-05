using System;
using System.Windows.Media;
using Stack.NET.Utility;

namespace Stack.NET.Model
{
    /// <inheritdoc cref="IEquatable{T}" />
    /// <summary>A 3-dimensional cube.</summary>
    public sealed class Cube : IEquatable<Cube>
    {
        /// <summary>Constructs a <see cref="Cube" /> at the specified position.</summary>
        /// <param name="position">The position.</param>
        /// <param name="color">The surface color.</param>
        public Cube(Index3D position, Color color)
        {
            Surface = color;
            Position = position;
        }

        /// <summary>The surface color of the cube.</summary>
        public Color Surface { get; set; }

        /// <summary>The position of the cube.</summary>
        public Index3D Position { get; }

        /// <inheritdoc />
        public bool Equals(Cube cube)
        {
            return cube != null && Position.Equals(cube.Position) && Surface.Equals(cube.Surface);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Cube cube && Position.Equals(cube.Position) && Surface.Equals(cube.Surface);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
}