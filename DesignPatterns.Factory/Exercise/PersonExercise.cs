using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Exercise
{
    public class PersonExercise
    {
        //https://www.udemy.com/course/design-patterns-csharp-dotnet/
    }

    public class PersonFactory
    {
        List<Person> _createdPersons = new List<Person>();
        public Person CreatePerson(string name)
        {
            var e = new Person() { Name = name, Id = _createdPersons.Count };
            _createdPersons.Add(e);
            return e;
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
