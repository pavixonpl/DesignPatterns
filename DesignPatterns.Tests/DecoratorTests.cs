using DesignPatterns.Decorator.CustomStringBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class DecoratorTests
    {
        [Test]
        public void CustomStringBuilder_ReturnsProperValues()
        {
            var demo = new Demo();
            var data = new string[] { "firstLine", "secondLine" };
            var result = demo.Invoke(data);
            var expectedResult = new StringBuilder().AppendLine("firstLine").AppendLine("secondLine").ToString();
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("hello", "world")]
        [TestCase("hello ", "\nworld")]
        public void AdapterDecorator_ReturnsProperValues(string firstArg, string secondArg)
        {
            var demo = new Decorator.AdapterDecorator.Demo();
            var result = demo.Invoke(new string[] { firstArg, secondArg });
            var expectedResult = new StringBuilder().Append(firstArg).Append(secondArg).ToString();
            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void AutofacDecoratorWorksProperly()
        {
            var demo = new Decorator.Autofac.Decorators();
            var res = demo.Invoke();
            var expectedRes = new StringBuilder().AppendLine("Commencing log...").Append("Here is your report").AppendLine("Ending log...").ToString();
            Assert.AreEqual(expectedRes, res);

        }
    }
}
