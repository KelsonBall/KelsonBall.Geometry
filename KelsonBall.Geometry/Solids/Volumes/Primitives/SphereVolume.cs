using KelsonBall.Geometry.Solids.Primitives;
using KelsonBall.VectorExtensions;
using System.Numerics;

namespace KelsonBall.Geometry.Volumes.Primitives
{
    public class SphereVolume : Volume, ISphere
    {
        const double fudge = 1e-5;
        private readonly double r2;
        public double Radius { get; private set; }

        public SphereVolume(double radius)
        {
            Radius = radius;
            r2 = radius * radius + fudge;
        }

        public override bool Contains(Vector3 point) => point.MagnitudeSquared() <= r2;
    }
}
