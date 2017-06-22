using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ufo.Models;
using Ufo.Services;

namespace Ufo.DbAccess.Repositories
{
    public interface IUfoRepository
    {
        IEnumerable<MissingPerson> GetMissingPersons();
        IEnumerable<MissingPerson> GetMissingPersonsForCityState(string cityState);
        IEnumerable<MissingPerson> GetMissingPersonsForCity(string city, string cityState = null);
        IEnumerable<string> GetMissingPersonsCityStates();
        IEnumerable<string> GetMissingPersonsCity(string cityState = null);
    }

    public class UfoRepository : RepositoryBase<MissingPerson>, IUfoRepository
    {
        protected override string DataFileName => "MissingPersons.json";

        public UfoRepository(IFileService fileService, IJsonSerializationService jsonSerializationService) : base(fileService, jsonSerializationService)
        {
        }


        public IEnumerable<MissingPerson> GetMissingPersons()
        {
            return Repository;
        }

        public IEnumerable<MissingPerson> GetMissingPersonsForCityState(string cityState)
        {
            return Repository.Where(mp => mp.CityState.Equals(cityState, StringComparison.OrdinalIgnoreCase));               
        }

        public IEnumerable<MissingPerson> GetMissingPersonsForCity(string city, string cityState = null)
        {
            if (string.IsNullOrWhiteSpace(cityState))
                return Repository.Where(mp => mp.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            return Repository.Where(mp => mp.CityState.Equals(cityState, StringComparison.OrdinalIgnoreCase) &&
                                                 mp.City.Equals(city, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<string> GetMissingPersonsCityStates()
        {
            return Repository.Select(mp => mp.CityState.Trim()).Distinct().OrderBy(c=>c);
        }

        public IEnumerable<string> GetMissingPersonsCity(string cityState = null)
        {
            if (string.IsNullOrWhiteSpace(cityState))
                return Repository.Select(mp => mp.City.Trim()).Distinct().OrderBy(c=>c);
            return Repository.Where(mp => mp.CityState.Equals(cityState, StringComparison.OrdinalIgnoreCase))
                .Select(mp => mp.City.Trim()).Distinct().OrderBy(c=>c);
        }


    }
}