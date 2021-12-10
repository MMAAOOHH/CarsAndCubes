namespace DefaultNamespace
{
    public interface IObservable
    {
        void Add(IObserver observer);
        void Notify();
    }
}