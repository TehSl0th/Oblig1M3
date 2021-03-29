using M3Oblig1;
using NUnit.Framework;

namespace M3Oblig1Test
{
    public class Tests
    {
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 24,
                FirstName = "Mikael",
                BirthYear = 1996,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Mikael (Id=24) Født: 1996";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}