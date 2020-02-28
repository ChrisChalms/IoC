using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Object
{
    // Register a dependency once
    class ObjectRegistry : BenchmarkBase
    {
        protected override void action()
        {
            _container.Register<IA>(new A());
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Object Registry".PadRight(_nameLength, '-');
        }
    }
}
