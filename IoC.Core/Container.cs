using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    public class Container
    {
        public enum DependencyScope{ SINGLETON, TRANSIENT }
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
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="implementation">Implementation type</param>
        /// <remarks>Uses reflection</remarks>
        public void Register<T>(Type implementation)
        {
            if (implementation == null)
                throw new Exception("Passed implementation cannot be null");
            var typeOf = typeOf<T>();
            if (IsRegistered(typeOf))
                throw new Exception("Dependency already registered");

            _dependencies[typeOf] = new ImplentationRegistry(implementation);
        }

        /// <summary>
        /// Register an existing implementation of an interface
        /// <code>Container.Register&lt;interface&gt;(new implementation())</code>
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="implementationObject">Implementation object</param>
        /// <remarks>Singleton only, does not support transient scope</remarks>
        public void Register<T>(object implementationObject)
        {
            if(implementationObject == null)
                throw new Exception("Passed implementation object cannot be null");
            var typeOf = typeOf<T>();
            if (IsRegistered(typeOf))
                throw new Exception("Dependency already registered");

            _dependencies[typeOf] = new ObjectRegistry(implementationObject);
        }

        #endregion

        #region Resolution

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

            return (T)_dependencies[typeOf].GetObject();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Return whether an implementation of the passed interface has been registered
        /// <code>Container.IsRegistered(typeOf(ITestService))</code>
        /// </summary>
        /// <param name="key">Interface to check</param>
        /// <returns>bool</returns>
        public bool IsRegistered(Type key) => _dependencies.ContainsKey(key);

        // Return the typeOf of the passed generic
        private Type typeOf<T>() => typeof(T);

        #endregion
    }
}
