using System;

namespace IoC.Core
{
    /// <summary>
    /// Represents a factory function registration object
    /// </summary>
    internal class FactoryFunctionRegistry<T> : IDependencyRegistration
    {
        private Func<T> _factory;
        private object _cachedObject;

        public bool Singleton { get; private set; }

        // Initialize
        public FactoryFunctionRegistry(Func<T> createFunction, bool singleton)
        {
            _factory = createFunction;
            Singleton = singleton;

            // Create immediately if the dependency is a singleton
            if (Singleton)
                _cachedObject = _factory();
        }

        // Return the cached object if this is a singleton, otherwise return a new object
        public object GetObject()
        {
            return Singleton ? _cachedObject : _factory();
        }

        // Returns the scope of this object
        public Container.RegistrationScope GetRegistrationScope()
        {
            return Singleton ? Container.RegistrationScope.SINGLETON : Container.RegistrationScope.TRANSIENT;
        }
    }
}
