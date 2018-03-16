using System;
using System.Collections.Generic;

namespace WebDoAn.Models.DB
{
    public partial class MQuestion
    {
        public string Questioncode { get; set; }
        public string Usercode { get; set; }
        public string Contentquestion { get; set; }
        public string Votenumber { get; set; }
        public string Toppiccode { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string CreateDate { get; set; }
        public string UpDate { get; set; }
    }
}
