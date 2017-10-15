using System;
using System.Numerics;
using KelsonBall.VectorExtensions;
using System.Collections.Generic;

namespace KelsonBall.Geometry.Surfaces.Primitives
{
    public class SphereSurface : Surface
    {
        private readonly double r2;
        private readonly double radius;

        public double Radius => radius;

        public SphereSurface(double radius)
        {
            this.radius = radius;
            this.r2 = radius * radius;
        }


        public override IEnumerable<Vector3> Intersection(Ray<Vector3> ray)
        {
            var o = ray.Origin;
            var d = ray.Direction;
            var L = -o;
            if (L.Dot(d) < 0)
                yield break;
            
            var projection = L.Projection(d);

            var centerDistance = (L - projection).Magnitude();
            var halfChord = (float)Math.Sqrt(r2 + centerDistance * centerDistance);

            yield return projection - d * halfChord;
            yield return projection + d * halfChord;            
        }
    }
}
