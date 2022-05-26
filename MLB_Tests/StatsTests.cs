using MLB_Stats;
//using Stats;
//namespace MLB_Tests
namespace MLB_Stats.UnitTests

{
    [TestClass]
    public class StatsTests
    {
        [TestMethod]
        public void TestMethod1()
        {

            var ex = Assert.ThrowsException<Exception>(() => Stats.GetScheduleForSpecifiedDates("202", "202608"));
        //    Assert.That(ex.Message, Is.EqualTo("Invalid dates\n"));
            Assert.IsTrue(ex.Message == "Invalid dates");


            //Assert.ThrowsException<ArgumentException>(() =>
            //Assert.ThrowsException()
           // Assert.That
        }
    }

    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void testUserAddedToListOfUsers()
        {
            List<int> teams = new List<int> { 136, 146};
            User person1 = new User("Bob", "BobIsGreat", 140, teams);
            Assert.IsTrue(User.users.Contains(person1));
        }

    }
}