using System.Numerics;

namespace KelsonBall.Geometry.Solids.Primitives
{
    public interface IPrism
    {
        Vector2 A { get; }
        Vector2 B { get; }
        Vector2 C { get; }

        double Length { get; }
    }
}
