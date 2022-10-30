using System.ComponentModel.DataAnnotations;

namespace Books.Domain
{
    public class Book
    {
        public ulong Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}