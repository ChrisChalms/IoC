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
            //container.Register<ITestService>(() => new EmailService());
            //container.Register<ITestService>(typeof(LogService));
            //container.Register<ITestService>(new LogService());

            var service = container.Resolve<ITestService>();

            Console.WriteLine("Registered? {0}", container.IsRegistered(typeof(ITestService)));
            service.PrintName();
        }
    }
}