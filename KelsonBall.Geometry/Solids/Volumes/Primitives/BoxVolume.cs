using KelsonBall.Geometry.Solids.Primitives;
using System;
using System.Numerics;

namespace KelsonBall.Geometry.Volumes.Primitives
{
    public class BoxVolume : Volume, IBox
    {
        const double fudge = 1e-5;
        public Vector3 Dimensions { get; private set; }

        public BoxVolume(Vector3 dimensions)
        {
            Dimensions = dimensions;
        }

        public override bool Contains(Vector3 point)
        {
            return (point.X >= -Dimensions.X && point.X <= Dimensions.X)
                && (point.Y >= -Dimensions.Y && point.Y <= Dimensions.Y)
                && (point.Z >= -Dimensions.Z && point.Z <= Dimensions.Z);
        }
    }
}
