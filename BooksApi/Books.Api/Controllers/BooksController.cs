using Books.Api.Services;
using Books.Domain;
using Books.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksService;

        public BooksController(ILogger<BooksController> logger, IBooksService booksService)
        {
            _logger = logger;
            _booksService = booksService;
        }

        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book body)
        {
            var id = _booksService.CreateBook(body);

            return new ObjectResult(id) { StatusCode = 201 };
        }

        /// <summary>
        /// Returns a list of books. Sorted by title by default.
        /// </summary>
        /// <param name="sortby"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        public IActionResult GetBook([FromQuery] SortBy? sortby)
        {
            return new OkObjectResult(_booksService.GetBooks(sortby));
        }

        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Book not found</response>
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(ulong id, [FromBody] Book body)
        {
            var book = _booksService.UpdateBookById(id, body);

            if (book == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(book);
        }

        /// <summary>
        /// Gets a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpGet("{id}")]
        public IActionResult GetBookById(ulong id)
        {
            var book = _booksService.GetBookById(id);

            if (book == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(book);
        }

        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(ulong id)
        {
            if (_booksService.DeleteBookById(id))
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }
    }
}