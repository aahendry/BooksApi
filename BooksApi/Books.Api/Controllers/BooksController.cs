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

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of books. Sorted by title by default.
        /// </summary>
        /// <param name="sortby"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        public IActionResult GetBook([FromQuery] SortBy sortby)
        {
            throw new NotImplementedException();
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
        public IActionResult UpdateBookById(int id, [FromBody] Book body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}