using KelsonBall.Geometry.Areas;
using KelsonBall.VectorExtensions;
using System.Numerics;

namespace KelsonBall.Geometry.Volumes.Primitives
{
    public class ExtendedCrossSectionVolume : Volume
    {
        const double fudge = 1e-5;
        public readonly Area CrossSection;
        public readonly double Height;

        public ExtendedCrossSectionVolume(Area crossSection, double height)
        {
            CrossSection = crossSection;
            Height = height;
        }

        public override bool Contains(Vector3 point)
        {
            return CrossSection.Contains(point.ToVector2()) && (point.Y + fudge <= Height && point.Y + fudge >= -Height);
        }
    }
}
