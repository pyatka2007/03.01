using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46;

namespace Console46.Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Constructor_ShouldSetNameAndHP()
        {
            var person = new Person(75, "TestHero");
            Assert.AreEqual("TestHero", person.NamePerson);
            Assert.AreEqual(75, person.HP);
        }
    }
}