using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using WebGrease;
using WebGrease.Activities;

namespace Ufo.Services
{
	public interface IDataService
	{
		Task<string> GetData(string key);
	}

	public class DataService : IDataService
	{
		private readonly IFileService _fileService;
		private readonly string DataFileName = "Data.zip";
		private readonly Dictionary<string, string> _data = new Dictionary<string, string>();
		private readonly Task _initializeTask;

		public DataService(IFileService fileService)
		{
			_fileService = fileService;
			_initializeTask = Task.Run(() =>
			{
				Initialize();
			});
		}

		public async Task<string> GetData(string key)
		{
			await _initializeTask;
			if (_data.ContainsKey(key))
				return _data[key];
			return "";
		}

		private void Initialize()
		{
			using (var zipFileStream = _fileService.GetAssetFileStream(DataFileName))
			{
				try
				{
					var zipFile = new ZipFile(zipFileStream);
					foreach (ZipEntry zipEntry in zipFile)
					{
						string content;
						byte[] buffer = new byte[4096];
						using (Stream zipStream = zipFile.GetInputStream(zipEntry))
						{
							using (MemoryStream ms = new MemoryStream())
							{
								StreamUtils.Copy(zipStream, ms, buffer);

								content = Encoding.UTF8.GetString(ms.ToArray());
							}
						}
						_data.Add(zipEntry.Name, content);
					}
				}
				catch (Exception)
				{
					// ignored
				}
			}
		}
	}
}