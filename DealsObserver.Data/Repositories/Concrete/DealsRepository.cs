using Microsoft.EntityFrameworkCore;
using DealsObserver.Data.Models;
using DealsObserver.Data.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DealsObserver.Data.Repositories.Concrete
{
    public class DealsRepository : IDealsRepository
    {
        private readonly DealsContext _context;

        public DealsRepository(DealsContext context)
        {
            _context = context;
        }

        public async Task<IList<Deal>> GetAll()
        {
            return await _context
                .Deals
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<string> GetTheMostPopularVehicleName()
        {
            return _context
                .Deals
                .AsNoTracking()
                .GroupBy(x => x.VehicleName)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefaultAsync();
        }

        public async Task Add(IList<Deal> deals)
        {
            foreach (var deal in deals)
                await _context.Deals.AddAsync(deal);

            await _context.SaveChangesAsync();

            foreach (var deal in deals)
                _context.Entry(deal).State = EntityState.Detached;
        }
    }
}
