using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Stack.NET.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// An implementation of <see cref="T:System.Windows.Data.IValueConverter" /> that converts <see cref="T:System.Drawing.Color" /> values to <see cref="T:System.Windows.Media.Color" /> values.
    /// </summary>
    public class ColorToSolidBrushConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null == value)
                return null;

            if (value is Color color)
                return new SolidColorBrush(color);

            var type = value.GetType();
            throw new InvalidOperationException($"Unsupported type [{type.Name}]");
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}