using System.Numerics;
using static System.Math;

namespace KelsonBall.Geometry
{

    public class Transform2 : Transform<Vector2>
    {
        public static TransformStack<Vector2> NewTransformStack() => new TransformStack<Vector2>(new Transform2());

        private Transform2() : base(3)
        {

        }

        private Transform2(double[,] matrix) : base(matrix)
        {
        }

        public override Vector2 ApplyTo(Vector2 v)
        {
            var affineVector = VectorExtensions.GetMathVector(v.X, v.Y, 1);
            return (transform * affineVector).ToVector2();
        }

        public override Vector2 ApplyInverse(Vector2 v)
        {
            var affineVector = VectorExtensions.GetMathVector(v.X, v.Y, 1);
            return (inverse * affineVector).ToVector2();
        }

        internal static Transform2 Translation(double x, double y)
        => new Transform2(new double[,]{
                { 1, 0, x },
                { 0, 1, y },
                { 0, 0, 1 }
            });

        internal static Transform2 Rotation(double Θ)
        {
            double c = Cos(Θ);
            double s = Sin(Θ);
            return new Transform2(new double[,]{
                { c, -s, 0 },
                { s,  c, 0 },
                { 0,  0, 1 }
            });
        }

        internal static Transform2 Scale(double s)
        => new Transform2(new double[,]{
                { s, 0, 0 },
                { 0, s, 0 },
                { 0, 0, 1 }
            });

        internal static Transform2 Scale(double x, double y)
        => new Transform2(new double[,]{
                { x, 0, 0 },
                { 0, y, 0 },
                { 0, 0, 1 }
            });
    }

    public static class Transform2StackOperations
    {
        public static TransformStack<Vector2> Translate(TransformStack<Vector2> stack, Vector2 v)
        {
            stack.Push(Transform2.Translation(v.X, v.Y));
            return stack;
        }

        public static TransformStack<Vector2> Rotate(TransformStack<Vector2> stack, double angle)
        {
            stack.Push(Transform2.Rotation(angle));
            return stack;
        }

        public static TransformStack<Vector2> Scale(TransformStack<Vector2> stack, double s)
        {
            stack.Push(Transform2.Scale(s));
            return stack;
        }

        public static TransformStack<Vector2> Scale(TransformStack<Vector2> stack, Vector2 v)
        {
            stack.Push(Transform2.Scale(v.X, v.Y));
            return stack;
        }
    }
}
