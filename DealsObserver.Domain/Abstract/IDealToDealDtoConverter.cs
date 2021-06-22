using DealsObserver.Data.Models;
using DealsObserver.Domain.Models;

namespace DealsObserver.Domain.Abstract
{
    public interface IDealToDealDtoConverter
    {
        DealDto Convert(Deal deal);
    }
}
