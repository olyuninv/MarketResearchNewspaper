namespace Tests
{
    using NUnit.Framework;
    using ConsoleApp1;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUnder25Fashion()
        {
            var idealNewspaper = new Newspaper();
            idealNewspaper.fashionSupplement = true;
            idealNewspaper.sportsSupplement = true;
            idealNewspaper.entertainmentSupplement = true;
            idealNewspaper.healthcareSupplement = true;
            
            var person1 = new Customer();
            person1.age = 23;

            var engine = new MarketingResearchEngine();

            // Obvious case
            Assert.AreEqual(engine.testSuitability(idealNewspaper, person1), true);

            var newspaper1 = idealNewspaper;
            newspaper1.fashionSupplement = false;

            Assert.AreEqual(engine.testSuitability(idealNewspaper, person1), false);

            newspaper1.fashionSupplement = true;

            Assert.AreEqual(engine.testSuitability(idealNewspaper, person1), false);

            person1.age = 35;
            person1.gender = Gender.Woman;
            newspaper1.fashionSupplement = false;

            Assert.AreEqual(engine.testSuitability(idealNewspaper, person1), false);
            
            person1.age = 35;
            person1.gender = Gender.Woman;
            newspaper1.fashionSupplement = true;

            Assert.AreEqual(engine.testSuitability(idealNewspaper, person1), true);
            
        }
    }
}