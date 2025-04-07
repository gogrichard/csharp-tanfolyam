using NUnit.Framework;
using ButtonCatching.Logic;

namespace ButtonCatching.Tests
{
    public class GameLogicTests
    {
        [Test]
        public void RegisterCatch_IncrementsAndReducesDelay()
        {
            var logic = new GameLogic();
            logic.RegisterCatch();

            Assert.That(logic.CatchCount, Is.EqualTo(1));
            Assert.That(logic.Delay, Is.EqualTo(1900));
        }

        [Test]
        public void GetRandomPosition_IsWithinClientBounds()
        {
            var logic = new GameLogic();
            var pos = logic.GetRandomPosition(new Size(500, 300), new Size(100, 50));

            Assert.That(pos.X, Is.InRange(0, 400));
            Assert.That(pos.Y, Is.InRange(0, 250));
        }
    }
}
