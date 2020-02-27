using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace IoC.Core
{
    /// <summary>
    /// Represents an implementation registration object
    /// </summary>
    internal class ImplentationRegistry : IDependencyRegistration
    {
        private ConstructorInfo _constructorInfo;
        private object _cachedObject;

        public bool Singleton { get; private set; }

        // Initialize
        public ImplentationRegistry(Type type, bool singleton)
        {
            // Get constructor
            var constructors = type.GetConstructors();

            if (constructors.Length == 0)
                throw new Exception($"No public constructors found for type {type}");

            // TODO: Search for an internal constructor

            var constructor = constructors.First();

            if (constructor.GetParameters().Length > 0)
                throw new Exception("Parameters are not supported");

            // TODO: Support parameters

            _constructorInfo = constructor;

            // Create immediately if the dependency is a singleton
            Singleton = singleton;
            if (Singleton)
                _cachedObject = _constructorInfo.Invoke(null);
        }

        // Return the cached object if this is a singleton, otherwise return a new object
        public object GetObject()
        {
            return Singleton ? _cachedObject : _constructorInfo.Invoke(null);
        }

        // Returns the scope of this object
        public Container.RegistrationScope GetRegistrationScope()
        {
            return Singleton ? Container.RegistrationScope.SINGLETON : Container.RegistrationScope.TRANSIENT;
        }
    }
}
