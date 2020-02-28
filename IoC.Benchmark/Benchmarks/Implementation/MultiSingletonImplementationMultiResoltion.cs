using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Implementation
{
    // Resolves a singleton dependency multple times, container contains singleton implentation registered dependencies
    class MultiSingletonImplementationMultiResoltion : BenchmarkBase
    {
        private int _timesToResolve;

        public MultiSingletonImplementationMultiResoltion()
        {
            _timesToResolve = 100;
            _container.Register<IA>(typeof(A), true);
            _container.Register<IB>(typeof(B), true);
            _container.Register<IC>(typeof(C), true);
            _container.Register<ID>(typeof(D), true);
            _container.Register<IE>(typeof(E), true);
            _container.Register<IF>(typeof(F), true);
            _container.Register<IG>(typeof(G), true);
            _container.Register<IH>(typeof(H), true);
            _container.Register<II>(typeof(I), true);
            _container.Register<IJ>(typeof(J), true);
            _container.Register<IK>(typeof(K), true);
            _container.Register<IL>(typeof(L), true);
            _container.Register<IM>(typeof(M), true);
            _container.Register<IN>(typeof(N), true);
            _container.Register<IO>(typeof(O), true);
            _container.Register<IP>(typeof(P), true);
            _container.Register<IQ>(typeof(Q), true);
            _container.Register<IR>(typeof(R), true);
            _container.Register<IS>(typeof(S), true);
            _container.Register<IT>(typeof(T), true);
            _container.Register<IU>(typeof(U), true);
            _container.Register<IV>(typeof(V), true);
            _container.Register<IW>(typeof(W), true);
            _container.Register<IX>(typeof(X), true);
            _container.Register<IY>(typeof(Y), true);
            _container.Register<IZ>(typeof(Z), true);
        }

        protected override void action()
        {
            for(var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Multi Singleton Implementation Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
