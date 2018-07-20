using System.Windows;
using Stack.NET.Model;

namespace Stack.NET.Controls
{
    /// <inheritdoc cref="System.Windows.Controls.UserControl" />
    public partial class NamedColorBox
    {
        /// <summary>The Colors dependency property.</summary>
        public static readonly DependencyProperty ColorsProperty = DependencyProperty.Register(
            nameof(Colors),
            typeof(NamedColorCollection),
            typeof(NamedColorBox),
            new PropertyMetadata());

        /// <summary>The SelectedColor dependency property.</summary>
        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            nameof(SelectedColor),
            typeof(NamedColor),
            typeof(NamedColorBox),
            new PropertyMetadata());

        public NamedColorBox()
        {
            InitializeComponent();
        }

        /// <summary>A collection of named colors.</summary>
        public NamedColorCollection Colors
        {
            get => (NamedColorCollection) GetValue(ColorsProperty);
            set => SetValue(ColorsProperty, value);
        }

        /// <summary>The currently selected color.</summary>
        public NamedColor SelectedColor
        {
            get => (NamedColor) GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }
    }
}