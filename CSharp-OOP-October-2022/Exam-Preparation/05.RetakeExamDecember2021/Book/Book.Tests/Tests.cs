namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private const string BOOK_NAME = "Harry Potter";
        private const string AUTHOR = "J. K. Rowling";
        private Book book;

        [SetUp] 
        public void SetUp()
        {
            book = new Book(BOOK_NAME, AUTHOR);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            Assert.AreEqual(BOOK_NAME, book.BookName);
            Assert.AreEqual(AUTHOR, book.Author);
            Assert.DoesNotThrow(() =>
            {
                int count = book.FootnoteCount;
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void BookNameSetterShouldThrowExceptionIfValueIsNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, AUTHOR);
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void AuthorSetterShouldThrowExceptionIfValueIsNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(BOOK_NAME, author);
            });
        }

        [Test]
        public void AddFootnoteShouldAddFootnotesToADictionary()
        {
            int expectedCount = 5;

            for (int i = 1; i <= expectedCount; i++)
            {
                book.AddFootnote(i, $"Footnote{i}");
            }

            Assert.AreEqual(expectedCount, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteShouldThrowExceptionIfFootnoteAlreadyExists()
        {
            for (int i = 1; i <= 5; i++)
            {
                book.AddFootnote(i, $"Footnote{i}");
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(3, "Footnote");
            });
        }

        [Test]
        public void FindFootnoteShouldReturnCorrectFootnoteInfo()
        {
            for (int i = 1; i <= 5; i++)
            {
                book.AddFootnote(i, $"Footnote{i}");
            }
            int footnoteNumber = 3;
            string expectedText = $"Footnote #{footnoteNumber}: {$"Footnote{footnoteNumber}"}";
            Assert.AreEqual(expectedText, book.FindFootnote(3));
        }

        [Test]
        public void FindFootnoteShouldThrowExceptionIfFootnoteDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                book.AddFootnote(i, $"Footnote{i}");
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                string result = book.FindFootnote(6);
            });
        }

        [Test]
        public void AlterFootnoteShouldChangeFootnoteText()
        {
            for (int i = 1; i <= 5; i++)
            {
                book.AddFootnote(i, $"Footnote{i}");
            }

            int footnoteNumber = 2;
            string newText = "My Footnote";
            book.AlterFootnote(footnoteNumber, newText);
            string expectedText = $"Footnote #{footnoteNumber}: {newText}";

            Assert.AreEqual(expectedText, book.FindFootnote(footnoteNumber));
        }

        [Test]
        public void AlterFootnoteShouldThrowExceptionIfFootnoteDoesNotExist()
        {
            for (int i = 1; i <= 5; i++)
            {
                book.AddFootnote(i, $"Footnote{i}");
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(6, "My Footnote");
            });
        }
    }
}