using System.Numerics;

namespace KelsonBall.Geometry.Shapes.Primitives
{
    public interface IRectangle
    {
        Vector2 Dimensions { get; }
    }

    public class Rectangle : Shape, IRectangle
    {
        public Vector2 Dimensions { get; private set; }

        public Rectangle(Vector2 dimensions) : base(new RectangleArea(dimensions), new RectanglePerimeter(dimensions))
        {

        }
    }
}
