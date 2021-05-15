using System;

namespace DesignPatterns.Prototype
{
    class Program
    {
        //Prototype is a nice way to deepcopy objects, but you will get the same result just by serializing and desirializing object with newtonsoft.json
        //So for me at this moment I think it's useless
        static void Main(string[] args)
        {
            var john = new Employee();
            john.Names = new[] { "John", "Doe" };
            john.Address = new Address { HouseNumber = 123, StreetName = "London Road" };
            john.Salary = 321000;
            var copy = john.DeepCopy();

            copy.Names[1] = "Smith";
            copy.Address.HouseNumber++;
            copy.Salary = 123000;

            Console.WriteLine(john);
            Console.WriteLine(copy);
        }
    }
}
