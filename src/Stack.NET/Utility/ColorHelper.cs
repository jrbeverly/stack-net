using System;
using System.Collections.Generic;
using System.Drawing;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Drawing.ColorConverter;

namespace Stack.NET.Utility
{
    using MediaColor = Color;
    using DrawColor = System.Drawing.Color;

    public static class ColorHelper
    {
        public static IEnumerable<DrawColor> GetColors()
        {
            var converter = new ColorConverter();
            var kc = new KnownColor();
            foreach (KnownColor knownColor in Enum.GetValues(kc.GetType()))
            {
                var color = DrawColor.FromName(knownColor.ToString());

                if (!color.IsSystemColor)
                    yield return color;
            }
        }

        public static DrawColor Convert(MediaColor color)
        {
            return DrawColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static MediaColor Convert(DrawColor color)
        {
            return MediaColor.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}