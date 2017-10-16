using System;
using System.Numerics;
using KelsonBall.Vectors;
using System.Collections.Generic;
using KelsonBall.Geometry.Solids;
using System.Linq;
using static KelsonBall.Geometry.Surfaces.Primitives.BoxSurface;
using static System.Math;

namespace KelsonBall.Geometry.Surfaces.Primitives
{
    public class SphereSurface : Surface
    {
        const double fudge = 1e-5;
        private readonly double r2;
        private readonly double radius;

        public double Radius => radius;

        public override ISurfaceVertexAlgorithm VertexAlgorithm
        {
            get => _vertexAlgorithm ?? (_vertexAlgorithm = new SpherifiedCubeAlgorithm(4));
            set
            {
                _vertexAlgorithm = value;
                vertexCache = null;
                triangleCache = null;
            }
        }

        public SphereSurface(double radius)
        {
            this.radius = radius;
            this.r2 = radius * radius;
        }


        public override IEnumerable<Vector3> Intersections(Ray<Vector3> ray)
        {
            var o = ray.Origin;
            var d = ray.Direction;
            var L = -o;
            if (L.Dot(d) < 0)
                yield break;

            var projection = L.Projection(d);

            var centerDistance = (L - projection).Magnitude();
            var halfChord = (float)(Math.Sqrt(r2 + centerDistance * centerDistance) - fudge);

            yield return projection - d * halfChord;
            yield return projection + d * halfChord;
        }

        public override Vector3[] VertexArray()
        {
            return vertexCache ?? (vertexCache = VertexAlgorithm.GenerateVertecies().Select(v => v.Scale(Radius)).ToArray());
        }

        // http://mathproofs.blogspot.co.uk/2005/07/mapping-cube-to-sphere.html
        public class SpherifiedCubeAlgorithm : ISurfaceVertexAlgorithm
        {
            private readonly ISurfaceVertexAlgorithm source;
            private readonly int Subdivisions;

            public SpherifiedCubeAlgorithm(int subdivisions)
            {
                Subdivisions = subdivisions;
                source = new GridCubeAlgorithm(subdivisions);
            }

            public IEnumerable<Vector3> GenerateVertecies()
            {
                foreach (var v in source.GenerateVertecies())
                {
                    double x = v.X;
                    double x2 = x * x;
                    double y = v.Y;
                    double y2 = y * y;
                    double z = v.Z;
                    double z2 = z * z;
                    yield return new Vector3(
                        (float)(x * Sqrt(1 - y2 / 2 - z2 / 2 + y2 * z2 / 3)),
                        (float)(y * Sqrt(1 - z2 / 2 - x2 / 2 + z2 * x2 / 3)),
                        (float)(z * Sqrt(1 - x2 / 2 - y2 / 2 + x2 * y2 / 3)) );
                }
            }

            public IEnumerable<int> Triangles()
            {
                return source.Triangles();
            }
        }
    }
}
