using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    internal class FactoryFunctionRegistry<T> : IDependencyDescription
    {
        public Func<T> _factory;
        
        // Initialize
        public FactoryFunctionRegistry(Func<T> createFunction)
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
