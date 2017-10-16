using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace KelsonBall.Vectors.Tests
{
    [TestClass]
    public class DotProductTests
    {
        public static readonly Vector2[] cases2 = new Vector2[]
        {
            new Vector2( 0, 0),
            new Vector2( 0, 1),
            new Vector2( 1, 0),
            new Vector2( 0,-1),
            new Vector2(-1, 0),
            new Vector2( 2, 3),
            new Vector2( (float)Math.E, (float)Math.PI ),
        };

        public static int offset2(int index, int offset) => (index + offset) % cases2.Length;

        [TestMethod]
        public void Vector2CommutativePropertyTest()
        {
            for (int i = 0; i < cases2.Length; i++)
            {
                var a = cases2[i];
                var b = cases2[offset2(i, 1)];

                AssertDouble.AreEqual(a.Dot(b), b.Dot(a));
            }
                
        }

        [TestMethod]
        public void Vector2DistributivePropertyTest()
        {
            for (int i = 0; i < cases2.Length; i++)
            {
                var a = cases2[i];
                var b = cases2[offset2(i, 1)];
                var c = cases2[offset2(i, 2)];
                AssertDouble.AreEqual(a.Dot(b + c), a.Dot(b) + a.Dot(c));
            }
        }

        [TestMethod]
        public void Vector2BilinearPropertyTest()
        {
            for (int i = 0; i < cases2.Length; i++)
            {
                var a = cases2[i];
                var b = cases2[offset2(i, 1)];
                var c = cases2[offset2(i, 2)];
                float r = (float)Math.E;
                AssertDouble.AreEqual(a.Dot(r * b + c), r * a.Dot(b) + a.Dot(c), 1e-5);
            }
        }

        [TestMethod]
        public void Vector2OrthogonalPropertyTest()
        {
            AssertDouble.AreEqual(new Vector2(0, 1).Dot(new Vector2(1, 0)), 0);
        }

        public static readonly Vector3[] cases3 = new Vector3[]
        {
            new Vector3( 0, 0, 0),
            new Vector3( 0, 0, 1),
            new Vector3( 0, 1, 0),
            new Vector3( 1, 0, 0),
            new Vector3( 0, 0,-1),
            new Vector3( 0,-1, 0),
            new Vector3(-1, 0, 0),
            new Vector3( 2, 3, 4),
            new Vector3( (float)Math.E, (float)Math.PI, (float)Math.Sqrt(2) ),
        };

        public static int offset3(int index, int offset) => (index + offset) % cases3.Length;

        [TestMethod]
        public void Vector3CommutativePropertyTest()
        {
            for (int i = 0; i < cases3.Length; i++)
            {
                var a = cases3[i];
                var b = cases3[offset3(i, 1)];

                AssertDouble.AreEqual(a.Dot(b), b.Dot(a));
            }

        }

        [TestMethod]
        public void Vector3DistributivePropertyTest()
        {
            for (int i = 0; i < cases3.Length; i++)
            {
                var a = cases3[i];
                var b = cases3[offset3(i, 1)];
                var c = cases3[offset3(i, 3)];
                AssertDouble.AreEqual(a.Dot(b + c), a.Dot(b) + a.Dot(c), 1e-5);
            }
        }

        [TestMethod]
        public void Vector3BilinearPropertyTest()
        {
            for (int i = 0; i < cases3.Length; i++)
            {
                var a = cases3[i];
                var b = cases3[offset3(i, 1)];
                var c = cases3[offset3(i, 3)];
                float r = (float)Math.E;
                AssertDouble.AreEqual(a.Dot(r * b + c), r * a.Dot(b) + a.Dot(c), 1e-5);
            }
        }

        [TestMethod]
        public void Vector3OrthogonalPropertyTest()
        {
            AssertDouble.AreEqual(new Vector3(0, 1, 0).Dot(new Vector3(1, 0, 0)), 0);
        }
    }
}
