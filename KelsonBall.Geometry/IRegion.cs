namespace KelsonBall.Geometry
{
    public interface IRegion<TVector>
    {
        bool Contains(TVector point);
    }

    public interface IComposable<TComposed>
    {
        TComposed  Or(TComposed region);
        TComposed Not(TComposed region);
        TComposed And(TComposed region);
        TComposed XOr(TComposed region);
    }
}
