using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Surfaces
{
    public class TransformSurface : Surface
    {
        public readonly Surface Root;

        private readonly TransformStack<Vector3> transformStack;

        internal TransformSurface(Surface root)
        {
            Root = root;
            transformStack = Transform3.NewTransformStack();
        }

        public override Surface Transform(Transform3 transformation)
        {
            transformStack.Push(transformation);
            return this;
        }

        public override IEnumerable<Vector3> Intersection(Ray<Vector3> ray)
        {
            foreach (var intersect in Root.Intersection(ray.Transform(transformStack.Aggregate)))
                yield return intersect;
        }
    }
}
