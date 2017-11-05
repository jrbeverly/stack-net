using System.Linq;
using System.Windows.Media;

namespace Stack.NET.Utility
{
    internal static class ColorHelper
    {
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