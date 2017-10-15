using KelsonBall.Geometry.Shapes;
using KelsonBall.VectorExtensions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace KelsonBall.Geometry.Surfaces.Primitives
{
    public class ExtendedCrossSectionSurface : Surface
    {
        public readonly Shape Shape;
        public readonly double Height;

        public ExtendedCrossSectionSurface(Shape shape, double height)
        {
            Shape = shape;
            Height = height;
        }

        public override IEnumerable<Vector3> Intersections(Ray<Vector3> ray)
        {
            var flatRay = new Ray2(ray.Origin.ToVector2(), ray.Direction.ToVector2());
            foreach (var flatIntersect in Shape.Intersections(flatRay))
            {
                var distance = (flatIntersect - flatRay.Origin).Magnitude();
                var verticalComponent = ray.Direction.Y * distance;
                if (verticalComponent <= Height && verticalComponent >= -Height)
                    yield return new Vector3(flatIntersect.X, (float)verticalComponent, flatIntersect.Y);
            }

            if (ray.Direction.Y != 0)
            {
                var component = (Height - ray.Origin.Y) / ray.Direction.Y;
                var point = flatRay.Direction.Scale(component) + flatRay.Origin;
                if (Shape.Contains(point))
                    yield return new Vector3(point.X, (float)Height, point.Y);
                component = (-Height - ray.Origin.Y) / ray.Direction.Y;
                point = flatRay.Direction.Scale(component) + flatRay.Origin;
                if (Shape.Contains(point))
                    yield return new Vector3(point.X, (float)Height, point.Y);
            }

        }
    }
}
