using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Surfaces
{
    public abstract class Surface
    {
        public abstract IEnumerable<Vector3> Intersection(Ray<Vector3> ray);

        public virtual Surface Transform(Transform3 transformation)
        {
            var tSurface = new TransformSurface(this);

            return tSurface;
        }
    }
}
