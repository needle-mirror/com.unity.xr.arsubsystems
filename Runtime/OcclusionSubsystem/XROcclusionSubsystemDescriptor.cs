using System;

namespace UnityEngine.XR.ARSubsystems
{
    /// <summary>
    /// Constructor parameters for the <see cref="XROcclusionSubsystemDescriptor"/>.
    /// </summary>
    public struct XROcclusionSubsystemCinfo : IEquatable<XROcclusionSubsystemCinfo>
    {
        /// <summary>
        /// Specifies an identifier for the provider implementation of the subsystem.
        /// </summary>
        /// <value>
        /// The identifier for the provider implementation of the subsystem.
        /// </value>
        public string id { get; set; }

        /// <summary>
        /// Specifies the provider implementation type to use for instantiation.
        /// </summary>
        /// <value>
        /// Specifies the provider implementation type to use for instantiation.
        /// </value>
        public Type implementationType { get; set; }

        /// <summary>
        /// Specifies if the current subsystem supports human segmentation stencil image.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports human segmentation stencil image. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanSegmentationStencilImage { get; set; }

        /// <summary>
        /// Specifies if the current subsystem supports human segmentation depth image.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports human segmentation depth image. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanSegmentationDepthImage { get; set; }

        /// <summary>
        /// Tests for equality.
        /// </summary>
        /// <param name="other">The other <see cref="XROcclusionSubsystemCinfo"/> to compare against.</param>
        /// <returns>`True` if every field in <paramref name="other"/> is equal to this <see cref="XROcclusionSubsystemCinfo"/>, otherwise false.</returns>
        public bool Equals(XROcclusionSubsystemCinfo other)
            => (id.Equals(other.id) && implementationType.Equals(other.implementationType)
                && supportsHumanSegmentationStencilImage.Equals(other.supportsHumanSegmentationStencilImage)
                && supportsHumanSegmentationDepthImage.Equals(other.supportsHumanSegmentationDepthImage));

        /// <summary>
        /// Tests for equality.
        /// </summary>
        /// <param name="obj">The `object` to compare against.</param>
        /// <returns>`True` if <paramref name="obj"/> is of type <see cref="XROcclusionSubsystemCinfo"/> and
        /// <see cref="Equals(XROcclusionSubsystemCinfo)"/> also returns `true`; otherwise `false`.</returns>
        public override bool Equals(System.Object obj) => ((obj is XROcclusionSubsystemCinfo) && Equals((XROcclusionSubsystemCinfo)obj));

        /// <summary>
        /// Tests for equality. Same as <see cref="Equals(XROcclusionSubsystemCinfo)"/>.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <returns>`True` if <paramref name="lhs"/> is equal to <paramref name="rhs"/>, otherwise `false`.</returns>
        public static bool operator ==(XROcclusionSubsystemCinfo lhs, XROcclusionSubsystemCinfo rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Tests for inequality. Same as `!`<see cref="Equals(XROcclusionSubsystemCinfo)"/>.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <returns>`True` if <paramref name="lhs"/> is not equal to <paramref name="rhs"/>, otherwise `false`.</returns>
        public static bool operator !=(XROcclusionSubsystemCinfo lhs, XROcclusionSubsystemCinfo rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Generates a hash suitable for use with containers like `HashSet` and `Dictionary`.
        /// </summary>
        /// <returns>A hash code generated from this object's fields.</returns>
        public override int GetHashCode()
        {
            int hashCode = 486187739;
            unchecked
            {
                hashCode = (hashCode * 486187739) + HashCode.ReferenceHash(id);
                hashCode = (hashCode * 486187739) + HashCode.ReferenceHash(implementationType);
                hashCode = (hashCode * 486187739) + supportsHumanSegmentationStencilImage.GetHashCode();
                hashCode = (hashCode * 486187739) + supportsHumanSegmentationDepthImage.GetHashCode();
            }
            return hashCode;
        }
    }

    /// <summary>
    /// Descriptor for the XROcclusionSubsystem.
    /// </summary>
    public class XROcclusionSubsystemDescriptor : SubsystemDescriptor<XROcclusionSubsystem>
    {
        XROcclusionSubsystemDescriptor(XROcclusionSubsystemCinfo occlusionSubsystemCinfo)
        {
            id = occlusionSubsystemCinfo.id;
            subsystemImplementationType = occlusionSubsystemCinfo.implementationType;
            supportsHumanSegmentationStencilImage = occlusionSubsystemCinfo.supportsHumanSegmentationStencilImage;
            supportsHumanSegmentationDepthImage = occlusionSubsystemCinfo.supportsHumanSegmentationDepthImage;
        }

        /// <summary>
        /// Specifies if the current subsystem supports human segmentation stencil image.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports human segmentation stencil image. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanSegmentationStencilImage { get; private set; }

        /// <summary>
        /// Specifies if the current subsystem supports human segmentation depth image.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports human segmentation depth image. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanSegmentationDepthImage { get; private set; }

        /// <summary>
        /// Creates the occlusion subsystem descriptor from the construction info.
        /// </summary>
        /// <param name="occlusionSubsystemCinfo">The occlusion subsystem descriptor constructor information.</param>
        internal static XROcclusionSubsystemDescriptor Create(XROcclusionSubsystemCinfo occlusionSubsystemCinfo)
        {
            if (String.IsNullOrEmpty(occlusionSubsystemCinfo.id))
            {
                throw new ArgumentException("Cannot create occlusion subsystem descriptor because id is invalid",
                                            "occlusionSubsystemCinfo");
            }

            if ((occlusionSubsystemCinfo.implementationType == null)
                || !occlusionSubsystemCinfo.implementationType.IsSubclassOf(typeof(XROcclusionSubsystem)))
            {
                throw new ArgumentException("Cannot create occlusion subsystem descriptor because implementationType is invalid",
                                            "occlusionSubsystemCinfo");
            }

            return new XROcclusionSubsystemDescriptor(occlusionSubsystemCinfo);
        }
    }
}
