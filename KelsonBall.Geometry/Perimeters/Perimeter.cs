using System;
using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry
{
    public abstract class Perimeter
    {
        public abstract IEnumerable<Vector2> Intersections(Ray<Vector2> ray);

        public virtual Perimeter Transform(Transform<Vector2> transform)
        {
            throw new NotImplementedException();
        }
    }
}
