using System;

namespace DealsObserver.Data.Models
{
    public partial class Deal
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string VehicleName { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
