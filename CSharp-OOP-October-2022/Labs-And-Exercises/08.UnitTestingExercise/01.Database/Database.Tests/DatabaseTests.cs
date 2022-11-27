namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Test_ConstructorShouldIncreaseCount(params int[] data)
        {
            Database database = new Database(data);

            Assert.AreEqual(data.Length, database.Count);
        }

        [Test]
        public void Test_ConstructorShouldThrowExceptionWhenCountIsMoreThan16()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Test_ConstructorShouldAddData(params int[] data)
        {
            Database database = new Database(data);

            CollectionAssert.AreEquivalent(data, database.Fetch());
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Test_CountShouldReturnCorrectCount(params int[] data)
        {
            Database database = new Database(data);

            Assert.AreEqual(data.Length, database.Count);
        }

        [Test]
        public void Test_AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;

            for (int i = 0; i < expectedCount; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }
        
        [Test]
        public void Test_AddingElementsShouldAddThemToTheCollection()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(i);
            }

            int[] expectedData = new int[] { 0, 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expectedData, database.Fetch());
        }
        
        [Test]
        public void Test_AddingElementToFullDatabaseShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            } 

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });
        }

        [Test]
        public void Test_RemovingElementsShouldDecreaseCount()
        {
            int initialCount = 5;

            for (int i = 0; i < initialCount; i++)
            {
                database.Add(i);
            }

            int removeCount = 2;
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(initialCount - removeCount, database.Count);
        }
        
        [Test]
        public void Test_RemovingElementsShouldRemoveThemFromTheCollection()
        {
            int initialCount = 5;

            for (int i = 0; i < initialCount; i++)
            {
                database.Add(i);
            }

            int removeCount = 2;
            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            int[] expectedData = new int[] { 0, 1, 2};

            CollectionAssert.AreEqual(expectedData, database.Fetch());
        }
        
        [Test]
        public void Test_RemovingElementFromEmptyDatabaseShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Test_FetchShouldReturnElementsAsArray(params int[] data)
        {
            Database database = new Database(data);

            CollectionAssert.AreEqual(data, database.Fetch());
        }
    }
}
