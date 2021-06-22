using DealsObserver.Data.Models;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Models;

namespace DealsObserver.Domain.Concrete
{
    public class DealToDealDtoConverter : IDealToDealDtoConverter
    {
        public DealDto Convert(Deal deal)
        {
            return new DealDto
            {
                Number = deal.Number,
                CustomerName = deal.CustomerName,
                DealershipName = deal.DealershipName,
                VehicleName = deal.VehicleName,
                Date = deal.Date,
                Price = $"CAD${deal.Price:n0}"
            };
        }
    }
}
