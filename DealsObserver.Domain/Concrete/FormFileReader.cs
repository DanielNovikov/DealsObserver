using DealsObserver.Domain.Abstract;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DealsObserver.Domain.Concrete
{
    public class FormFileReader : IFormFileReader
    {
        public Task<string> ReadAllText(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return reader.ReadToEndAsync();
            }
        }
    }
}
