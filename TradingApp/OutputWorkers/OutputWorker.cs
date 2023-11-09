namespace TradingApp.OutputWorkers
{
    public abstract class OutputWorker<T>
    {
        public abstract IEnumerable<T> Reader(string path);
        public abstract void Writer(IEnumerable<T> data, string path);
        public abstract void Append(IEnumerable<T> data, string path);
    }
}
