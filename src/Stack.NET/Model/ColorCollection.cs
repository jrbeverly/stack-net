using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Stack.NET.Model
{
    public sealed class ColorCollection : List<NamedColor>
    {
        public ColorCollection(IEnumerable<NamedColor> colors) : base(colors)
        {
        }

        internal static ColorCollection GetNamedColors()
        {
            return new ColorCollection(typeof(Colors).GetProperties()
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