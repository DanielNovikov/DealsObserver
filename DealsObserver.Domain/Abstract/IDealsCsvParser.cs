using DealsObserver.Data.Models;
using System.Collections.Generic;

namespace DealsObserver.Domain.Abstract
{
    public interface IDealsCsvParser
    {
        IList<Deal> Parse(string csv);
    }
}
