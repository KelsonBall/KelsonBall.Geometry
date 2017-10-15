using KelsonBall.Geometry.Surfaces;
using KelsonBall.Geometry.Volumes;
using System.Numerics;
using System.Collections.Generic;

namespace KelsonBall.Geometry.Solids
{
    public abstract class Solid : IBorder<Vector3>, IRegion<Vector3>, IComposable<Solid>, ITransformable<Solid, Vector3>
    {
        public Surface Surface { get; private set; }
        public Volume Volume { get; private set; }

        protected Solid(Surface surface, Volume volume)
        {
            Surface = surface;
            Volume = volume;
        }

        public Solid And(Solid region)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Vector3 point)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vector3> Intersections(Ray<Vector3> ray)
        {
            throw new System.NotImplementedException();
        }

        public Solid Not(Solid region)
        {
            throw new System.NotImplementedException();
        }

        public Solid Or(Solid region)
        {
            throw new System.NotImplementedException();
        }

        public Solid Transform(Transform<Vector3> transform)
        {
            throw new System.NotImplementedException();
        }

        public Vector3[] VertexArray()
        {
            throw new System.NotImplementedException();
        }

        public Solid XOr(Solid region)
        {
            throw new System.NotImplementedException();
        }
    }
}
