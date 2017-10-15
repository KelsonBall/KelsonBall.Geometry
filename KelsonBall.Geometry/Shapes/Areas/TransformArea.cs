using System;
using System.Numerics;

namespace KelsonBall.Geometry.Areas
{
    public class TransformArea : Area
    {
        public readonly Area Root;

        private readonly TransformStack<Vector2> transformStack = Transform2.NewTransformStack();

        internal TransformArea(Area root)
        {
            Root = root;
        }

        public override bool Contains(Vector2 point) => Root.Contains(transformStack.Aggregate.ApplyInverse(point));

        public override Area Transform(Transform<Vector2> transform)
        {
            transformStack.Push(transform);
            return this;
        }
    }
}
