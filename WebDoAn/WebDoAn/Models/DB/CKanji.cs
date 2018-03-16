using System;
using System.Collections.Generic;

namespace WebDoAn.Models.DB
{
    public partial class CKanji
    {
        public string Kanjicode { get; set; }
        public string Onomi { get; set; }
        public string Kunyomi { get; set; }
        public string Hanviet { get; set; }
        public string Nghiaviet { get; set; }
        public string Topiccode { get; set; }
        public string Levelcode { get; set; }
        public string Minacode { get; set; }
        public string Example1 { get; set; }
        public string MeanEx1 { get; set; }
        public string Example2 { get; set; }
        public string MeanEx2 { get; set; }
        public string Example3 { get; set; }
        public string MeanEx3 { get; set; }
        public string Hinhve { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string CreateDate { get; set; }
        public string UpDate { get; set; }
    }
}
