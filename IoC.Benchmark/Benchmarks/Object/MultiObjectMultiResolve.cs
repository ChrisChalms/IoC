using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Object
{
    // Resolves a dependency multple times, container contains object registered dependencies
    class MultiObjectMultiResolve : BenchmarkBase
    {
        private int _timesToResolve;

        public MultiObjectMultiResolve()
        {
            _timesToResolve = 100;

            _container.Register<IA>(new A());
            _container.Register<IB>(new B());
            _container.Register<IC>(new C());
            _container.Register<ID>(new D());
            _container.Register<IE>(new E());
            _container.Register<IF>(new F());
            _container.Register<IG>(new G());
            _container.Register<IH>(new H());
            _container.Register<II>(new I());
            _container.Register<IJ>(new J());
            _container.Register<IK>(new K());
            _container.Register<IL>(new L());
            _container.Register<IM>(new M());
            _container.Register<IN>(new N());
            _container.Register<IO>(new O());
            _container.Register<IP>(new P());
            _container.Register<IQ>(new Q());
            _container.Register<IR>(new R());
            _container.Register<IS>(new S());
            _container.Register<IT>(new T());
            _container.Register<IU>(new U());
            _container.Register<IV>(new V());
            _container.Register<IW>(new W());
            _container.Register<IX>(new X());
            _container.Register<IY>(new Y());
            _container.Register<IZ>(new Z());
        }

        protected override void action()
        {
            for (var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Multi Object Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
