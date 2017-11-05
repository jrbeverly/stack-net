using System.Windows.Media;

namespace Stack.NET.Model
{
    /// <summary>Describes a predefined color.</summary>
    /// <remarks>
    /// The Windows Presentation Foundation (WPF) color names match the Microsoft .NET Framework version 1.0, Windows Forms, and Microsoft Internet Explorer color names. This representation is based on UNIX X11 named color values.
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/system.windows.media.colors(v=vs.110).aspx"/>
    /// </remarks>
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