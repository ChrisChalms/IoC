using IoC.Test.Interfaces;
using System;

namespace IoC.Test.Classes
{
    class GuiService : ITestService
    {
        public string _guid;
        
        public GuiService()
        {
            _guid = Guid.NewGuid().ToString();
        }

        public void PrintResult()
        {
            Console.WriteLine("Guid: {0}", _guid);
        }
    }
}
