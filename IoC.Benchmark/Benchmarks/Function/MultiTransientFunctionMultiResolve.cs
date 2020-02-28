using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Resolves a transient dependency multple times, container contains transient factory function registered dependencies
    class MultiTransientFunctionMultiResolve : BenchmarkBase
    {
        private int _timesToResolve;

        public MultiTransientFunctionMultiResolve()
        {
            _timesToResolve = 100;
            _container.Register<IA>(() => new A(), false);
            _container.Register<IB>(() => new B(), false);
            _container.Register<IC>(() => new C(), false);
            _container.Register<ID>(() => new D(), false);
            _container.Register<IE>(() => new E(), false);
            _container.Register<IF>(() => new F(), false);
            _container.Register<IG>(() => new G(), false);
            _container.Register<IH>(() => new H(), false);
            _container.Register<II>(() => new I(), false);
            _container.Register<IJ>(() => new J(), false);
            _container.Register<IK>(() => new K(), false);
            _container.Register<IL>(() => new L(), false);
            _container.Register<IM>(() => new M(), false);
            _container.Register<IN>(() => new N(), false);
            _container.Register<IO>(() => new O(), false);
            _container.Register<IP>(() => new P(), false);
            _container.Register<IQ>(() => new Q(), false);
            _container.Register<IR>(() => new R(), false);
            _container.Register<IS>(() => new S(), false);
            _container.Register<IT>(() => new T(), false);
            _container.Register<IU>(() => new U(), false);
            _container.Register<IV>(() => new V(), false);
            _container.Register<IW>(() => new W(), false);
            _container.Register<IX>(() => new X(), false);
            _container.Register<IY>(() => new Y(), false);
            _container.Register<IZ>(() => new Z(), false);
        }

        protected override void action()
        {
            for (var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Multi Transient Factory Function Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
