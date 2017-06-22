using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ufo.Services;

namespace Ufo.DbAccess.Repositories
{
    public abstract class RepositoryBase<T>
    {
        private readonly IFileService _fileService;
        private readonly IJsonSerializationService _jsonSerializationService;

        protected RepositoryBase(IFileService fileService, IJsonSerializationService jsonSerializationService)
        {
            _fileService = fileService;
            _jsonSerializationService = jsonSerializationService;
        }

        protected abstract string DataFileName { get; }

        private static readonly object _repositoryLock = new object();
        private IEnumerable<T> _repository;
        protected IEnumerable<T> Repository
        {
            get
            {
                lock (_repositoryLock)
                {
                    if (_repository != null) return _repository;
                    _repository = GetRepository();
                    return _repository;
                }
            }
        }

        private IEnumerable<T> GetRepository()
        {
            string dataFileContents = _fileService.ReadAssetFileContents(DataFileName);

            if (string.IsNullOrWhiteSpace(dataFileContents)) return new List<T>();

            return _jsonSerializationService.Deserialize<IEnumerable<T>>(dataFileContents);
        }
    }
}