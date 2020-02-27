using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    internal class ObjectRegistry : IDependencyDescription
    {
        private object _object;

        public ObjectRegistry(object obj)
        {
            _object = obj;
        }

        public object GetObject()
        {
            return _object;
        }
    }
}
