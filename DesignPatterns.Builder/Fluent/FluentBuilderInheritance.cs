using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.Fluent
{
    public class FluentBuilderInheritance
    {
        public void Init()
        {
            var me = Person.New.Called("Pawel").WorksAsA("NotOfYourBusines").Born(DateTime.UtcNow).Build();
            Console.WriteLine(me);
        }
    }

    //Builder class is just a helper class, which gives u access to PersonBirthDateBuilder
    //PersonBirthDateBuilder inherits from PersonJobBuilder, which inherits from PersonInfoBuilder, which inhertis from PersonBuilder
    //PersonBuilder is most basic object of builder, which just returns new object of Person class
    //This way of inheritance, allows you to inherit from builder class with access to their methods, by using fluent building, like in line 13.
    //This way uses a recursive generics
    public class Person
    {
        public string Name;

        public string Position;

        public DateTime DateOfBirth;

        public class Builder : PersonBirthDateBuilder<Builder>
        {
            internal Builder() { }
        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    // here's another inheritance level
    // note there's no PersonInfoBuilder<PersonJobBuilder<PersonBirthDateBuilder<SELF>>>!

    public class PersonBirthDateBuilder<SELF> : PersonJobBuilder<PersonBirthDateBuilder<SELF>> where SELF : PersonBirthDateBuilder<SELF>
    {
        public SELF Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (SELF)this;
        }
    }
}
