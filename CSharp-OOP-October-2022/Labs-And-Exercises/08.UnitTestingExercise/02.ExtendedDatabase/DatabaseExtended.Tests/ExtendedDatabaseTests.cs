namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void Test_ConstructorShouldStoreDataInACollection()
        {
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i + 1, ((char)('a' + i)).ToString());
            }

            Database database = new Database(people);

            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void Test_ConstructorShouldThrowExceptionIfCountIsMoreThan16()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i + 1, ((char)('a' + i)).ToString());
            }

            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(people);
            });
        }

        [Test]
        public void Test_AddingPeopleShouldIncreaseCount()
        {
            int expectedCount = 10;

            for (int i = 0; i < expectedCount; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Test_AddingPersonToFullDatabaseShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "George"));
            });
        }

        [Test]
        public void Test_AddingPersonWithExistingUsernameShouldThrowException()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(6, "a"));
            });
        }

        [Test]
        public void Test_AddingPersonWithExistingIdShouldThrowException()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(5, "George"));
            });
        }

        [Test]
        public void Test_RemovingPeopleShouldDecreaseCount()
        {
            int initialCount = 7;

            for (int i = 0; i < initialCount; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            int removeCount = 3;

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(initialCount - removeCount, database.Count);
        }

        [Test]
        public void Test_RemovingPersonFromEmptyDatabaseShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Test_FindByUsernameShouldReturnTheCorrectPerson()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Person person = new Person(6, "Peter");
            database.Add(person);

            Assert.AreEqual(person, database.FindByUsername("Peter"));
        }

        [Test]
        public void Test_FindByUsernameShouldThrowExceptionIfUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        [Test]
        public void Test_FindByUsernameShouldThrowExceptionIfUsernameIsNotPresentInTheDatabase()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("John");
            });
        }

        [Test]
        public void Test_FindByIdShouldReturnTheCorrectPerson()
        {
            Person person = new Person(1, "Peter");
            database.Add(person);

            for (int i = 1; i < 5; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.AreEqual(person, database.FindById(1));
        }

        [Test]
        public void Test_FindByIdShouldThrowExceptionIfIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-5);
            });
        }

        [Test]
        public void Test_FindByIdShouldThrowExceptionIfIdIsNotPresentInTheDatabase()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Add(new Person(i + 1, ((char)('a' + i)).ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(10);
            });
        }
    }
}