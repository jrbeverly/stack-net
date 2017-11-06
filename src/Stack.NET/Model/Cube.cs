using System.Windows.Media;

namespace Stack.NET.Model
{
    /// <summary>A 3-dimensional cube.</summary>
    public sealed class Cube
    {
        /// <summary>Constructs a <see cref="Cube" /> at the specified position.</summary>
        /// <param name="color">The surface color.</param>
        public Cube(Color color)
        {
            Surface = color;
        }

        /// <summary>The surface color of the cube.</summary>
        public Color Surface { get; set; }
    }
}