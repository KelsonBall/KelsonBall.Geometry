using KelsonBall.Geometry.Surfaces.Primitives;
using KelsonBall.Geometry.Volumes.Primitives;

namespace KelsonBall.Geometry.Solids.Primitives
{
    public class Sphere : Solid, ISphere
    {
        public double Radius { get; private set; }

        public Sphere(double radius) : base(new SphereSurface(radius), new SphereVolume(radius))
        {
            Radius = radius;
        }
    }
}
