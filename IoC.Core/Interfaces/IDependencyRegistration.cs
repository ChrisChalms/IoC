using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Core
{
    interface IDependencyRegistration
    {
        // All registered dependency should return an implementation, cached or transient 
        public object GetObject();
        public Container.RegistrationScope GetRegistrationScope();
    }
}
