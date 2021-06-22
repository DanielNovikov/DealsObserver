using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsObserver.Domain.Concrete
{
    public class DealsService : IDealsService
    {
        private readonly IDealToDealDtoConverter _dtoConverter;
        private readonly IFormFileReader _formFileReader;
        private readonly IDealsCsvParser _dealsCsvParser;
        private readonly IDealsRepository _dealsRepository;

        public DealsService(
            IDealToDealDtoConverter dtoConverter,
            IFormFileReader formFileReader,
            IDealsCsvParser dealsCsvParser,
            IDealsRepository dealsRepository)
        {
            _dtoConverter = dtoConverter;
            _formFileReader = formFileReader;
            _dealsCsvParser = dealsCsvParser;
            _dealsRepository = dealsRepository;
        }

        public async Task<IList<DealDto>> GetAll()
        {
            var deals = await _dealsRepository.GetAll();

            return deals
                .Select(x => _dtoConverter.Convert(x))
                .ToList();
        }

        public async Task<TheMostPopularVachicleDto> GetTheMostPopularVehicle()
        {
            var vehicleName = await _dealsRepository.GetTheMostPopularVehicleName();

            return !string.IsNullOrEmpty(vehicleName) 
                ? new TheMostPopularVachicleDto(vehicleName)
                : default;
        }

        public async Task UploadFromCsv(IFormFile csvFile)
        {
            var csv = await _formFileReader.ReadAllText(csvFile);

            var deals = _dealsCsvParser.Parse(csv);

            await _dealsRepository.Add(deals);
        }
    }
}
