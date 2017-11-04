using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Stack.NET.Geometry
{
    /// <inheritdoc />
    public sealed class GeometryBuilder : IGeometryBuilder
    {
        private readonly MeshGeometry3D _mesh;

        /// <summary>Initializes a new instance of the <see cref="GeometryBuilder" /> class.</summary>
        public GeometryBuilder()
        {
            _mesh = new MeshGeometry3D();
        }
        
        /// <inheritdoc />
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

        /// <inheritdoc />
        public GeometryModel3D Build(Color color)
        {
            var material = new DiffuseMaterial(new SolidColorBrush(color));
            var geometry = new GeometryModel3D(_mesh, material);

            return geometry;
        }

        /// <inheritdoc />
        public GeometryModel3D Wireframe(Color color)
        {
            var material = new DiffuseMaterial(new RadialGradientBrush(Colors.DimGray, Colors.WhiteSmoke));
            var geometry = new GeometryModel3D(_mesh, material);

            return geometry;
        }
    }
}