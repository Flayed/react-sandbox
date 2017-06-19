using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ufo.DbAccess.Models.Entities;

namespace Ufo.Models
{
    public class MissingPerson
    {
        public long Id { get; set; }
        public long? CaseId { get; set; }
        public string Name { get; set; }
        public DateTime? LastSeen { get; set; }
        public string City { get; set; }
        public string CityState { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public long? Age { get; set; }

        public MissingPerson()
        {

        }

        public MissingPerson(missingperson entity)
        {
            Id = entity.id;
            CaseId = entity.caseid;
            Name = entity.name;
            LastSeen = entity.lastseen;
            City = entity.city;
            CityState = entity.citystate;
            Lattitude = entity.lat;
            Longitude = entity.lng;
            Gender = entity.gender;
            Race = entity.race;
            Age = entity.age;
        }
    }
}