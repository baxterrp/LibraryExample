using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample
{
    public class BookService : IBookService
    {
        private readonly IFileRepository _fileRepository;

        public BookService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository ?? throw new System.ArgumentNullException(nameof(fileRepository));
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _fileRepository.GetAll();

            return books.Select(b =>
            {
                var props = b.Split("|");
                return new Book
                {
                    Id = props[0],
                    Title = props[1],
                    Author = props[2],
                };
            });
        }

        public async Task<Book> GetBook(string id)
        {
            var book = await _fileRepository.GetById(id);
            var props = book.Split("|");
            return new Book
            {
                Id = props[0],
                Title = props[1],
                Author = props[2],
            };
        }

        public async Task SaveBook(Book book)
        {
            var bookString = $"{book.Id}|{book.Title}|{book.Author}";
            await _fileRepository.Insert(bookString);
        }
    }
}
