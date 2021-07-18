using DesignPatterns.Composite.Geometric;
using System;

namespace DesignPatterns.Composite
{
    class Program
    {
        //test
        static void Main(string[] args)
        {
            var d = new Demo();
            Console.WriteLine(d.PrintDemo()) ;
            var ns = new Neurons.Demo();
            ns.Start();
            Console.ReadKey();
        }
    }
}
