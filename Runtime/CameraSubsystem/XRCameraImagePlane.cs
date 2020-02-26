using System;
using Unity.Collections;

namespace UnityEngine.XR.ARSubsystems
{
    /// <summary>
    /// Information about the camera image planes. An image "plane" refers to an image channel used in video encoding.
    /// </summary>
    public struct XRCameraImagePlane : IEquatable<XRCameraImagePlane>
    {
        /// <summary>
        /// The number of bytes per row for this plane.
        /// </summary>
        /// <value>
        /// The number of bytes per row for this plane.
        /// </value>
        public int rowStride { get; internal set; }

        /// <summary>
        /// The number of bytes per pixel for this plane.
        /// </summary>
        /// <value>
        /// The number of bytes per pixel for this plane.
        /// </value>
        public int pixelStride { get; internal set; }

        /// <summary>
        /// A "view" into the platform-specific plane data. It is an error to access <c>data</c> after the owning
        /// <see cref="XRCameraImage"/> has been disposed.
        /// </summary>
        /// <value>
        /// The platform-specific plane data.
        /// </value>
        public NativeArray<byte> data { get; internal set; }

        /// <summary>
        /// Generates a hash suitable for use with containers like `HashSet` and `Dictionary`.
        /// </summary>
        /// <returns>A hash code generated from this object's fields.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = data.GetHashCode();
                hash = hash * 486187739 + rowStride.GetHashCode();
                hash = hash * 486187739 + pixelStride.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Tests for equality.
        /// </summary>
        /// <param name="obj">The `object` to compare against.</param>
        /// <returns>`True` if <paramref name="obj"/> is of type <see cref="XRCameraImagePlane"/> and
        /// <see cref="Equals(XRCameraImagePlane)"/> also returns `true`; otherwise `false`.</returns>
        public override bool Equals(object obj) => ((obj is XRCameraImagePlane) && Equals((XRCameraImagePlane)obj));

        /// <summary>
        /// Tests for equality.
        /// </summary>
        /// <param name="other">The other <see cref="XRCameraImagePlane"/> to compare against.</param>
        /// <returns>`True` if every field in <paramref name="other"/> is equal to this <see cref="XRCameraImagePlane"/>, otherwise false.</returns>
        public bool Equals(XRCameraImagePlane other)
        {
            return
                (data.Equals(other.data)) &&
                (rowStride == other.rowStride) &&
                (pixelStride == other.pixelStride);
        }

        /// <summary>
        /// Tests for equality. Same as <see cref="Equals(XRCameraImagePlane)"/>.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <returns>`True` if <paramref name="lhs"/> is equal to <paramref name="rhs"/>, otherwise `false`.</returns>
        public static bool operator ==(XRCameraImagePlane lhs, XRCameraImagePlane rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Tests for inequality. Same as `!`<see cref="Equals(XRCameraImagePlane)"/>.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <returns>`True` if <paramref name="lhs"/> is not equal to <paramref name="rhs"/>, otherwise `false`.</returns>
        public static bool operator !=(XRCameraImagePlane lhs, XRCameraImagePlane rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Generates a string representation of this <see cref="XRCameraImagePlane"/>.
        /// </summary>
        /// <returns>A string representation of this <see cref="XRCameraImagePlane"/>.</returns>
        public override string ToString() => $"({data.Length} bytes, Row Stride: {rowStride}, Pixel Stride: {pixelStride})";
    }
}
