using System.Collections.Generic;

namespace KelsonBall.Geometry
{
    public static class VertexHelpers
    {
        public static IEnumerable<int> TrianglesFromQuad(int a, int b, int c, int d)
        {
            yield return a;
            yield return b;
            yield return c;
            yield return c;
            yield return d;
            yield return a;
        }
    }
}
