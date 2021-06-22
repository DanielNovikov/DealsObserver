using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using Moq;

namespace DealsObserver.Tests.Domain.Concrete.DealsServiceTests
{
    public class Builder
    {
        private IDealToDealDtoConverter _dtoConverter;
        private IFormFileReader _formFileReader;
        private IDealsCsvParser _dealsCsvParser;
        private IDealsRepository _dealsRepository;

        public Builder()
        {
            _dtoConverter = Mock.Of<IDealToDealDtoConverter>();
            _formFileReader = Mock.Of<IFormFileReader>();
            _dealsCsvParser = Mock.Of<IDealsCsvParser>();
            _dealsRepository = Mock.Of<IDealsRepository>();
        }

        public Builder WithDtoConverter(IDealToDealDtoConverter dtoConverter)
        {
            _dtoConverter = dtoConverter;
            return this;
        }

        public Builder WithFormFileReader(IFormFileReader formFileReader)
        {
            _formFileReader = formFileReader;
            return this;
        }

        public Builder WithDealsCsvParser(IDealsCsvParser dealsCsvParser)
        {
            _dealsCsvParser = dealsCsvParser;
            return this;
        }

        public Builder WithDealsRepository(IDealsRepository dealsRepository)
        {
            _dealsRepository = dealsRepository;
            return this;
        }

        public IDealsService Build()
        {
            return new DealsService(
                _dtoConverter,
                _formFileReader,
                _dealsCsvParser,
                _dealsRepository);
        }
    }
}
