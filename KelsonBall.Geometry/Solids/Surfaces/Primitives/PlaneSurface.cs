using KelsonBall.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Surfaces.Primitives
{
    public class PlaneSurface : Surface
    {
        public PlaneSurface(Shape shape)
        {
            Shape = shape;
        }

        public readonly Shape Shape;

        public override IEnumerable<Vector3> Intersections(Ray<Vector3> ray)
        {
            throw new NotImplementedException();
        }
    }
}
