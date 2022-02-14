using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryExample
{
    public interface IBookService
    {
        Task SaveBook(Book book);
        Task<Book> GetBook(string id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
