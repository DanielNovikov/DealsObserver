using System;

namespace DealsObserver.Domain.Models
{
    public class DealDto
    {
        public int Number { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string VehicleName { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
    }
}
