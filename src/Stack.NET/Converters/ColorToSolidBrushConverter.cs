using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Stack.NET.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// An implementation of <see cref="T:System.Windows.Data.IValueConverter" /> that converts <see cref="T:System.Drawing.Color" /> values to
    /// <see cref="T:System.Windows.Media.Color" /> values.
    /// </summary>
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
            if (null == value)
            {
                return null;
            }
            
            if (value is Color color)
            {
                return new SolidColorBrush(color);
            }

            var type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
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