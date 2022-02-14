using System;
using System.Threading.Tasks;

namespace LibraryExample
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var bookService = GetBookService();
            Console.WriteLine("Enter new book title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Enter new book author: ");
            var author = Console.ReadLine();

            await bookService.SaveBook(new Book
            {
                Author = author,
                Title = title,
                Id = Guid.NewGuid().ToString()
            });

            var allBooks = await bookService.GetAllBooks();

            foreach(var book in allBooks)
            {
                Console.WriteLine($"Id: {book.Id}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine();
            }

        }

        private static IBookService GetBookService()
        {
            return new BookService(new FileRepository("books.txt"));
        }


    }
}
