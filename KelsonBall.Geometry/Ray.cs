using KelsonBall.VectorExtensions;
using System;
using System.Numerics;

namespace KelsonBall.Geometry
{
    public abstract class Ray<T>
    {
        public readonly T Origin;
        public readonly T Direction;

        protected Ray(T origin, T direction)
        {
            Origin = origin;            
            Direction = direction;
        }

        public abstract Ray<T> Transform(Transform<T> transform);
    }

    public class Ray2 : Ray<Vector2>
    {        

        public Ray2(Vector2 o, Vector2 d) : base(o, d.Unit()) { }        

        public override Ray<Vector2> Transform(Transform<Vector2> transform)
        {
            return new Ray2(transform.ApplyTo(Origin), transform.ApplyTo(Direction));
        }
    }

    public class Ray3 : Ray<Vector3>
    {
        public Ray3(Vector3 o, Vector3 d) : base(o, d.Unit()) { }

        public override Ray<Vector3> Transform(Transform<Vector3> transform)
        {
            return new Ray3(transform.ApplyTo(Origin), transform.ApplyTo(Direction));
        }
    }
}
