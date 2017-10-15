using System.Numerics;
using KelsonBall.Geometry.Surfaces.Primitives;
using KelsonBall.Geometry.Volumes.Primitives;

namespace KelsonBall.Geometry.Solids.Primitives
{
    public class Box : Solid, IBox
    {
        public Vector3 Dimensions { get; private set; }

        public Box(Vector3 dimensions) : base(new BoxSurface(dimensions), new BoxVolume(dimensions))
        {
            Dimensions = dimensions;
        }
    }
}
