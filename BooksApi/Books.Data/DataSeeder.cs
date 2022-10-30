using Books.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Books.Data
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new BooksContext(
                serviceProvider.GetRequiredService<DbContextOptions<BooksContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Books',RESEED,0);");

                context.Books.AddRange(
                    new Book
                    {
                        Author = "A. A. Milne",
                        Title = "Winnie-the-Pooh",
                        Price = 19.25M
                    },
                    new Book
                    {
                        Author = "Jane Austen",
                        Title = "Pride and Prejudice",
                        Price = 5.49M
                    },
                    new Book
                    {
                        Author = "William Shakespeare",
                        Title = "Romeo and Juliet",
                        Price = 6.95M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}