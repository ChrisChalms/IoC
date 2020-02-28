using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Resolves a singleton dependency multple times, container is empty
    class SingleSingletonFunctionMultiResolution : BenchmarkBase
    {
        private int _timesToResolve;

        public SingleSingletonFunctionMultiResolution()
        {
            _timesToResolve = 100;
            _container.Register<IA>(() => new A(), true);
        }

        protected override void action()
        {
            for (var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Single Singleton Factory Function Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
