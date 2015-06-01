using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interface.InterfaceTest interfaceTest = new Interface.InterfaceTest();
            interfaceTest.StartTest();

            Delegate.DelegateTest delegateTest = new Delegate.DelegateTest();
            delegateTest.StartTest();
        }
    }
}
