using static System.Math;
using Vector = System.Numerics.Vector3;

namespace KelsonBall.VectorExtensions
{
    public static partial class Vector3Extensions
    {        
        public static double Dot(this Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        public static double MagnitudeSquared(this Vector v1) => v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z;

        public static double Magnitude(this Vector v1) => Sqrt(v1.MagnitudeSquared());

        public static Vector Unit(this Vector v) => v / (float)v.Magnitude();

        public static double ScalarProjection(this Vector of, Vector onto) => of.Dot(onto) / of.Magnitude();

        public static Vector Projection(this Vector of, Vector onto) => onto.Unit() * (float)of.ScalarProjection(onto);

        public static double Angle(this Vector v1, Vector v2) => Acos(v1.Dot(v2) / (float)(v1.Magnitude() * v2.Magnitude()));

        public static bool EqualWithinTolerance(this Vector v1, Vector v2, float tolerance = float.Epsilon)
         => Abs(v1.X - v2.X) <= tolerance
         && Abs(v1.Y - v2.Y) <= tolerance
         && Abs(v1.Z - v2.Z) <= tolerance;
    }
}
