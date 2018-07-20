using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Stack.NET.Model;

namespace Stack.NET.Geometry
{
    /// <summary>A builder to construct a <see cref="Cube" />.</summary>
    public sealed class CubeBuilder : ICubeBuilder
    {
        /// <summary>The default width of the cube.</summary>
        public const int DefaultWidth = 1;

        /// <summary>Initializes a new instance of the <see cref="CubeBuilder" /> class.</summary>
        /// <param name="scale"></param>
        public CubeBuilder(double scale)
        {
            if (scale <= 0) throw new ArgumentOutOfRangeException(nameof(scale));

            Scale = scale;
        }

        /// <summary>The standard cube size.</summary>
        public double Scale { get; }

        /// <summary></summary>
        /// <param name="color">The <see cref="Color" /> of the model.</param>
        /// <returns>The 3d geometry mesh.</returns>
        /// <summary>Constructs a <see cref="GeometryModel3D" /> Cube from the underlying <see cref="GeometryBuilder" />.</summary>
        /// <param name="x">The bottom-left x-coordinate of the cube.</param>
        /// <param name="y">The bottom-left y-coordinate of the cube.</param>
        /// <param name="z">The bottom-left z-coordinate of the cube.</param>
        /// <returns>The <see cref="GeometryModel3D" /> cube.</returns>
        public GeometryModel3D Create(Color color, double x = 0, double y = 0, double z = 0)
        {
            var space = DefaultWidth * Scale;
            var points = new Point3D[8]
            {
                new Point3D(x, y, z),
                new Point3D(space + x, y, z),
                new Point3D(space + x, y, space + z),
                new Point3D(x, y, space + z),
                new Point3D(x, space + y, z),
                new Point3D(space + x, space + y, z),
                new Point3D(space + x, space + y, space + z),
                new Point3D(x, space + y, space + z)
            };

            var builder = new GeometryBuilder();
            builder.AddTriangle(points[3], points[2], points[6]);
            builder.AddTriangle(points[3], points[6], points[7]);
            builder.AddTriangle(points[2], points[1], points[5]);
            builder.AddTriangle(points[2], points[5], points[6]);
            builder.AddTriangle(points[1], points[0], points[4]);
            builder.AddTriangle(points[1], points[4], points[5]);
            builder.AddTriangle(points[0], points[3], points[7]);
            builder.AddTriangle(points[0], points[7], points[4]);
            builder.AddTriangle(points[7], points[6], points[5]);
            builder.AddTriangle(points[7], points[5], points[4]);
            builder.AddTriangle(points[2], points[3], points[0]);
            builder.AddTriangle(points[2], points[0], points[1]);

            return builder.Build(color);
        }
    }
}