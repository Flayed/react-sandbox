//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ufo.DbAccess.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class missingperson
    {
        public long id { get; set; }
        public Nullable<long> caseid { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> lastseen { get; set; }
        public string city { get; set; }
        public string citystate { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public Nullable<long> age { get; set; }
    }
}
