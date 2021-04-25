using HCL.RockPaperScissors.Service.Service;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HCL.RockPaperScissors.Tests
{
    public class RockPaperScissorsGameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async  Task UserEntryIsValid()
        {
            RockPaperScissorsGame rockPaperScissorsGame = new RockPaperScissorsGame();
            var isValid =  await  rockPaperScissorsGame.IsUserEntryValid("Rock");
            Assert.IsTrue(isValid == true);
        }

        [Test]
        public async Task UserEntryIsInValid()
        {
            RockPaperScissorsGame rockPaperScissorsGame = new RockPaperScissorsGame();
            var isValid = await rockPaperScissorsGame.IsUserEntryValid("Rr");
            Assert.IsTrue(isValid == false);
        }
    }
}