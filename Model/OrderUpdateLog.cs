using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class OrderUpdateLog
    {
        public int Id { get; set; }
        public int? PromotionId { get; set; }
        public int? StoryBagId { get; set; }
        public string Region { get; set; }
        public int? RegionId { get; set; }
        public string ShopLevel { get; set; }
        
        public int? TotalRecord { get; set; }
        public int? SuccessNum { get; set; }
        public int? FailNum { get; set; }
        public int? RepeatNum { get; set; }
        public string BigArea { get; set; }
    }
}
