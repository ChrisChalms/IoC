using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    internal class FactoryFunction<T> : IDependencyDescription
    {
        public Func<T> _factory;
        
        // Initialize
        public FactoryFunction(Func<T> createFunction)
        {
            _factory = createFunction;
        }

        // Instantiate and return dependency
        public object GetObject()
        {
            return _factory();
        }
    }
}
