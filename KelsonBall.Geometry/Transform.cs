using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace KelsonBall.Geometry
{
    public abstract class Transform<T>
    {
        protected Matrix<double> transform;
        protected Matrix<double> inverse;

        public Matrix<double> Matrix
        {
            get => transform;
            internal set
            {
                inverse = null;
                transform = value;
            }
        }

        public Matrix<double> Inverse => inverse ?? (inverse = transform.Inverse());

        public abstract T ApplyTo(T vector);

        protected Transform(int dim)
        {
            transform = DenseMatrix.Create(dim, dim, 0);
            transform.SetDiagonal(Range(0, dim).Select(i => 1d).ToArray());
        }

        protected Transform(double[,] data)
        {
            transform = DenseMatrix.OfArray(data);
        }
    }

    public class TransformStack<T>
    {
        protected readonly Transform<T> aggregate;

        public Transform<T> Aggregate => aggregate;

        private readonly Stack<Transform<T>> stack;

        internal TransformStack(Transform<T> transform)
        {
            aggregate = transform;
        }

        public void Push(Transform<T> transform)
        {
            stack.Push(transform);
            aggregate.Matrix *= transform.Matrix;
        }

        public Transform<T> Pop()
        {
            var top = stack.Pop();
            aggregate.Matrix *= top.Inverse;
            return top;
        }

        public Transform<T> Peek() => stack.Peek();

        public static implicit operator Transform<T>(TransformStack<T> stack) => stack.aggregate;        
    }
}
