using System.Collections.Generic;

namespace Stack.NET.Utility
{
    public sealed class ColorCollection : List<NamedColor>
    {
        public ColorCollection(IEnumerable<NamedColor> colors) : base(colors)
        {
        }
    }
}