using System.Collections.Generic;
using System.Numerics;

namespace KelsonBall.Geometry.Areas
{
    public class CompositeArea : Area
    {
        public readonly Area Root;
        private readonly List<(Operator op, Area volume)> Operations = new List<(Operator op, Area volume)>();

        internal CompositeArea(Area root)
        {
            Root = root;
        }

        public override Area And(Area region)
        {
            Operations.Add((Operator.And, region));
            return this;
        }

        public override Area Not(Area region)
        {
            Operations.Add((Operator.Not, region));
            return this;
        }

        public override Area Or(Area region)
        {
            Operations.Add((Operator.Or, region));
            return this;
        }

        public override Area XOr(Area region)
        {
            Operations.Add((Operator.XOr, region));
            return this;
        }

        public override bool Contains(Vector2 point)
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
