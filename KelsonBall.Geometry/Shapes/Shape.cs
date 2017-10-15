using KelsonBall.Geometry.Areas;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Shapes
{
    public class Shape : IBorder<Vector2>, IRegion<Vector2>, IComposable<Shape>, ITransformable<Shape, Vector2>
    {
        private readonly TransformStack<Vector2> transformStack = Transform2.NewTransformStack();

        public Area Area { get; private set; }
        public Perimeter Perimeter { get; private set; }

        public Shape(Area area, Perimeter perimeter)
        {
            Area = area;
            Perimeter = perimeter;
        }

        public Shape And(Shape region)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2 point)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vector2> Intersections(Ray<Vector2> ray)
        {
            foreach (var intersect in Perimeter.Intersections(ray))
                if (Area.Contains(intersect))
                    yield return intersect;
        }

        public Shape Not(Shape region)
        {
            throw new NotImplementedException();
        }

        public Shape Or(Shape region)
        {
            throw new NotImplementedException();
        }

        public Shape Transform(Transform<Vector2> transform)
        {
            Area.Transform(transform);
            Perimeter.Transform(transform);
            return this;
        }

        public Vector2[] VertexArray()
        {
            throw new NotImplementedException();
        }

        public Shape XOr(Shape region)
        {
            throw new NotImplementedException();
        }
    }
}
