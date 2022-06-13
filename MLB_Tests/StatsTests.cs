using MLB_Stats;
//using Stats;
namespace MLB_Tests
//namespace MLB_Stats.UnitTests

{
    [TestClass]
    public class StatsTests
    {
        /*
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

        */
        [TestMethod]
        public static void testFormatNameMixLetters()
        {
            String name = "NEW york yANKEES";
            Assert.IsTrue(Stats.formatName(name) == "New York Yankees");
        }

        [TestMethod]
        public static void testFormatNameAllcapitalLetters()
        {
            String name = "NEW YORK YANKEES";
            Assert.IsTrue(Stats.formatName(name) == "New York Yankees");
        }

        [TestMethod]
        public static void testFormatNameAllLowercaseLetters()
        {
            String name = "new york yankees";
            Assert.IsTrue(Stats.formatName(name) == "New York Yankees");
        }

        [TestMethod]
        public static void testFormatNameOneWord()
        {
            String name = "rangers";
            Assert.IsTrue(Stats.formatName(name) == "Rangers");
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

        /*
        [TestMethod]
        public void testLoggedInStatusAfterAddingUser()
        {
            List<int> teams = new List<int> { 136, 146 };
            User person1 = new User("Bob", "BobIsGreat", 140, teams);
            
        }
        */
    }
}