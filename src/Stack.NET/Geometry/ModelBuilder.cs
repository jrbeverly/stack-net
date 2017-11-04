using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Stack.NET.Geometry
{
    /// <summary>A builder to construct a <see cref="MeshGeometry3D" /> objects.</summary>
    public sealed class ModelBuilder
    {
        private readonly MeshGeometry3D _mesh;

        /// <summary>Initializes a new instance of the <see cref="ModelBuilder" /> class.</summary>
        public ModelBuilder()
        {
            _mesh = new MeshGeometry3D();
        }

        /// <summary>Appends a triangle to the underlying <see cref="MeshGeometry3D" />.</summary>
        /// <param name="p0">Source vertex.</param>
        /// <param name="p1">Source vertex.</param>
        /// <param name="p2">Source vertex.</param>
        public void AddTriangle(Point3D p0, Point3D p1, Point3D p2)
        {
            _mesh.Positions.Add(p0);
            _mesh.Positions.Add(p1);
            _mesh.Positions.Add(p2);

            var count = _mesh.TriangleIndices.Count;
            _mesh.TriangleIndices.Add(count + 0);
            _mesh.TriangleIndices.Add(count + 1);
            _mesh.TriangleIndices.Add(count + 2);
        }

        /// <summary>Constructs a <see cref="GeometryModel3D" /> from the underlying triangle mesh.</summary>
        /// <param name="color">The <see cref="Color" /> of the model.</param>
        /// <returns>The 3d geometry mesh.</returns>
        public GeometryModel3D Build(Color color)
        {
            var material = new DiffuseMaterial(new SolidColorBrush(color));
            var geometry = new GeometryModel3D(_mesh, material);

            return geometry;
        }

        /// <summary>Constructs a wireframe <see cref="GeometryModel3D" /> from the underlying triangle mesh.</summary>
        /// <param name="color">The <see cref="Color" /> of the model.</param>
        /// <returns>The 3d geometry mesh.</returns>
        public GeometryModel3D Wireframe(Color color)
        {
            var material = new DiffuseMaterial(new RadialGradientBrush(Colors.DimGray, Colors.WhiteSmoke));
            var geometry = new GeometryModel3D(_mesh, material);

            return geometry;
        }
    }
}