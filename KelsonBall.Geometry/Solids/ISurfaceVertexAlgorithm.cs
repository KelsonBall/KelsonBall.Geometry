using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Solids
{
    public interface ISurfaceVertexAlgorithm
    {
        IEnumerable<Vector3> GenerateVertecies();

        IEnumerable<int> Triangles();
    }
}
