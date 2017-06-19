using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ufo.DbAccess.Repositories;
using Ufo.Models;

namespace Ufo.Services
{
    public interface IUfoService
    {
        Task<IEnumerable<MissingPerson>> GetMissingPersons();
        Task<IEnumerable<MissingPerson>> GetMissingPersonsForCityState(string cityState);
        Task<IEnumerable<MissingPerson>> GetMissingPersonsForCity(string city, string cityState = null);
        Task<List<string>> GetMissingPersonCityStates();
        Task<List<string>> GetMissingPersonCities(string cityState = null);
    }

    public class UfoService : IUfoService
    {
        private readonly IUfoRepository _ufoRepository;

        public UfoService(IUfoRepository ufoRepository)
        {
            _ufoRepository = ufoRepository;
        }

        public async Task<IEnumerable<MissingPerson>> GetMissingPersons()
        {
            var missingPersons = await _ufoRepository.GetMissingPersons().ConfigureAwait(false);
            return missingPersons.Select(mp => new MissingPerson(mp));
        }

        public async Task<IEnumerable<MissingPerson>> GetMissingPersonsForCityState(string cityState)
        {
            var missingPersons = await _ufoRepository.GetMissingPersonsForCityState(cityState).ConfigureAwait(false);
            return missingPersons.Select(mp => new MissingPerson(mp));
        }

        public async Task<IEnumerable<MissingPerson>> GetMissingPersonsForCity(string city, string cityState = null)
        {
            var missingPersons = await _ufoRepository.GetMissingPersonsForCity(city, cityState).ConfigureAwait(false);
            return missingPersons.Select(mp => new MissingPerson(mp));
        }

        public async Task<List<string>> GetMissingPersonCityStates()
        {
            var cityStates = await _ufoRepository.GetMissingPersonsCityStates().ConfigureAwait(false);
            return cityStates;

        }
        
        public async Task<List<string>> GetMissingPersonCities(string cityState = null)
        {
            var cities = await _ufoRepository.GetMissingPersonsCity(cityState).ConfigureAwait(false);
            return cities;
        }
    }
}