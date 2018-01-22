using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class ExportOriginalOrderRack
    {
        public int Id { get; set; }
        public int? PromitionId { get; set; }
        public int? StoryBagId { get; set; }
        public int? ShopLevelId { get; set; }
        public string RackIds { get; set; }
    }
}
