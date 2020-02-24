using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    internal class DependencyDescription<T> : IDependencyDescription
    {
        public Func<T> _createFunc;
        
        // Initialize
        public DependencyDescription(Func<T> createFunction)
        {
            _createFunc = createFunction;
        }

        // Instantiate and return dependency
        public T GetObject()
        {
            return _createFunc();
        }
    }
}
