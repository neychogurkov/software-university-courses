using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 2);
            dummy = new Dummy(30, 3);
        }

        [Test]
        public void Test_AxeShouldLoseDurabilityAfterEachAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(1, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AttackingWithBrokenAxeShouldThrowException()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}