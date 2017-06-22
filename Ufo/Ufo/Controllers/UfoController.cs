using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Ufo.Models;
using Ufo.Services;

namespace Ufo.Controllers
{
    [System.Web.Http.RoutePrefix("API/Ufo"), EnableCors(origins: "http://abductions.azurewebsites.net", headers:"*", methods:"*")]
    public class UfoController : ApiController
    {
        private readonly IUfoService _ufoService;

        public UfoController(IUfoService ufoService)
        {
            _ufoService = ufoService;
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("MissingPersonStates")]
        public IEnumerable<string> GetMissingPersonStates()
        {
            return _ufoService.GetMissingPersonCityStates();
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("MissingPersonCities")]
        public IEnumerable<string> GetMissingPersonCities()
        {
            return _ufoService.GetMissingPersonCities();
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("MissingPersonCities/{cityState}")]
        public IEnumerable<string> GetMissingPersonCities(string cityState)
        {
            return _ufoService.GetMissingPersonCities(cityState);
        }
    

        [System.Web.Http.HttpGet, System.Web.Http.Route("MissingPersons")]
        public JsonResult<IEnumerable<MissingPerson>> GetMissingPersons()
        {
            var missingPersons = _ufoService.GetMissingPersons();
            return Json(missingPersons);
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("MissingPersons/{state}")]
        public IEnumerable<MissingPerson> GetMissingPersonsByState(string state)
        {
            return _ufoService.GetMissingPersonsForCityState(state);
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("MissingPersons/{state}/{city}")]
        public IEnumerable<MissingPerson> GetMissingPersonsByCityAndState(string state, string city)
        {
            return _ufoService.GetMissingPersonsForCity(city, state);
        }
    }
}