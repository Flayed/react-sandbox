using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using Ufo.DbAccess.Configuration;
using Ufo.DbAccess.Models.Entities;

namespace Ufo.Contexts
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UfoContext : DbContext
    {
        public UfoContext()
        {

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UfoContext, UfoConfiguration>());
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<missingperson> MissingPersons { get; set; }
    }
}