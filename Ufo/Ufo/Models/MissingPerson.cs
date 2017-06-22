using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ufo.Models
{
    public class MissingPerson
    {
        public long Id { get; set; }
        public long? CaseId { get; set; }
        public string Name { get; set; }
        public string LastSeen { get; set; }
        public string City { get; set; }
        public string CityState { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public long? Age { get; set; }

    }
}