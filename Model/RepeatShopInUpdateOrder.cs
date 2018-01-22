using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class RepeatShopInUpdateOrder
    {
        public int Id { get; set; }
        public int? PromitionId { get; set; }
        public int? StoryBagId { get; set; }
        public string ShopLevel { get; set; }
        public string BigArea { get; set; }
        public string ShopNo { get; set; }
        public int? RepeatNum { get; set; }
    }
}
