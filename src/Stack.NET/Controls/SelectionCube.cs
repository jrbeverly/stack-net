using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Stack.NET.Geometry;

namespace Stack.NET.Controls
{
    /// <inheritdoc />
    /// <summary>
    /// Describes a cube representing the user cursor.
    /// </summary>
    public sealed class SelectionCube : ModelVisual3D
    {
        /// <summary>The <see cref="Position"/> dependency property.</summary>
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(
            nameof(Position),
            typeof(Vector3D),
            typeof(SelectionCube),
            new PropertyMetadata(new Vector3D(10, 10, 10)));

        /// <summary>The <see cref="Color"/> dependency property.</summary>
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color),
            typeof(Color),
            typeof(SelectionCube),
            new PropertyMetadata(Colors.CornflowerBlue));

        /// <inheritdoc />
        /// <summary>
        /// Constructs an instance of the <see cref="T:Stack.NET.Controls.SelectionCube" /> class.
        /// </summary>
        public SelectionCube()
        {
        }

        /// <summary>
        /// The position of the cube.
        /// </summary>
        public Vector3D Position { get; set; }

        /// <summary>
        /// The color of the cube.
        /// </summary>
        public Color Color { get; set; }
    }
}
