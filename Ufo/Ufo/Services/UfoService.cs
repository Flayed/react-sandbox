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
        IEnumerable<MissingPerson> GetMissingPersons();
        IEnumerable<MissingPerson> GetMissingPersonsForCityState(string cityState);
        IEnumerable<MissingPerson> GetMissingPersonsForCity(string city, string cityState = null);
        IEnumerable<string> GetMissingPersonCityStates();
        IEnumerable<string> GetMissingPersonCities(string cityState = null);
    }

    public class UfoService : IUfoService
    {
        private readonly IUfoRepository _ufoRepository;

        public UfoService(IUfoRepository ufoRepository)
        {
            _ufoRepository = ufoRepository;
        }

        public IEnumerable<MissingPerson> GetMissingPersons()
        {
            return _ufoRepository.GetMissingPersons();
        }

        public IEnumerable<MissingPerson> GetMissingPersonsForCityState(string cityState)
        {
            return _ufoRepository.GetMissingPersonsForCityState(cityState);
        }

        public IEnumerable<MissingPerson> GetMissingPersonsForCity(string city, string cityState = null)
        {
            return _ufoRepository.GetMissingPersonsForCity(city, cityState);
        }

        public IEnumerable<string> GetMissingPersonCityStates()
        {
            return _ufoRepository.GetMissingPersonsCityStates();
        }
        
        public IEnumerable<string> GetMissingPersonCities(string cityState = null)
        {
            return _ufoRepository.GetMissingPersonsCity(cityState);
        }
    }
}