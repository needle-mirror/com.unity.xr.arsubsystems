using System;

namespace UnityEngine.XR.ARSubsystems
{
    /// <summary>
    /// Constructor info for the <see cref="XRHumanBodySubsystemDescriptor"/>.
    /// </summary>
    public struct XRHumanBodySubsystemCinfo : IEquatable<XRHumanBodySubsystemCinfo>
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
        /// Specifies if the current subsystem supports 2D human body pose estimation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports 2D human body pose estimation. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanBody2D { get; set; }

        /// <summary>
        /// Specifies if the current subsystem supports 3D human body pose estimation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports 3D human body pose estimation. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanBody3D { get; set; }

        /// <summary>
        /// Specifies if the current subsystem supports 3D human body scale estimation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports 3D human body scale estimation. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanBody3DScaleEstimation { get; set; }

        /// <summary>
        /// Tests for equality.
        /// </summary>
        /// <param name="other">The other <see cref="XRHumanBodySubsystemCinfo"/> to compare against.</param>
        /// <returns>`True` if every field in <paramref name="other"/> is equal to this <see cref="XRHumanBodySubsystemCinfo"/>, otherwise false.</returns>
        public bool Equals(XRHumanBodySubsystemCinfo other)
        {
            return (id.Equals(other.id) && implementationType.Equals(other.implementationType)
                    && supportsHumanBody2D.Equals(other.supportsHumanBody2D)
                    && supportsHumanBody3D.Equals(other.supportsHumanBody3D)
                    && supportsHumanBody3DScaleEstimation.Equals(other.supportsHumanBody3DScaleEstimation));
        }

        /// <summary>
        /// Tests for equality.
        /// </summary>
        /// <param name="obj">The `object` to compare against.</param>
        /// <returns>`True` if <paramref name="obj"/> is of type <see cref="XRHumanBodySubsystemCinfo"/> and
        /// <see cref="Equals(XRHumanBodySubsystemCinfo)"/> also returns `true`; otherwise `false`.</returns>
        public override bool Equals(System.Object obj)
        {
            return ((obj is XRHumanBodySubsystemCinfo) && Equals((XRHumanBodySubsystemCinfo)obj));
        }

        /// <summary>
        /// Tests for equality. Same as <see cref="Equals(XRHumanBodySubsystemCinfo)"/>.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <returns>`True` if <paramref name="lhs"/> is equal to <paramref name="rhs"/>, otherwise `false`.</returns>
        public static bool operator ==(XRHumanBodySubsystemCinfo lhs, XRHumanBodySubsystemCinfo rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Tests for inequality. Same as `!`<see cref="Equals(XRHumanBodySubsystemCinfo)"/>.
        /// </summary>
        /// <param name="lhs">The left-hand side of the comparison.</param>
        /// <param name="rhs">The right-hand side of the comparison.</param>
        /// <returns>`True` if <paramref name="lhs"/> is not equal to <paramref name="rhs"/>, otherwise `false`.</returns>
        public static bool operator !=(XRHumanBodySubsystemCinfo lhs, XRHumanBodySubsystemCinfo rhs)
        {
            return !lhs.Equals(rhs);
        }

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
                hashCode = (hashCode * 486187739) + supportsHumanBody2D.GetHashCode();
                hashCode = (hashCode * 486187739) + supportsHumanBody3D.GetHashCode();
                hashCode = (hashCode * 486187739) + supportsHumanBody3DScaleEstimation.GetHashCode();
            }
            return hashCode;
        }
    }

    /// <summary>
    /// The descriptor for the <see cref="XRHumanBodySubsystem"/>.
    /// </summary>
    public class XRHumanBodySubsystemDescriptor : SubsystemDescriptor<XRHumanBodySubsystem>
    {
        XRHumanBodySubsystemDescriptor(XRHumanBodySubsystemCinfo humanBodySubsystemCinfo)
        {
            id = humanBodySubsystemCinfo.id;
            subsystemImplementationType = humanBodySubsystemCinfo.implementationType;
            supportsHumanBody2D = humanBodySubsystemCinfo.supportsHumanBody2D;
            supportsHumanBody3D = humanBodySubsystemCinfo.supportsHumanBody3D;
            supportsHumanBody3DScaleEstimation = humanBodySubsystemCinfo.supportsHumanBody3DScaleEstimation;
        }

        /// <summary>
        /// Specifies if the current subsystem supports 2D human body pose estimation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports 2D human body pose estimation. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanBody2D { get; private set; }

        /// <summary>
        /// Specifies if the current subsystem supports 3D human body pose estimation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports 3D human body pose estimation. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanBody3D { get; private set; }

        /// <summary>
        /// Specifies if the current subsystem supports 3D human body scale estimation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current subsystem supports 3D human body scale estimation. Otherwise, <c>false</c>.
        /// </value>
        public bool supportsHumanBody3DScaleEstimation { get; private set; }

        internal static XRHumanBodySubsystemDescriptor Create(XRHumanBodySubsystemCinfo humanBodySubsystemCinfo)
        {
            if (String.IsNullOrEmpty(humanBodySubsystemCinfo.id))
            {
                throw new ArgumentException("Cannot create human body subsystem descriptor because id is invalid",
                                            "humanBodySubsystemCinfo");
            }

            if ((humanBodySubsystemCinfo.implementationType == null)
                || !humanBodySubsystemCinfo.implementationType.IsSubclassOf(typeof(XRHumanBodySubsystem)))
            {
                throw new ArgumentException("Cannot create human body subsystem descriptor because implementationType is invalid",
                                            "humanBodySubsystemCinfo");
            }

            return new XRHumanBodySubsystemDescriptor(humanBodySubsystemCinfo);
        }
    }
}
