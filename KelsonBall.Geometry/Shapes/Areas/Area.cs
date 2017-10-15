using System;
using System.Numerics;

namespace KelsonBall.Geometry.Areas
{
    public abstract class Area : IRegion<Vector2>, IComposable<Area> ITransformable<Area, Vector2>
    {
        public abstract bool Contains(Vector2 point);

        public virtual Area And(Area region)
        {
            return new CompositeArea(this).And(region);
        }

        public virtual Area Not(Area region)
        {
            return new CompositeArea(this).Not(region);
        }

        public virtual Area Or(Area region)
        {
            return new CompositeArea(this).Or(region);
        }

        public virtual Area XOr(Area region)
        {
            return new CompositeArea(this).XOr(region);
        }

        public virtual Area Transform(Transform<Vector2> transform)
        {
            var area = new TransformArea(this);
            area.Transform(transform);
            return area;
        }

    }
}
