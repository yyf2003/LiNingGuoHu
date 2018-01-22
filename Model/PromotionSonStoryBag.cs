using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class PromotionSonStoryBag
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public int ParentStoryBagId { get; set; }
        public string StoryBagName { get; set; }
        public int? IsSon { get; set; }
    }
}
