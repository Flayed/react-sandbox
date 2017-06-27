using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ufo.Models;
using Ufo.Repositories;

namespace Ufo.Services
{
	public interface IUfoService
	{
		Task<IEnumerable<MissingPerson>> GetMissingPersons();
		Task<IEnumerable<MissingPerson>> GetMissingPersonsForCityState(string cityState);
		Task<IEnumerable<MissingPerson>> GetMissingPersonsForCity(string city, string cityState = null);
		Task<IEnumerable<string>> GetMissingPersonCityStates();
		Task<IEnumerable<string>> GetMissingPersonCities(string cityState = null);
	}

	public class UfoService : IUfoService
	{
		private readonly IMissingPersonsRepository _missingPersonsRepository;

		public UfoService(IMissingPersonsRepository missingPersonsRepository)
		{
			_missingPersonsRepository = missingPersonsRepository;
		}

		public Task<IEnumerable<MissingPerson>> GetMissingPersons()
		{
			return _missingPersonsRepository.GetMissingPersons();
		}

		public Task<IEnumerable<MissingPerson>> GetMissingPersonsForCityState(string cityState)
		{
			return _missingPersonsRepository.GetMissingPersonsForCityState(cityState);
		}

		public Task<IEnumerable<MissingPerson>> GetMissingPersonsForCity(string city, string cityState = null)
		{
			return _missingPersonsRepository.GetMissingPersonsForCity(city, cityState);
		}

		public Task<IEnumerable<string>> GetMissingPersonCityStates()
		{
			return _missingPersonsRepository.GetMissingPersonsCityStates();
		}
		
		public Task<IEnumerable<string>> GetMissingPersonCities(string cityState = null)
		{
			return _missingPersonsRepository.GetMissingPersonsCity(cityState);
		}
	}
}