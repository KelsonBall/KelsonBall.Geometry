using System.Numerics;

namespace KelsonBall.Geometry.Volumes
{
    public abstract class Volume
    {
        public abstract bool Contains(Vector3 point);

        public virtual Volume Transform(Transform3 transformation)
        {
            var volume = new TransformVolume(this);
            volume.Transform(transformation);
            return volume;
        }
    }
}
