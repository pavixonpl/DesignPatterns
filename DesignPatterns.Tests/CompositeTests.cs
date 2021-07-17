using DesignPatterns.Composite.Exercise;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class CompositeTests
    {
        [Test]
        public void Test()
        {
            var singleValue = new SingleValue { Value = 11 };
            var otherValues = new ManyValues();
            otherValues.Add(22);
            otherValues.Add(33);
            Assert.That(new List<IValueContainer> { singleValue, otherValues }.Sum(), Is.EqualTo(66));
        }
    }
}
