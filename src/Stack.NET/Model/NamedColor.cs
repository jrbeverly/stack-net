using System.Windows.Media;

namespace Stack.NET.Model
{
    /// <summary>A collection of predefined colors.</summary>
    public sealed class NamedColor
    {
        /// <summary>Constructs an instance of a system-defined color.</summary>
        /// <param name="name">The name.</param>
        /// <param name="color">The color.</param>
        public NamedColor(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        /// <summary>Gets the name of the color.</summary>
        public string Name { get; }

        /// <summary>Gets the system-defined color.</summary>
        public Color Color { get; }
    }
}