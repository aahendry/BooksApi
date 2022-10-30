using Books.Api.Repositories;
using Books.Domain;
using Books.Domain.Enums;

namespace Books.Api.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepo;   

        public BooksService(IBooksRepository booksRepo)
        {
            _booksRepo = booksRepo;
        }

        public ulong CreateBook(Book book)
        {
            return _booksRepo.CreateBook(book);
        }

        public IQueryable<Book> GetBooks(SortBy? sortby)
        {
            return _booksRepo.GetBooks(sortby);
        }

        public Book? UpdateBookById(ulong id, Book book)
        {
            return _booksRepo.UpdateBookById(id, book);
        }

        public Book? GetBookById(ulong id)
        {
            return _booksRepo.GetBookById(id);
        }

        public bool DeleteBookById(ulong id)
        {
            return _booksRepo.DeleteBookById(id);
        }
    }
}
