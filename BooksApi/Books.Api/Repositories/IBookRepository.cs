using Books.Domain;
using Books.Domain.Enums;

namespace Books.Api.Repositories
{
    public interface IBooksRepository
    {
        ulong CreateBook(Book book);
        IQueryable<Book> GetBooks(SortBy? sortby);
        Book? UpdateBookById(ulong id, Book newBook);
        Book? GetBookById(ulong id);
        bool DeleteBookById(ulong id);
    }
}