using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    /// <summary>
    /// Represents an object registration. No singleton option here, object already exists, then is registered
    /// </summary>
    internal class ObjectRegistry : IDependencyRegistration
    {
        private object _object;

        // Initialize
        public ObjectRegistry(object obj)
        {
            _object = obj;
        }

        // Return the cached object
        public object GetObject()
        {
            return _object;
        }

        // Returns the scope of this object
        public Container.RegistrationScope GetRegistrationScope()
        {
            return Container.RegistrationScope.SINGLETON;
        }
    }
}
