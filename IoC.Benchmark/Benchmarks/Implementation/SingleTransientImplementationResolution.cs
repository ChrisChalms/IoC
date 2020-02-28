using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Implementation
{
    // Resolves a transient dependency once, container is empty
    class SingleTransientImplementationResolution : BenchmarkBase
    {
        public SingleTransientImplementationResolution()
        {
            _container.Register<IA>(typeof(A), false);
        }

        protected override void action()
        {
            var temp = _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Single Transient Implementation Resolution".PadRight(_nameLength, '-');
        }
    }
}
