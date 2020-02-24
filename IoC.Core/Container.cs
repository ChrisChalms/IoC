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

        #region Registry

        // Register a new dependency with a create function to avoid reflection
        public void Register<T>(Func<T> createFunction)
        {
            if (createFunction == null)
                throw new Exception("No createfunction passed");
            var typeOf = typeof(T);

            if (containsKey(typeOf))
                throw new Exception("Dependency already registered");
            
            _dependencies[typeOf] = new DependencyDescription<T>(createFunction);

            Console.WriteLine("Registered {0}, Dict count now {1}", typeof(T), _dependencies.Count);
        }

        #endregion

        #region Resolution

        // Return the concrete implementation if present
        public T Resolve<T>()
        {
            if (!containsKey(typeof(T)))
                throw new Exception($"No dependency of type {typeof(T)} registered");

            return (_dependencies[typeof(T)] as DependencyDescription<T>).GetObject();
        }

        #endregion

        #region Helpers

        // Returns whether the dependecy is registered or not
        private bool containsKey(Type key)
        {
            return _dependencies.ContainsKey(key);
        }

        #endregion
    }
}
