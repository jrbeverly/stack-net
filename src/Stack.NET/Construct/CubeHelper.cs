using System.Windows.Media.Media3D;
using Stack.NET.Geometry;
using Stack.NET.Utility;

namespace Stack.NET.Construct
{
    public static class CubeHelper
    {
        public static Model3DGroup CreateSelection()
        {
            var cubeBuilder = new CubeBuilder(MovementConstants.ScaleFactor + 0.01D);
            var cube = cubeBuilder.Create(System.Windows.Media.Colors.Red, 0, 0, 0);

            var group = new Model3DGroup();
            @group.Children.Add(cube);

            return @group;
        }
    }
}
