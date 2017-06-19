using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Ufo.Contexts;

namespace Ufo.DbAccess.Configuration
{
    public class UfoConfiguration : DbMigrationsConfiguration<UfoContext>
    {
        public UfoConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}