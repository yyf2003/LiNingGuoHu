using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    public class Attachment
    {
        public int? Id { get; set; }
        public string ItemId { get; set; }
        public string ItemTypeId { get; set; }
        public string Title { get; set; }
        public string FileCode { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public string SmallImgUrl { get; set; }
        public DateTime? AddDate { get; set; }
        public int? AddUserId { get; set; }
        public int? IsDelete { get; set; }
        public string FileNumber { get; set; }
    }
}
