using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Stack.NET.Geometry
{
    public interface ICubeBuilder
    {
        GeometryModel3D Create(Color color, double x = 0, double y = 0, double z = 0);
    }
}