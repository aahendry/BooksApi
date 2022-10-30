using Books.Domain;
using Books.Domain.Enums;

namespace Books.Api.Services
{
    public interface IBooksService
    {
        ulong CreateBook(Book book);
        IQueryable<Book> GetBooks(SortBy? sortby);
        Book? UpdateBookById(ulong id, Book book);
        Book? GetBookById(ulong id);
        bool DeleteBookById(ulong id);
    }
}