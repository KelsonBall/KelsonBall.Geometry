using System;
using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Perimeters.Primitives
{
    public class LinePerimeter : Perimeter
    {
        public readonly double Length;

        public LinePerimeter(double length)
        {
            Length = length;
        }

        public override IEnumerable<Vector2> Intersections(Ray<Vector2> ray)
        {
            throw new NotImplementedException();
        }
    }
}
