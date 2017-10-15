using System.Numerics;

namespace KelsonBall.Geometry.Solids.Primitives
{
    public interface ITetrahedron
    {
        Vector2 BaseA { get; }
        Vector2 BaseB { get; }
        Vector2 BaseC { get; }
        Vector2 Top { get; }
    }

}
