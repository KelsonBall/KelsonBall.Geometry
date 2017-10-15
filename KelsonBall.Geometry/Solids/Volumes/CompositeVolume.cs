using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Volumes
{
    public class CompositeVolume : Volume
    {
        public readonly Volume Root;
        private readonly List<(Operator op, Volume volume)> Operations = new List<(Operator op, Volume volume)>();

        internal CompositeVolume(Volume root)
        {
            Root = root;
        }

        public override Volume And(Volume volume)
        {
            Operations.Add((Operator.And, volume));
            return this;
        }

        public override Volume Not(Volume volume)
        {
            Operations.Add((Operator.Not, volume));
            return this;
        }

        public override Volume Or(Volume volume)
        {
            Operations.Add((Operator.Or, volume));
            return this;
        }

        public override Volume XOr(Volume volume)
        {
            Operations.Add((Operator.XOr, volume));
            return this;
        }

        public override bool Contains(Vector3 point)
        {
            bool result = Root.Contains(point);
            foreach (var operation in Operations)
            {
                bool op_result = operation.volume.Contains(point);
                switch (operation.op)
                {
                    case Operator.Or:
                        result = result || op_result;
                        break;
                    case Operator.And:
                        result = result && op_result;
                        break;
                    case Operator.Not:
                        result = !result;
                        break;
                    case Operator.XOr:
                        result = (result || op_result) && !(result && op_result);
                        break;
                }
            }

            return result;
        }
    }
}
