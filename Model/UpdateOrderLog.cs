using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class UpdateOrderLog
    {
        public int Id { get; set; }
        public int? PromotionId { get; set; }
        public int? StoryBagId { get; set; }
        public int? AreaId { get; set; }
        public string UpdateMsg { get; set; }
    }
}
