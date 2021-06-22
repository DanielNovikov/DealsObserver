using DealsObserver.Data.Models;
using DealsObserver.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace DealsObserver.Domain.Concrete
{
    public class DealsCsvParser : IDealsCsvParser
    {
        private char[] LineSplitters => new[] { '\r', '\n' };
        private const string DateFormat = "M/d/yyyy";
        private const string PropertiesSplitRegex = @",(?=(?:[^\""]*\""[^\""]*\"")*[^\""]*$)";

        public IList<Deal> Parse(string csv)
        {
            var dealsProperties = csv
                .Split(LineSplitters)
                .Skip(1)
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => Regex.Split(x, PropertiesSplitRegex));

            return dealsProperties
                .Select(x => new Deal
                {
                    Number = int.Parse(x[0]),
                    CustomerName = x[1],
                    DealershipName = x[2],
                    VehicleName = x[3],
                    Price = float.Parse(x[4].Trim('"')),
                    Date = DateTime.ParseExact(x[5], DateFormat, CultureInfo.InvariantCulture)
                })
                .ToList();
        }
    }
}
