using KelsonBall.Transforms;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry
{
    public abstract class Perimeter : IBorder<Vector2>, ITransformable<Perimeter, Vector2>, IComposable<Perimeter>
    {

        public Perimeter And(Perimeter region)
        {
            throw new NotImplementedException();
        }

        public Perimeter Not(Perimeter region)
        {
            throw new NotImplementedException();
        }

        public Perimeter Or(Perimeter region)
        {
            throw new NotImplementedException();
        }

        public Perimeter XOr(Perimeter region)
        {
            throw new NotImplementedException();
        }

        public virtual Perimeter Transform(Transform<Vector2> transform)
        {
            throw new NotImplementedException();
        }

        public abstract IEnumerable<Vector2> Intersections(Ray<Vector2> ray);

        public Vector2[] VertexArray()
        {
            throw new NotImplementedException();
        }
    }
}
