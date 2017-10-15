using MathNet.Numerics.LinearAlgebra.Double;
using v = MathNet.Numerics.LinearAlgebra.Vector<double>;
using System.Numerics;

namespace KelsonBall.Geometry
{
    public static class VectorExtensions
    {
        public static v GetMathVector(params double[] values) => DenseVector.OfArray(values);

        public static v ToMathVector(this Vector3 vector) => GetMathVector(vector.X, vector.Y, vector.Z);

        public static v ToMathVector(this Vector2 vector) => GetMathVector(vector.X, vector.Y);

        public static Vector3 ToVector3(this v source) => new Vector3((float)source[0], (float)source[1], (float)source[2]);

        public static Vector2 ToVector2(this v source) => new Vector2((float)source[0], (float)source[1]);
    }
}
