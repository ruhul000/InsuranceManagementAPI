using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models.Factories;
using InsuranceManagementAPI.Models;

namespace InsuranceManagementAPI.Services
{
    public class CurrencyService: ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyFactory _currencyFactory;

        public CurrencyService(ICurrencyRepository currencyRepository, ICurrencyFactory currencyFactory)
        {
            _currencyRepository = currencyRepository;
            _currencyFactory = currencyFactory;
        }
        public async Task<Currency> Create(Currency currency)
        {
            Currency? response = null;
            var currencyDto = _currencyFactory.CreateFrom(currency);

            try
            {
                var insertedId = _currencyRepository.Add(currencyDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }


                //currencyDto.DepKey = insertedId;

                response = _currencyFactory.CreateFrom(currencyDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public Task<bool> Delete(int DepId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            var currencyDtos = await _currencyRepository.GetAll();

            return _currencyFactory.CreateMultipleFrom(currencyDtos);
        }

        public async Task<Currency> GetById(int DepId)
        {
            var currencyDto = await _currencyRepository.GetByID(DepId);

            return _currencyFactory.CreateFrom(currencyDto);
        }

        public Task<Currency> Update(Currency currency)
        {
            Currency? response = null;
            var currencyDto = _currencyFactory.CreateFrom(currency);

            try
            {
                var result = _currencyRepository.Update(currencyDto).Result;
                if (!result)
                {
                    return Task.FromResult<Currency>(response);
                }



                response = _currencyFactory.CreateFrom(currencyDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Currency>(response);
            }

            return Task.FromResult(response);

        }
    }
}
