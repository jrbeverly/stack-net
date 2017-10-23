using System;

namespace Stack.NET.Utility
{
    public sealed class Index3D : IEquatable<Index3D>
    {
        /// <summary>
        ///     Gets or sets the x-component of the vector.
        /// </summary>
        public int X;

        /// <summary>
        ///     Gets or sets the y-component of the vector.
        /// </summary>
        public int Y;

        /// <summary>
        ///     Gets or sets the z-component of the vector.
        /// </summary>
        public int Z;

        /// <summary>
        ///     Initializes a new instance of <see cref="Index3D" />.
        /// </summary>
        /// <param name="x">Initial value for the x-component of the vector.</param>
        /// <param name="y">Initial value for the y-component of the vector.</param>
        /// <param name="z">Initial value for the z-component of the vector.</param>
        public Index3D(int x = 0, int y = 0, int z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Index3D index)
        {
            return index != null && X == index.X && Y == index.Y && Z == index.Z;
        }

        public override bool Equals(object obj)
        {
            var index = obj as Index3D;
            return index != null && X == index.X && Y == index.Y && Z == index.Z;
        }
    }
}