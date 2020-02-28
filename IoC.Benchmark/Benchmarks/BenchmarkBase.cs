using System.Diagnostics;
using IoC.Core;

namespace IoC.Benchmark.Benchmarks
{
    internal abstract class BenchmarkBase
    {
        protected int _nameLength;
        protected Container _container;
        private Stopwatch _stopWatch;

        // Initialize
        public BenchmarkBase()
        {
            _nameLength = 70;
            _container = new Container();
        }

        // Start timer, perform the action, then print results
        public virtual string StartBenchmark()
        {
            _stopWatch = Stopwatch.StartNew();

            action();

            _stopWatch.Stop();

            return string.Format("{0} ms ({1} ticks)", _stopWatch.ElapsedMilliseconds, _stopWatch.ElapsedTicks);
        }

        // The action being testing
        protected virtual void action() { }
    }
}
