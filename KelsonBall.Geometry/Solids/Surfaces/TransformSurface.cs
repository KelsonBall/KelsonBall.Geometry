using KelsonBall.Transforms;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using KelsonBall.Geometry.Solids;

namespace KelsonBall.Geometry.Surfaces
{
    public class TransformSurface : Surface
    {
        public readonly Surface Root;

        private readonly TransformStack<Vector3> transformStack;

        public override ISurfaceVertexAlgorithm VertexAlgorithm { get => Root.VertexAlgorithm; set => Root.VertexAlgorithm = value; }

        internal TransformSurface(Surface root)
        {
            Root = root;
            transformStack = Transform3.NewTransformStack();
        }

        public override Surface Transform(Transform<Vector3> transformation)
        {
            transformStack.Push(transformation);
            return this;
        }

        public override IEnumerable<Vector3> Intersections(Ray<Vector3> ray)
        {
            foreach (var intersect in Root.Intersections(ray.ApplyInverse(transformStack.Aggregate)))
                yield return intersect;
        }

        public override Vector3[] VertexArray()
            => Root.VertexArray()
                   .Select(vertex => transformStack.Aggregate.ApplyTo(vertex))
                   .ToArray();
    }
}
