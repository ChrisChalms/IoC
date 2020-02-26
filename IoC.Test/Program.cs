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
            container.Register<ITestService>(() => new EmailService());
            
            var service = container.Resolve<ITestService>();
            service.PrintName();
        }
    }
}