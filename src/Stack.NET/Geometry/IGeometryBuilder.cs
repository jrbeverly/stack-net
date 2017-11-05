using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Stack.NET.Geometry
{
    /// <summary>A builder to construct a <see cref="MeshGeometry3D" /> objects.</summary>
    public interface IGeometryBuilder
    {
        /// <summary>Appends a triangle to the underlying <see cref="MeshGeometry3D" />.</summary>
        /// <param name="p0">Source vertex.</param>
        /// <param name="p1">Source vertex.</param>
        /// <param name="p2">Source vertex.</param>
        void AddTriangle(Point3D p0, Point3D p1, Point3D p2);

        /// <summary>Constructs a <see cref="GeometryModel3D" /> from the underlying triangle mesh.</summary>
        /// <param name="color">The <see cref="Color" /> of the model.</param>
        /// <returns>The 3d geometry mesh.</returns>
        GeometryModel3D Build(Color color);

        /// <summary>Constructs a wireframe <see cref="GeometryModel3D" /> from the underlying triangle mesh.</summary>
        /// <param name="color">The <see cref="Color" /> of the model.</param>
        /// <returns>The 3d geometry mesh.</returns>
        GeometryModel3D Wireframe(Color color);
    }
}