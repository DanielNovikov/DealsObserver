using DealsObserver.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealsObserver.Domain.Abstract
{
    public interface IDealsService
    {
        Task<IList<DealDto>> GetAll();

        Task<TheMostPopularVachicleDto> GetTheMostPopularVehicle();

        Task UploadFromCsv(IFormFile csvFile);
    }
}
