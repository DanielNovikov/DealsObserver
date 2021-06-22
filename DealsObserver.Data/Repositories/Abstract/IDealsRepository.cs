using DealsObserver.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealsObserver.Data.Repositories.Abstract
{
    public interface IDealsRepository
    {
        Task<IList<Deal>> GetAll();

        Task<string> GetTheMostPopularVehicleName();

        Task Add(IList<Deal> deals);
    }
}
