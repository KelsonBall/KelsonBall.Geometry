using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace KelsonBall.VectorExtensions.Tests
{
    [TestClass]
    public class ProjectionTests
    {
        [TestMethod]
        public void Vector2ProjectionOntoAxisTest()
        {
            var v = new Vector2(1, 1);
            var axis = new Vector2(1, 0);

            var result = v.Projection(axis);

            AssertVector2.AreEqual(result, axis);
        }

        [TestMethod]
        public void Vector3ProjectionOntoAxisTest()
        {
            var v = new Vector3(1, 2, 3);
            var axis = new Vector3(0, 1, 0);

            var result = v.Projection(axis);

            AssertVector3.AreEqual(result, axis.Scale(v.Y));
        }
    }
}
