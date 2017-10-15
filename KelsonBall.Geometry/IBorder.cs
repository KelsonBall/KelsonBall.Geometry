using System.Collections.Generic;

namespace KelsonBall.Geometry
{
    public interface IBorder<TVector>
    {
        IEnumerable<TVector> Intersections(Ray<TVector> ray);

        TVector[] VertexArray();
    }
}
