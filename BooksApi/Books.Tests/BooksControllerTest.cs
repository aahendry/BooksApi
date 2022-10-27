using Books.Api.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using FluentAssertions;
using Books.Domain.Enums;
using Books.Domain;

namespace Books.Tests
{
    public class BooksControllerTest
    {
        public Mock<ILogger<BooksController>> _mockLogger;
        public BooksController _controller;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<BooksController>>();
            _controller = new BooksController(_mockLogger.Object);
        }

        [Test]
        public void CreateBook_Throws()
        {
            _controller.Invoking(o => o.CreateBook(It.IsAny<Book>())).Should().Throw<NotImplementedException>();
        }

        [Test]
        public void GetBook_Throws()
        {
            _controller.Invoking(o => o.GetBook(It.IsAny<SortBy>())).Should().Throw<NotImplementedException>();
        }

        [Test]
        public void UpdateBookById_Throws()
        {
            _controller.Invoking(o => o.UpdateBookById(It.IsAny<int>(), It.IsAny<Book>())).Should().Throw<NotImplementedException>();
        }

        [Test]
        public void GetBookById_Throws()
        {
            _controller.Invoking(o => o.GetBookById(It.IsAny<int>())).Should().Throw<NotImplementedException>();
        }

        [Test]
        public void DeleteBookById_Throws()
        {
            _controller.Invoking(o => o.DeleteBookById(It.IsAny<int>())).Should().Throw<NotImplementedException>();
        }
    }
}