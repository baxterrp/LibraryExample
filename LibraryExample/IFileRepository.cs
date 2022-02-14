using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryExample
{
    public interface IFileRepository
    {
        Task Insert(string line);
        Task<string> GetById(string id);
        Task<IEnumerable<string>> GetAll();
    }
}
