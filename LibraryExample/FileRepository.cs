using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExample
{
    public class FileRepository : IFileRepository
    {
        private readonly string _fileName;
        private readonly string _filePath;

        public FileRepository(string fileName)
        {
            _fileName = string.IsNullOrWhiteSpace(fileName) ? throw new ArgumentNullException(nameof(fileName)) : fileName;
            _filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            using var reader = new StreamReader(Path.Combine(_filePath, _fileName));
            var lines = new List<string>();

            while (!reader.EndOfStream)
            {
                lines.Add(await reader.ReadLineAsync());
            }

            return lines;
        }

        public async Task<string> GetById(string id)
        {
            using var reader = new StreamReader(Path.Combine(_filePath, _fileName));

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (line.Split("^^^")?.First()?.Equals(id) ?? false)
                {
                    return line;
                }
            }

            return string.Empty;
        }

        public async Task Insert(string line)
        {
            using var writer = new StreamWriter(Path.Combine(_filePath, _fileName), true, Encoding.UTF8);
            await writer.WriteLineAsync(line);
        }
    }
}
