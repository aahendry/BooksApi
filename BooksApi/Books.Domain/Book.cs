namespace Books.Domain
{
    public class Book
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}