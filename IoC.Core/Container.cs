using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    public class Container
    {
        private Dictionary<Type, IDependencyDescription> _dependencies;

        // Initialize
        public Container()
        {
            _dependencies = new Dictionary<Type, IDependencyDescription>();
        }

        #region Registration

        /// <summary>
        /// Register an factory function to be called on resolution
        /// <code>Container.Register(() => new implementation())</code>
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="factory">Function to call on resolution</param>
        public void Register<T>(Func<T> factory)
        {
            if (factory == null)
                throw new Exception("No function passed");
            var typeOf = typeof(T);

            if (IsRegistered(typeOf))
                throw new Exception("Dependency already registered");
            
            _dependencies[typeOf] = new FactoryFunction<T>(factory);
        }

        // Register an existing object
        public void Register<T>(object implementation)
        {
            if (implementation == null)
                throw new Exception("Passed implementation cannot be null");
            if (IsRegistered(typeof(T)))
                throw new Exception("Dependency already registered");

        }

        #endregion

        #region Retrieval

        // Return the concrete implementation if present
        public T Resolve<T>()
        {
            if (!IsRegistered(typeof(T)))
                throw new Exception($"No dependency of type {typeof(T)} registered");

            return (T)_dependencies[typeof(T)].GetObject();
        }

        #endregion

        #region Helpers

        // Does the dependency dictionary contain the key?
        public bool IsRegistered(Type key) => _dependencies.ContainsKey(key);

        #endregion
    }
}
