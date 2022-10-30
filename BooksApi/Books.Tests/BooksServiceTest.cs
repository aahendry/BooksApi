using Books.Api.Repositories;
using Books.Api.Services;
using Books.Domain;
using Books.Domain.Enums;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Books.Tests
{
    public class BooksServiceTest
    {
        public Mock<IBooksRepository> _mockBooksRepo;
        public IBooksService _service;

        [SetUp]
        public void Setup()
        {
            _mockBooksRepo = new Mock<IBooksRepository>();
            _service = new BooksService(_mockBooksRepo.Object);
        }

        [Test]
        public void CreateBook_Success()
        {
            var book = new Book { 
                Author = "Test Author",
                Title = "Test Title",
                Price = 50.99M
            };

            _mockBooksRepo.Setup(o => o.CreateBook(book)).Returns(5);

            var result = _service.CreateBook(book);

            result.Should().Be(5);
        }

        [TestCase(SortBy.title)]
        [TestCase(SortBy.author)]
        [TestCase(SortBy.price)]
        public void GetBooks_Success(SortBy sortby)
        {
            var books = new Mock<IQueryable<Book>>();
            _mockBooksRepo.Setup(o => o.GetBooks(sortby)).Returns(books.Object);

            var result = _service.GetBooks(sortby);

            result.Should().BeEquivalentTo(books.Object);
        }

        [Test]
        public void UpdateBookById_Success()
        {
            ulong id = 55;
            var book = new Mock<Book>();
            _mockBooksRepo.Setup(o => o.UpdateBookById(id, book.Object)).Returns(book.Object);

            var result = _service.UpdateBookById(id, book.Object);

            result.Should().Be(book.Object);
        }

        [Test]
        public void UpdateBookById_NotFound()
        {
            ulong id = 55;
            var book = new Mock<Book>();
            _mockBooksRepo.Setup(o => o.UpdateBookById(id, book.Object)).Returns((Book)null);

            var result = _service.UpdateBookById(id, book.Object);

            result.Should().BeNull();
        }

        [Test]
        public void GetBookById_Success()
        {
            ulong id = 55;
            var book = new Mock<Book>();
            _mockBooksRepo.Setup(o => o.GetBookById(id)).Returns(book.Object);

            var result = _service.GetBookById(id);

            result.Should().Be(book.Object);
        }

        [Test]
        public void GetBookById_NotFound()
        {
            ulong id = 55;
            _mockBooksRepo.Setup(o => o.GetBookById(id)).Returns((Book)null);

            var result = _service.GetBookById(id);

            result.Should().BeNull();
        }

        [Test]
        public void DeleteBookById_Success()
        {
            ulong id = 55;
            _mockBooksRepo.Setup(o => o.DeleteBookById(id)).Returns(true);

            var result = _service.DeleteBookById(id);

            result.Should().BeTrue();
        }

        [Test]
        public void DeleteBookById_NotFound()
        {
            ulong id = 55;
            _mockBooksRepo.Setup(o => o.DeleteBookById(id)).Returns(false);

            var result = _service.DeleteBookById(id);

            result.Should().BeFalse();
        }
    }
}