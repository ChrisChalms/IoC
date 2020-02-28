using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Implementation
{
    // Resolves a transient dependency multple times, container contains transient implementation registered dependencies
    class MultiTransientImplementationMultiResolve : BenchmarkBase
    {
        private int _timesToResolve;

        public MultiTransientImplementationMultiResolve()
        {
            _timesToResolve = 100;
            _container.Register<IA>(typeof(A), false);
            _container.Register<IB>(typeof(B), false);
            _container.Register<IC>(typeof(C), false);
            _container.Register<ID>(typeof(D), false);
            _container.Register<IE>(typeof(E), false);
            _container.Register<IF>(typeof(F), false);
            _container.Register<IG>(typeof(G), false);
            _container.Register<IH>(typeof(H), false);
            _container.Register<II>(typeof(I), false);
            _container.Register<IJ>(typeof(J), false);
            _container.Register<IK>(typeof(K), false);
            _container.Register<IL>(typeof(L), false);
            _container.Register<IM>(typeof(M), false);
            _container.Register<IN>(typeof(N), false);
            _container.Register<IO>(typeof(O), false);
            _container.Register<IP>(typeof(P), false);
            _container.Register<IQ>(typeof(Q), false);
            _container.Register<IR>(typeof(R), false);
            _container.Register<IS>(typeof(S), false);
            _container.Register<IT>(typeof(T), false);
            _container.Register<IU>(typeof(U), false);
            _container.Register<IV>(typeof(V), false);
            _container.Register<IW>(typeof(W), false);
            _container.Register<IX>(typeof(X), false);
            _container.Register<IY>(typeof(Y), false);
            _container.Register<IZ>(typeof(Z), false);
        }

        protected override void action()
        {
            for (var i = 0; i < _timesToResolve; i++)
                _container.Resolve<IA>();
        }

        // Prettier name of this action
        public override string ToString()
        {
            return $"Multi Transient Implementation Multi Resolution ({_timesToResolve}x)".PadRight(_nameLength, '-');
        }
    }
}
