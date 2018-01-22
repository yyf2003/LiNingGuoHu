using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    public class PromotionProductLines
    {
        public int? Id { get; set; }
        public string PromotionId { get; set; }
        public int? ProductLineId { get; set; }
        public int Level { get; set; }
        public string Position { get; set; }
    }
}
