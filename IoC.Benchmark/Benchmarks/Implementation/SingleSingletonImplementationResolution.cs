using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Implementation
{
    // Resolves a singleton dependency once, container is empty
    class SingleSingletonImplementationResolution : BenchmarkBase
    {
        public SingleSingletonImplementationResolution()
        {
            _container.Register<IA>(typeof(A), true);
        }

        protected override void action()
        {
            var temp = _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Single Singleton Implementation Resolution".PadRight(_nameLength, '-');
        }
    }
}
