using System.Collections.Generic;
using System.Threading.Tasks;
using Ufo.Services;

namespace Ufo.Repositories
{
	public abstract class RepositoryBase<T>
	{
		private readonly IJsonSerializationService _jsonSerializationService;
		private readonly IDataService _dataService;

		protected RepositoryBase(IJsonSerializationService jsonSerializationService, IDataService dataService)
		{
			_dataService = dataService;
			_jsonSerializationService = jsonSerializationService;
		}

		protected abstract string DataFileName { get; }

		private IEnumerable<T> _repository;
		protected async Task<IEnumerable<T>> GetRepository()
		{
			if (_repository != null) return _repository;
			_repository = await GetRepositoryAsync();
			return _repository;
		}

		private async Task<IEnumerable<T>> GetRepositoryAsync()
		{
			string dataFileContents = await _dataService.GetData(DataFileName);

			if (string.IsNullOrWhiteSpace(dataFileContents)) return new List<T>();

			return _jsonSerializationService.Deserialize<IEnumerable<T>>(dataFileContents);
		}
	}
}