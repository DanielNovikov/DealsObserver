using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DealsObserver.Domain.Abstract
{
    public interface IFormFileReader
    {
        Task<string> ReadAllText(IFormFile file); 
    }
}
