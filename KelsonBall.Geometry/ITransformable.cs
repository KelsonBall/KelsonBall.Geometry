using System;
using System.Collections.Generic;
using System.Text;

namespace KelsonBall.Geometry
{
    interface ITransformable<TType, TVector>
    {
        TType Transform(Transform<TVector> transform);
    }
}
