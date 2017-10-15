using KelsonBall.Geometry.Solids;
using KelsonBall.Geometry.Solids.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KelsonBall.Geometry.Surfaces.Primitives
{
    public class BoxSurface : Surface, IBox
    {
        public Vector3 Dimensions { get; private set; }

        private readonly Surface pX;
        private readonly Surface mX;
        private readonly Surface pY;
        private readonly Surface mY;
        private readonly Surface pZ;
        private readonly Surface mZ;

        public override ISurfaceVertexAlgorithm VertexAlgorithm
        {
            get => _vertexAlgorithm ?? (_vertexAlgorithm = new BasicCubeAlgorithm());
            set
            {
                _vertexAlgorithm = value;
                vertexCache = null;
                triangleCache = null;
            }
        }

        public BoxSurface(Vector3 dimensions)
        {
            Dimensions = dimensions;
            var sizeyz = new Vector2(dimensions.Y, dimensions.Z);
            var sizexz = new Vector2(dimensions.X, dimensions.Z);
            var sizexy = new Vector2(dimensions.X, dimensions.Y);

            //pX = new PlaneSurface(new Shape())
        }

        public override IEnumerable<Vector3> Intersections(Ray<Vector3> ray)
        {
            throw new NotImplementedException();
        }

        public override Vector3[] VertexArray()
        {
            return vertexCache ?? (vertexCache = VertexAlgorithm.GenerateVertecies().Select(v => v * Dimensions).ToArray());
        }

        public override int[] Triangles()
        {
            if (triangleCache != null)
                return triangleCache;
            return (triangleCache = VertexAlgorithm.Triangles().ToArray());
        }

        public class BasicCubeAlgorithm : ISurfaceVertexAlgorithm
        {
            public IEnumerable<Vector3> GenerateVertecies()
            {
                yield return new Vector3(-1,-1,-1);
                yield return new Vector3(-1,-1, 1);
                yield return new Vector3(-1, 1, 1);
                yield return new Vector3(-1, 1,-1);
                yield return new Vector3( 1,-1,-1);
                yield return new Vector3( 1,-1, 1);
                yield return new Vector3( 1, 1, 1);
                yield return new Vector3( 1, 1,-1);
            }

            internal static readonly List<int[]> surfaces = new List<int[]>
            {
                new int[]{ 0, 1, 2, 3 },
                new int[]{ 0, 4, 7, 3 },
                new int[]{ 0, 4, 5, 1 },
                new int[]{ 6, 2, 1, 5 },
                new int[]{ 6, 2, 3, 7 },
                new int[]{ 6, 7, 4, 5 }
            };

            public IEnumerable<int> Triangles()
            {
                foreach (var quad in surfaces)
                    foreach (var triangleVertex in VertexHelpers.TrianglesFromQuad(quad[0], quad[1], quad[2], quad[3]))
                        yield return triangleVertex;
            }
        }

        public class GridCubeAlgorithm : ISurfaceVertexAlgorithm
        {
            public readonly int Subdivisions;
            private readonly double quadScale;
            private readonly int sideLength;

            private readonly BasicCubeAlgorithm source = new BasicCubeAlgorithm();
            private readonly List<Vector3[]> faces = new List<Vector3[]>();
            private readonly Vector3[] corners;

            public GridCubeAlgorithm(int subdivisions)
            {
                Subdivisions = subdivisions;
                sideLength = 1 << subdivisions;
                quadScale = 1 / (double)sideLength;
                corners = source.GenerateVertecies().ToArray();
                foreach (var quad in BasicCubeAlgorithm.surfaces)
                    faces.Add(new Vector3[] { corners[quad[0]], corners[quad[1]], corners[quad[2]], corners[quad[3]] });
            }

            public IEnumerable<Vector3> GenerateVertecies()
            {
                foreach (var face in faces)
                {
                    var rowDir = face[1] - face[0];
                    var columnDir = face[3] - face[0];
                    var origin = face[0];
                    for (int x = 0; x < sideLength; x++)
                    {
                        for (int y = 0; y < sideLength; y++)
                        {
                            yield return origin;
                            yield return origin + rowDir;
                            yield return origin + rowDir + columnDir;
                            yield return origin + columnDir;
                            origin = origin + columnDir;
                        }
                        origin = origin + rowDir;
                    }
                }
            }

            public IEnumerable<int> Triangles()
            {
                int index = 0;
                foreach (var face in faces)
                {
                    for (int x = 0; x < sideLength; x++)
                    {
                        for (int y = 0; y < sideLength; y++)
                        {
                            foreach (var triangleVertex in VertexHelpers.TrianglesFromQuad(index, index + 1, index + 2, index + 3))
                                yield return triangleVertex;
                            index += 4;
                        }
                    }
                }
            }
        }
    }
}
