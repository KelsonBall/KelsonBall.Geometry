using System;
using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Surfaces.Primitives
{
    public class RectangularPrismSurface : Surface
    {
        private readonly Vector3 Size;

        private readonly Surface pX;
        private readonly Surface mX;
        private readonly Surface pY;
        private readonly Surface mY;
        private readonly Surface pZ;
        private readonly Surface mZ;

        public override IEnumerable<Vector3> Intersection(Ray<Vector3> ray)
        {
            throw new NotImplementedException();
        }
    }
}
