using System.Numerics;

namespace KelsonBall.Geometry.Volumes
{
    public class TransformVolume : Volume
    {
        public readonly Volume Root;

        private readonly TransformStack<Vector3> transformStack;

        internal TransformVolume(Volume root)
        {
            Root = root;
            transformStack = Transform3.NewTransformStack();
        }

        public override Volume Transform(Transform3 transformation)
        {
            transformStack.Push(transformation);
            return this;
        }

        public override bool Contains(Vector3 point)
        {
            return Root.Contains(transformStack.Aggregate.ApplyTo(point));
        }        
    }
}
