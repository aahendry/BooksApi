using Books.Data;
using Books.Domain;
using Books.Domain.Enums;

namespace Books.Api.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context;
        }

        public ulong CreateBook(Book book)
        {
            var books = _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }

        public IQueryable<Book> GetBooks(SortBy? sortby)
        {
            var books = _context.Books;

            switch (sortby)
            {
                case SortBy.author:
                    return books.OrderBy(o => o.Author);
                case SortBy.price:
                    return books.OrderBy(o => o.Price);
                case SortBy.title:
                default:
                    return books.OrderBy(o => o.Title);
            }
        }

        public Book? UpdateBookById(ulong id, Book newBook)
        {
            var existingBook = _context.Books.FirstOrDefault(o => o.Id == id);

            if (existingBook != null)
            {
                existingBook.Title = newBook.Title;
                existingBook.Author = newBook.Author;
                existingBook.Price = newBook.Price;

                _context.Books.Update(existingBook);
                _context.SaveChanges();
            }

            return existingBook;
        }

        public Book? GetBookById(ulong id)
        {
            return _context.Books.FirstOrDefault(o => o.Id == id);
        }

        public bool DeleteBookById(ulong id)
        {
            var book = _context.Books.FirstOrDefault(o => o.Id == id);

            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
