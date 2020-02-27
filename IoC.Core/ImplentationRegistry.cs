using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace IoC.Core
{
    class ImplentationRegistry : IDependencyDescription
    {
        private ConstructorInfo _constructorInfo;

        public ImplentationRegistry(Type type)
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
        }

        public object GetObject()
        {
            return _constructorInfo.Invoke(null);
        }
    }
}
