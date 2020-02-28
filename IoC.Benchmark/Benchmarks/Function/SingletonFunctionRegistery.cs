using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Register a singleton dependency once, container is empty
    class SingletonFunctionRegistery : BenchmarkBase
    {
        protected override void action()
        {
            _container.Register<IA>(() => new A(), true);
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Singleton Factory Function Registry".PadRight(_nameLength, '-');
        }
    }
}
