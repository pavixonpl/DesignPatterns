using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Builder.Functional
{
    public class FunctionalBuilderClass
    {
        public void Init()
        {

            var pb = new PersonBuilder();
            var person = pb.Called("Pawel").WorksAsA("Programmer").Build();
            Console.WriteLine($"{person.Name} {person.Position}");
        }
    }

    public class Person
    {
        public string Name, Position;
    }

    //Functional builder look pretty amazing, mainly bcs of simplicty to add new methods
    //You just create a class which inherits from basic Builder, and pass actions which will be triggered when build is called
    //I really like this solution
    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf> where TSubject : new ()
    {
        private readonly List<Func<Person, Person>> _actions = new List<Func<Person, Person>>(); //in out, are the same bcs of fluent workflow
        public TSelf Do(Action<Person> action) => AddAction(action);
        public Person Build() => _actions.Aggregate(new Person(), (p, f) => f(p)); //all actions for _actions collection will be triggered
        private TSelf AddAction(Action<Person> action)
        {
            _actions.Add(p => { action(p); return p; });
            return (TSelf) this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA(this PersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }
}
