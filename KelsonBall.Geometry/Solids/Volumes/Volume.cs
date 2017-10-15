using System.Numerics;

namespace KelsonBall.Geometry.Volumes
{
    public abstract class Volume : IRegion<Vector3>, IComposable<Volume>, ITransformable<Volume, Vector3>
    {
        public abstract bool Contains(Vector3 point);

        public virtual Volume And(Volume volume)
        {
            return new CompositeVolume(this).And(volume);
        }

        public virtual Volume Not(Volume volume)
        {
            return new CompositeVolume(this).Not(volume);
        }

        public virtual Volume Or(Volume volume)
        {
            return new CompositeVolume(this).Or(volume);
        }

        public virtual Volume XOr(Volume volume)
        {
            return new CompositeVolume(this).XOr(volume);
        }

        public virtual Volume Transform(Transform<Vector3> transformation)
        {
            var volume = new TransformVolume(this);
            volume.Transform(transformation);
            return volume;
        }
    }
}
