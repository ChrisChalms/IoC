using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Register a transient dependency once into an empty container
    class TransientFunctionRegistry : BenchmarkBase
    {
        protected override void action()
        {
            _container.Register<IA>(() => new A(), false);
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Transient Factory Function Registry".PadRight(_nameLength, '-');
        }
    }
}
