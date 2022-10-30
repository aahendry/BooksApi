using Books.Api.Controllers;
using Books.Api.Services;
using Books.Domain;
using Books.Domain.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;

namespace Books.Tests
{
    public class BooksControllerTest
    {
        public Mock<ILogger<BooksController>> _mockLogger;
        public Mock<IBooksService> _mockBooksService;
        public BooksController _controller;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<BooksController>>();
            _mockBooksService = new Mock<IBooksService>();
            _controller = new BooksController(_mockLogger.Object, _mockBooksService.Object);
        }

        [Test]
        public void CreateBook_201()
        {
            var book = new Book { 
                Author = "Test Author",
                Title = "Test Title",
                Price = 50.99M
            };

            _mockBooksService.Setup(o => o.CreateBook(book)).Returns(5);

            var actionResult = _controller.CreateBook(book);
            var result = actionResult as ObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.Created);
            result.Value.Should().Be(5);
        }

        [TestCase(SortBy.title)]
        [TestCase(SortBy.author)]
        [TestCase(SortBy.price)]
        public void GetBook_200(SortBy sortby)
        {
            var books = new Mock<IQueryable<Book>>();

            _mockBooksService.Setup(o => o.GetBooks(sortby)).Returns(books.Object);

            var actionResult = _controller.GetBook(sortby);
            var result = actionResult as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().Be(books.Object);
        }

        [Test]
        public void UpdateBookById_200()
        {
            ulong id = 55;
            var book = new Mock<Book>();

            _mockBooksService.Setup(o => o.UpdateBookById(id, book.Object)).Returns(book.Object);

            var actionResult = _controller.UpdateBookById(id, book.Object);
            var result = actionResult as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().Be(book.Object);
        }

        [Test]
        public void UpdateBookById_400()
        {
            ulong id = 55;
            var book = new Mock<Book>();

            _mockBooksService.Setup(o => o.UpdateBookById(id, book.Object)).Returns((Book)null);

            var actionResult = _controller.UpdateBookById(id, book.Object);
            var result = actionResult as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public void GetBookById_200()
        {
            ulong id = 55;
            var book = new Mock<Book>();

            _mockBooksService.Setup(o => o.GetBookById(id)).Returns(book.Object);

            var actionResult = _controller.GetBookById(id);
            var result = actionResult as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().Be(book.Object);
        }

        [Test]
        public void GetBookById_400()
        {
            ulong id = 55;
            var book = new Mock<Book>();

            _mockBooksService.Setup(o => o.GetBookById(id)).Returns((Book)null);

            var actionResult = _controller.GetBookById(id);
            var result = actionResult as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public void DeleteBookById_200()
        {
            ulong id = 55;
            var book = new Mock<Book>();

            _mockBooksService.Setup(o => o.DeleteBookById(id)).Returns(true);

            var actionResult = _controller.DeleteBookById(id);
            var result = actionResult as OkResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Test]
        public void DeleteBookById_400()
        {
            ulong id = 55;
            var book = new Mock<Book>();

            _mockBooksService.Setup(o => o.DeleteBookById(id)).Returns(false);

            var actionResult = _controller.DeleteBookById(id);
            var result = actionResult as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
    }
}