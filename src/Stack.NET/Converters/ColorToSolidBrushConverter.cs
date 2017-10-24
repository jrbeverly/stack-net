using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Stack.NET.Utility;
using Color = System.Drawing.Color;

namespace Stack.NET.Converters
{
    /// <summary>An implementation of <see cref="IValueConverter" /> that converts <see cref="System.Drawing.Color" /> values to <see cref="System.Windows.Media.Color" /> values.</summary>
    public class ColorToSolidBrushConverter : IValueConverter
    {
        /// <summary>Attempts to convert the specified value.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(ColorHelper.Convert((Color) value));
        }

        /// <summary>Attempts to convert the specified value back.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}