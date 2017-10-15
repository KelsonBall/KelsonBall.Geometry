using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace KelsonBall.VectorExtensions.Tests
{
    [TestClass]
    public class MagnitudeTests
    {


        [TestMethod]
        public void Vector2MagnitudeOfTrianglesTest()
        {
            AssertDouble.AreEqual(new Vector2(1, 1).Magnitude(), Math.Sqrt(2));
            AssertDouble.AreEqual(new Vector2(3, 4).Magnitude(), 5);
        }

        [TestMethod]
        public void Vector3MagnitudeOfTrianglesTest()
        {
            AssertDouble.AreEqual(new Vector3(1, 1, 1).Magnitude(), Math.Sqrt(3));
            AssertDouble.AreEqual(new Vector3(1, 2, 2).Magnitude(), 3);
            AssertDouble.AreEqual(new Vector3(1, 4, 8).Magnitude(), 9);
        }

        [TestMethod]
        public void Vector2MagnitudeSquaredOfTrianglesTest()
        {
            AssertDouble.AreEqual(new Vector2(1, 1).MagnitudeSquared(), 2);
            AssertDouble.AreEqual(new Vector2(3, 4).MagnitudeSquared(), 25);
        }

        [TestMethod]
        public void Vector3MagnitudeSquaredOfTrianglesTest()
        {
            AssertDouble.AreEqual(new Vector3(1, 1, 1).MagnitudeSquared(), 3);
            AssertDouble.AreEqual(new Vector3(1, 2, 2).MagnitudeSquared(), 9);
            AssertDouble.AreEqual(new Vector3(1, 4, 8).MagnitudeSquared(), 81);
        }
    }
}
