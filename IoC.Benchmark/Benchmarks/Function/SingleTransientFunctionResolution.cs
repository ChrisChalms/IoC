using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Resolves a singleton dependency multple times, container is empty
    class SingleTransientFunctionResolution : BenchmarkBase
    {
        public SingleTransientFunctionResolution()
        {
            _container.Register<IA>(() => new A(), false);
        }

        protected override void action()
        {
            _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Single Transient Factory Function Resolution".PadRight(_nameLength, '-');
        }
    }
}
