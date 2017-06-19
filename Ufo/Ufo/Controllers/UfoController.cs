using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Ufo.Models;
using Ufo.Services;

namespace Ufo.Controllers
{
    [RoutePrefix("API/Ufo")]
    public class UfoController : ApiController
    {
        private readonly IUfoService _ufoService;

        public UfoController(IUfoService ufoService)
        {
            _ufoService = ufoService;
        }

        [HttpGet, Route("MissingPersonStates")]
        public Task<List<string>> GetMissingPersonStates()
        {
            return _ufoService.GetMissingPersonCityStates();
        }

        [HttpGet, Route("MissingPersonCities")]
        public Task<List<string>> GetMissingPersonCities()
        {
            return _ufoService.GetMissingPersonCities();
        }

        [HttpGet, Route("MissingPersonCities/{cityState}")]
        public Task<List<string>> GetMissingPersonCities(string cityState)
        {
            return _ufoService.GetMissingPersonCities(cityState);
        }
    

        [HttpGet, Route("MissingPersons")]
        public Task<IEnumerable<MissingPerson>> GetMissingPersons()
        {
            return _ufoService.GetMissingPersons();
        }

        [HttpGet, Route("MissingPersons/{state}")]
        public Task<IEnumerable<MissingPerson>> GetMissingPersonsByState(string state)
        {
            return _ufoService.GetMissingPersonsForCityState(state);
        }

        [HttpGet, Route("MissingPersons/{state}/{city}")]
        public Task<IEnumerable<MissingPerson>> GetMissingPersonsByCityAndState(string state, string city)
        {
            return _ufoService.GetMissingPersonsForCity(city, state);
        }
    }
}