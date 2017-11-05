using System;

namespace Stack.NET.Utility
{
    /// <inheritdoc cref="IEquatable{T}" />
    /// <summary>Defines a index with three components.</summary>
    public struct Index3D : IEquatable<Index3D>
    {
        /// <summary>
        /// Returns a unit <see cref="Index3D"/> designating up (0, 1, 0).
        /// </summary>
        public static readonly Index3D Up = new Index3D(0, 1, 0);

        /// <summary>
        /// Returns a unit <see cref="Index3D"/> designating down (0, −1, 0).
        /// </summary>
        public static readonly Index3D Down = new Index3D(0, -1, 0);

        /// <summary>
        /// Returns a unit <see cref="Index3D"/> designating forward (0, 0, −1).
        /// </summary>
        public static readonly Index3D Forward = new Index3D(0, 0, -1);

        /// <summary>
        /// Returns a unit <see cref="Index3D"/> designating backward (0, 0, 1).
        /// </summary>
        public static readonly Index3D Backward = new Index3D(0, 0, 1);

        /// <summary>
        /// Returns a unit <see cref="Index3D"/> designating left (−1, 0, 0).
        /// </summary>
        public static readonly Index3D Left = new Index3D(-1, 0, 0);

        /// <summary>
        /// Returns a unit <see cref="Index3D"/> designating right (1, 0, 0).
        /// </summary>
        public static readonly Index3D Right = new Index3D(1, 0, 0);

        /// <summary>Gets the x-component of the index.</summary>
        public readonly int X;

        /// <summary>Gets the y-component of the index.</summary>
        public readonly int Y;

        /// <summary>Gets the z-component of the index.</summary>
        public readonly int Z;

        /// <summary>Initializes a new instance of <see cref="Index3D" />.</summary>
        public Index3D(int value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>Initializes a new instance of <see cref="Index3D" />.</summary>
        /// <param name="x">Initial value for the x-component of the index.</param>
        /// <param name="y">Initial value for the y-component of the index.</param>
        /// <param name="z">Initial value for the z-component of the index.</param>
        public Index3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the
        /// <see cref="T:Stack.NET.Utility.Index3D" />.
        /// </summary>
        /// <param name="index">
        /// The <see cref="T:Stack.NET.Utility.Index3D" /> to compare with the current
        /// <see cref="T:Stack.NET.Utility.Index3D" />.
        /// </param>
        /// <returns>
        /// true if the specified <see cref="T:Stack.NET.Utility.Index3D" /> is equal to the current
        /// <see cref="T:Stack.NET.Utility.Index3D" />; false otherwise.
        /// </returns>
        public bool Equals(Index3D index)
        {
            return X == index.X && Y == index.Y && Z == index.Z;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Index3D index && Equals(index);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }

        /// <summary>Returns a index that contains the highest value from each matching pair of components.</summary>
        /// <param name="value1">Source index.</param>
        /// <param name="value2">Source index.</param>
        /// <returns>The maximized index.</returns>
        public static Index3D Max(Index3D value1, Index3D value2)
        {
            return new Index3D(
                Math.Max(value1.X, value2.X),
                Math.Max(value1.Y, value2.Y),
                Math.Max(value1.Z, value2.Z));
        }

        /// <summary>Returns a index that contains the lowest value from each matching pair of components.</summary>
        /// <param name="value1">Source index.</param>
        /// <param name="value2">Source index.</param>
        /// <returns>The minimized index.</returns>
        public static Index3D Min(Index3D value1, Index3D value2)
        {
            return new Index3D(
                Math.Min(value1.X, value2.X),
                Math.Min(value1.Y, value2.Y),
                Math.Min(value1.Z, value2.Z));
        }

        /// <summary>Tests vectors for equality.</summary>
        /// <param name="value1">Source index.</param>
        /// <param name="value2">Source index.</param>
        /// <returns>true if the indicies are equal; false otherwise.</returns>
        public static bool operator ==(Index3D value1, Index3D value2)
        {
            return value1.X == value2.X
                   && value1.Y == value2.Y
                   && value1.Z == value2.Z;
        }

        /// <summary>Tests vectors for inequality.</summary>
        /// <param name="value1">Source index.</param>
        /// <param name="value2">Source index.</param>
        /// <returns>true if the indicies are not equal; false otherwise.</returns>
        public static bool operator !=(Index3D value1, Index3D value2)
        {
            return !(value1 == value2);
        }

        /// <summary>Adds two vectors.</summary>
        /// <param name="value1">Source index.</param>
        /// <param name="value2">Source index.</param>
        /// <returns>Sum of the indicies.</returns>
        public static Index3D operator +(Index3D value1, Index3D value2)
        {
            return new Index3D(value1.X + value2.X, value1.Y + value2.Y, value1.Z + value2.Z);
        }

        /// <summary>Subtracts a vector from a vector.</summary>
        /// <param name="value1">Source index.</param>
        /// <param name="value2">Source index.</param>
        /// <returns>Result of the subtraction.</returns>
        public static Index3D operator -(Index3D value1, Index3D value2)
        {
            return new Index3D(value1.X - value2.X, value1.Y - value2.Y, value1.Z - value2.Z);
        }
    }
}