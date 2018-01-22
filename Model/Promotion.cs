using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    public class Promotion
    {
        public int? Id { get; set; }
        public string PromotionId { get; set; }
        public string PromotionName { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PromotionDesc { get; set; }
        public DateTime? AddDate { get; set; }
        public int? AddUserId { get; set; }
        public int? IsDelete { get; set; }
        public string UploadFileUrl { get; set; }
        public int? BoolPrice { get; set; }
        public string ProductLineDatas { get; set; }
        public int? State { get; set; }
        public int? IsConfirmOrder { get; set; }
        public string UpdateFileNames { get; set; }
    }
}
