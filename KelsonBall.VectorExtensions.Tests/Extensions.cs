using System;
using System.Numerics;

namespace KelsonBall.Vectors.Tests
{
    public static class AssertFloat
    {
        public static void AreEqual(float a, float b, float tolerance = float.Epsilon)
        {
            if (Math.Abs(a - b) >= tolerance)
                throw new Exception($"Values {a} and {b} were not with in tolerance of {tolerance}");
        }
    }

    public static class AssertDouble
    {
        public static void AreEqual (double a, double b, double tolerance = double.Epsilon)
        {
            if (Math.Abs(a - b) >= tolerance)
                throw new Exception($"Values {a} and {b} were not with in tolerance of {tolerance}");
        }
    }

    public static class AssertVector2
    {
        public static void AreEqual(Vector2 a, Vector2 b, float tolerance = float.Epsilon)
        {
            AssertFloat.AreEqual(a.X, b.X, tolerance);
            AssertFloat.AreEqual(a.Y, b.Y, tolerance);
        }
    }

    public static class AssertVector3
    {
        public static void AreEqual(Vector3 a, Vector3 b, float tolerance = float.Epsilon)
        {
            AssertFloat.AreEqual(a.X, b.X, tolerance);
            AssertFloat.AreEqual(a.Y, b.Y, tolerance);
            AssertFloat.AreEqual(a.Z, b.Z, tolerance);
        }
    }
}
