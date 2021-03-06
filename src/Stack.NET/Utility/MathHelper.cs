using System;
using System.Windows.Media.Media3D;

namespace Stack.NET.Utility
{
    /// <summary>Contains commonly used mathematics functions.</summary>
    public static class MathHelper
    {
        /// <summary>Finds normal vector of a triangle given by vertices.</summary>
        /// <param name="p0">Source vertex.</param>
        /// <param name="p1">Source vertex.</param>
        /// <param name="p2">Source vertex.</param>
        /// <returns>Normal vector.</returns>
        public static Vector3D Normal(Point3D p0, Point3D p1, Point3D p2)
        {
            var v0 = new Vector3D(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            var v1 = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);

            var result = Vector3D.CrossProduct(v0, v1);
            result.Normalize();

            return result;
        }

        /// <summary>Linearly interpolates the center between two values.</summary>
        /// <param name="value1">Source value.</param>
        /// <param name="value2">Source value.</param>
        /// <returns>Interpolated value.</returns>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>
        /// value1 + (value2 - value1) * amount
        /// </code>
        /// Passing amount a value of 0 will cause value1 to be returned, a value of 1 will cause value2 to be returned.
        /// </remarks>
        /// <seealso cref="http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.mathhelper.lerp.aspx" />
        public static double Center(int value1, int value2)
        {
            return value1 + (Math.Abs(value2) + (double) Math.Abs(value1)) / 2.0D;
        }
    }
}