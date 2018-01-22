using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class PromotionStorySeat
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public int StoryBagId { get; set; }
        public int SeatId { get; set; }
        public DateTime? AddDate { get; set; }
        public int? AddUserId { get; set; }
    }
}
