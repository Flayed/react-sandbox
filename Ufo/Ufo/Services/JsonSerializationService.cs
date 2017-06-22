using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Ufo.Services
{
    public interface IJsonSerializationService
    {
        T Deserialize<T>(string json);
        string Serialize(object obj);
    }

    public class JsonSerializationService : IJsonSerializationService
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}