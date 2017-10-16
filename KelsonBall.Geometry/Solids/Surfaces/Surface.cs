using KelsonBall.Geometry.Solids;
using KelsonBall.Transforms;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KelsonBall.Geometry.Surfaces
{
    public abstract class Surface : IBorder<Vector3>
    {

        public virtual Surface Transform(Transform<Vector3> transformation)
        {
            var tSurface = new TransformSurface(this);

            return tSurface;
        }

        public abstract IEnumerable<Vector3> Intersections(Ray<Vector3> ray);

        protected ISurfaceVertexAlgorithm _vertexAlgorithm;
        public abstract ISurfaceVertexAlgorithm VertexAlgorithm { get; set; }

        protected Vector3[] vertexCache;
        public abstract Vector3[] VertexArray();

        protected int[] triangleCache;
        public virtual int[] Triangles()
        {
            if (triangleCache != null)
                return triangleCache;
            return (triangleCache = VertexAlgorithm.Triangles().ToArray());
        }
    }
}
