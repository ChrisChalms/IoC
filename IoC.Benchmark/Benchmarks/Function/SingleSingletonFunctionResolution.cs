using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Resolves a singleton dependency once, container is empty
    class SingleSingletonFunctionResolution : BenchmarkBase
    {
        public SingleSingletonFunctionResolution()
        {
            _container.Register<IA>(() => new A(), true);
        }

        protected override void action()
        {
            _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Single Singleton Factory Function Resolution".PadRight(_nameLength, '-');
        }
    }
}
