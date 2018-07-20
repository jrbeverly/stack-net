using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Stack.NET.Model
{
    /// <inheritdoc />
    /// <summary>A collection of predefined colors.</summary>
    public sealed class NamedColorCollection : List<NamedColor>
    {
        /// <inheritdoc />
        public NamedColorCollection(IEnumerable<NamedColor> colors) : base(colors)
        {
        }

        /// <summary>A collection of predefined colors.</summary>
        public static NamedColorCollection GetNamedColors()
        {
            return new NamedColorCollection(typeof(Colors).GetProperties()
                .Select(p => new
                {
                    p.Name,
                    Value = p.GetValue(null)
                })
                .Where(p => p.Value is Color)
                .Select(p => new NamedColor(p.Name, (Color) p.Value)));
        }
    }
}