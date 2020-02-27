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
        /// <code>Container.Register&lt;interface&gt;(() => new implementation())</code>
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="factory">Function to call on resolution</param>
        public void Register<T>(Func<T> factory)
        {
            if (factory == null)
                throw new Exception("No function passed");
            
            var typeOf = typeOf<T>();
            if (IsRegistered(typeOf))
                throw new Exception("Dependency already registered");
            
            _dependencies[typeOf] = new FactoryFunctionRegistry<T>(factory);
        }

        /// <summary>
        /// Register an implementation type for the supplied interface
        /// <code>Container.Register&lt;interface&gt;(implementation)</code>
        /// </summary>
        /// <remarks>Uses reflection</remarks>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="implementation">Implementation Type</param>
        public void Register<T>(Type implementation)
        {
            if (implementation == null)
                throw new Exception("Passed implementation cannot be null");
            var typeOf = typeOf<T>();
            if (IsRegistered(typeOf))
                throw new Exception("Dependency already registered");

            _dependencies[typeOf] = new ImplentationRegistry(implementation);
        }

        #endregion

        #region Retrieval

        /// <summary>
        /// Returns the object registered to a given type if registered
        /// <code>Container.Resolve&lt;interface&gt;()</code>
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <returns>Implementation of interface</returns>
        public T Resolve<T>()
        {
            var typeOf = typeOf<T>();
            if (!IsRegistered(typeOf))
                throw new Exception($"No dependency of type {typeOf} registered");

            return (T)_dependencies[typeof(T)].GetObject();
        }

        #endregion

        #region Helpers

        // Does the dependency dictionary contain the key?
        public bool IsRegistered(Type key) => _dependencies.ContainsKey(key);

        // Return the typeOf of the passed generic
        private Type typeOf<T>() => typeof(T);

        #endregion
    }
}
