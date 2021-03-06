﻿using IoC.Benchmark.Implementations;
using IoC.Benchmark.Interfaces;

namespace IoC.Benchmark.Benchmarks.Implementation
{
    // Resolves a singleton dependency once, container is empty
    class SingletonImplementationRegistry : BenchmarkBase
    {
        protected override void action()
        {
            _container.Register<IA>(typeof(A), true);
        }

        // Prettier name of this action
        public override string ToString()
        {
            return "Singleton Implementation Registry".PadRight(_nameLength, '-');
        }
    }
}
