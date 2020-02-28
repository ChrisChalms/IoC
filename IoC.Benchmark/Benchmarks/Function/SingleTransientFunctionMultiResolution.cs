using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Resolves a transient dependency multple times, container is empty
    class SingleTransientFunctionMultiResolution : BenchmarkBase
    {
        private int _timesToResolve;

        public SingleTransientFunctionMultiResolution()
        {
            _timesToResolve = 100;
            _container.Register<IA>(() => new A(), false);
        }

        protected override void action()
        {
            for (var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Single Transient Factory Function Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
