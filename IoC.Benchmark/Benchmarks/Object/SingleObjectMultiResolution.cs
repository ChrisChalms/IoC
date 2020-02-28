using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Object
{
    // Resolves a dependency multple times, container is empty
    class SingleObjectMultiResolution : BenchmarkBase
    {
        private int _timesToResolve;

        public SingleObjectMultiResolution()
        {
            _timesToResolve = 100;
            _container.Register<IA>(new A());
        }

        protected override void action()
        {
            for(var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Single Object Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
