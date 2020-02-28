using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Object
{
    // Resolves a dependency once, container is empty
    class ObjectResolution : BenchmarkBase
    {
        public ObjectResolution()
        {
            _container.Register<IA>(new A());
        }

        protected override void action()
        {
            var temp = _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Single Object Resolution".PadRight(_nameLength, '-');
        }
    }
}
