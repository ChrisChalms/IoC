using IoC.Core;
using IoC.Test.Classes;
using IoC.Test.Interfaces;
using System;

namespace IoC.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            // Registration

            // FactoryFunction
            container.Register<ITestService>(() => new GuiService(), false);
            
            // Implementation
            //container.Register<ITestService>(typeof(StringService), true);

            // Object
            //container.Register<ITestService>(new GuiService());

            // Resolution
            for(var i = 0; i < 10; i++)
                container.Resolve<ITestService>().PrintResult();

            // Registry check
            Console.WriteLine("Registered? {0}", container.IsRegistered(typeof(ITestService)));
            Console.WriteLine("Registered? {0}", container.IsRegistered<ITestService>());
            Console.WriteLine("Scope? {0}", container.GetRegistrationScope<ITestService>());
            Console.WriteLine("Scope? {0}", container.GetRegistrationScope(typeof(ITestService)));
        }
    }
}