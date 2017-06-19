using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ufo.Contexts;
using Ufo.DbAccess.Models.Entities;

namespace Ufo.DbAccess.Repositories
{
    public interface IUfoRepository
    {
        Task<List<missingperson>> GetMissingPersons();
        Task<List<missingperson>> GetMissingPersonsForCityState(string cityState);
        Task<List<missingperson>> GetMissingPersonsForCity(string city, string cityState = null);
        Task<List<string>> GetMissingPersonsCityStates();
        Task<List<string>> GetMissingPersonsCity(string cityState = null);
    }

    public class UfoRepository : IUfoRepository
    {
        protected readonly UfoContext Db = new UfoContext();

        public Task<List<missingperson>> GetMissingPersons()
        {
            return Db.MissingPersons.Take(100).ToListAsync();
        }

        public Task<List<missingperson>> GetMissingPersonsForCityState(string cityState)
        {
            return Db.MissingPersons.Where(mp => mp.citystate.Equals(cityState, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public Task<List<missingperson>> GetMissingPersonsForCity(string city, string cityState = null)
        {
            if (string.IsNullOrWhiteSpace(cityState))
                return Db.MissingPersons.Where(mp => mp.city.Equals(city, StringComparison.OrdinalIgnoreCase))
                    .ToListAsync();
            return Db.MissingPersons.Where(mp => mp.citystate.Equals(cityState, StringComparison.OrdinalIgnoreCase) &&
                                                 mp.city.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public Task<List<string>> GetMissingPersonsCityStates()
        {
            return Db.MissingPersons.Select(mp => mp.citystate).Distinct().OrderBy(c=>c).ToListAsync();
        }

        public Task<List<string>> GetMissingPersonsCity(string cityState = null)
        {
            if (string.IsNullOrWhiteSpace(cityState))
                return Db.MissingPersons.Select(mp => mp.city).Distinct().ToListAsync();
            return Db.MissingPersons.Where(mp => mp.citystate.Equals(cityState, StringComparison.OrdinalIgnoreCase))
                .Select(mp => mp.city).Distinct().ToListAsync();
        }
    }
}