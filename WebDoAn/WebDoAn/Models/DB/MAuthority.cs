using System;
using System.Collections.Generic;

namespace WebDoAn.Models.DB
{
    public partial class MAuthority
    {
        public string Authocode { get; set; }
        public string Authoname { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string CreateDate { get; set; }
        public string UpDate { get; set; }
    }
}
