using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Function
{
    // Resolves a singleton dependency multple times, container contains singleton factory function registered dependencies
    class MultiSingletonFunctionMultiResoltion : BenchmarkBase
    {
        private int _timesToResolve;

        public MultiSingletonFunctionMultiResoltion()
        {
            _timesToResolve = 100;
            _container.Register<IA>(() => new A(), true);
            _container.Register<IB>(() => new B(), true);
            _container.Register<IC>(() => new C(), true);
            _container.Register<ID>(() => new D(), true);
            _container.Register<IE>(() => new E(), true);
            _container.Register<IF>(() => new F(), true);
            _container.Register<IG>(() => new G(), true);
            _container.Register<IH>(() => new H(), true);
            _container.Register<II>(() => new I(), true);
            _container.Register<IJ>(() => new J(), true);
            _container.Register<IK>(() => new K(), true);
            _container.Register<IL>(() => new L(), true);
            _container.Register<IM>(() => new M(), true);
            _container.Register<IN>(() => new N(), true);
            _container.Register<IO>(() => new O(), true);
            _container.Register<IP>(() => new P(), true);
            _container.Register<IQ>(() => new Q(), true);
            _container.Register<IR>(() => new R(), true);
            _container.Register<IS>(() => new S(), true);
            _container.Register<IT>(() => new T(), true);
            _container.Register<IU>(() => new U(), true);
            _container.Register<IV>(() => new V(), true);
            _container.Register<IW>(() => new W(), true);
            _container.Register<IX>(() => new X(), true);
            _container.Register<IY>(() => new Y(), true);
            _container.Register<IZ>(() => new Z(), true);
        }

        protected override void action()
        {
            for(var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Multi Singleton Factory Function Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
