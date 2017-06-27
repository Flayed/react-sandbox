using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ufo.Models;
using Ufo.Services;

namespace Ufo.Repositories
{
	public interface IMissingPersonsRepository
	{
		Task<IEnumerable<MissingPerson>> GetMissingPersons();
		Task<IEnumerable<MissingPerson>> GetMissingPersonsForCityState(string cityState);
		Task<IEnumerable<MissingPerson>> GetMissingPersonsForCity(string city, string cityState = null);
		Task<IEnumerable<string>> GetMissingPersonsCityStates();
		Task<IEnumerable<string>> GetMissingPersonsCity(string cityState = null);
	}

	public class MissingPersonsRepository : RepositoryBase<MissingPerson>, IMissingPersonsRepository
	{
		protected override string DataFileName => "MissingPersons.json";

		public MissingPersonsRepository(IDataService dataService, IJsonSerializationService jsonSerializationService) : base(jsonSerializationService, dataService)
		{
		}


		public async Task<IEnumerable<MissingPerson>> GetMissingPersons()
		{
			return await GetRepository();
		}

		public async Task<IEnumerable<MissingPerson>> GetMissingPersonsForCityState(string cityState)
		{
			return (await GetRepository()).Where(mp => mp.CityState.Equals(cityState, StringComparison.OrdinalIgnoreCase));               
		}

		public async Task<IEnumerable<MissingPerson>> GetMissingPersonsForCity(string city, string cityState = null)
		{
			if (string.IsNullOrWhiteSpace(cityState))
				return (await GetRepository()).Where(mp => mp.City.Equals(city, StringComparison.OrdinalIgnoreCase));
			return (await GetRepository()).Where(mp => mp.CityState.Equals(cityState, StringComparison.OrdinalIgnoreCase) &&
												 mp.City.Equals(city, StringComparison.OrdinalIgnoreCase));
		}

		public async Task<IEnumerable<string>> GetMissingPersonsCityStates()
		{
			return (await GetRepository()).Select(mp => mp.CityState.Trim()).Distinct().OrderBy(c=>c);
		}

		public async Task<IEnumerable<string>> GetMissingPersonsCity(string cityState = null)
		{
			if (string.IsNullOrWhiteSpace(cityState))
				return (await GetRepository()).Select(mp => mp.City.Trim()).Distinct().OrderBy(c=>c);
			return (await GetRepository()).Where(mp => mp.CityState.Equals(cityState, StringComparison.OrdinalIgnoreCase))
				.Select(mp => mp.City.Trim()).Distinct().OrderBy(c=>c);
		}


	}
}