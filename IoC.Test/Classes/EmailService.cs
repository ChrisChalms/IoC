using IoC.Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Test.Classes
{
    class EmailService : ITestService
    {
        public void PrintName()
        {
            Console.WriteLine("Email service");
        }
    }
}
