using KelsonBall.Geometry.Shapes.Primitives;
using System.Numerics;
using KelsonBall.Geometry.Areas;

namespace KelsonBall.Geometry.Shapes.Areas.Primitives
{
    public class RectangleArea : Area, IRectangle
    {
        public Vector2 Dimensions { get; private set; }

        public RectangleArea(Vector2 dimensions)
        {
            Dimensions = dimensions;
        }

        public override bool Contains(Vector2 point)
        {
            return (point.X >= -Dimensions.X && point.X <= Dimensions.X)
                && (point.Y >= -Dimensions.Y && point.Y <= Dimensions.Y);
        }
    }
}
