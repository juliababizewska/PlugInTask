using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlugInFinal;
namespace UnitTest
{
    [TestFixture]
    public class Tests
    {

        List<IPlugin> plugins;

        [SetUp]
        public void initializeTest()
        {
            plugins = Program.LoadPlugins();
        }

        [Test, Order(1)]
        public void reverseTest()
        {
            String expected = "retupmoc";
            String input = "computer";
            IPlugin reverse = plugins.Find(p => p.name() == "--reverse");
            String output = reverse.Execute(input);
            Assert.That(output, Is.EqualTo(expected));

        }

        [Test, Order(2)]
        public void countTest()
        {
            String input = "computer";
            String expected = input.Length.ToString();
            IPlugin reverse = plugins.Find(p => p.name() == "--count");
            String output = reverse.Execute(input);
            Assert.That(output, Is.EqualTo(expected));

        }


    }
}
