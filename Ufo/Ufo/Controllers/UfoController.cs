using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Ufo.Models;
using Ufo.Services;

namespace Ufo.Controllers
{
    [RoutePrefix("API/Ufo"), EnableCors(origins: "*", headers:"*", methods:"*")]
    public class UfoController : ApiController
    {
        private readonly IUfoService _ufoService;

        public UfoController(IUfoService ufoService)
        {
            _ufoService = ufoService;
        }

        [HttpGet, Route("MissingPersonStates")]
        public Task<IEnumerable<string>> GetMissingPersonStates()
        {
            return _ufoService.GetMissingPersonCityStates();
        }

        [HttpGet, Route("MissingPersonCities")]
        public Task<IEnumerable<string>> GetMissingPersonCities()
        {
            return _ufoService.GetMissingPersonCities();
        }

        [HttpGet, Route("MissingPersonCities/{cityState}")]
        public Task<IEnumerable<string>> GetMissingPersonCities(string cityState)
        {
            return _ufoService.GetMissingPersonCities(cityState);
        }
    

        [HttpGet, Route("MissingPersons")]
        public async Task<JsonResult<IEnumerable<MissingPerson>>> GetMissingPersons()
        {
            var missingPersons = await _ufoService.GetMissingPersons();
            return Json(missingPersons);
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