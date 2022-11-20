using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DummyHealth = 20;
        private const int DummyExperience = 3;

        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void Test_DummyLosesHealthIfAttacked()
        {
            dummy.TakeAttack(10);
            Assert.AreEqual(DummyHealth - 10, dummy.Health);
        }

        [Test]
        public void Test_DeadDummyThrowsExceptionIfAttacked()
        {
            dummy.TakeAttack(30);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(10);
            });
        }

        [Test]
        public void Test_DeadDummyShouldBeAbleToGiveExperience()
        {
            dummy.TakeAttack(30);
            Assert.AreEqual(DummyExperience, dummy.GiveExperience());
        }

        [Test]
        public void Test_AliveDummyShouldNotBeAbleToGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}