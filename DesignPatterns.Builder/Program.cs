using DesignPatterns.Builder.Basic;
using DesignPatterns.Builder.Exercise;
using DesignPatterns.Builder.Faceted;
using DesignPatterns.Builder.Fluent;
using DesignPatterns.Builder.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    //In simple words, builder is just an API which helps to create complex objects
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(builder);
        }
    }
}
