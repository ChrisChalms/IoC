using IoC.Test.Interfaces;
using System;
using System.IO;

namespace IoC.Test.Classes
{
    class StringService : ITestService
    {
        private string _randomString;

        public StringService()
        {
            _randomString = Path.GetRandomFileName();
        }

        public void PrintResult()
        {
            Console.WriteLine("Random string {0}", _randomString);
        }
    }
}
