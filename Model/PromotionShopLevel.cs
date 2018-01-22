using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class PromotionShopLevel
    {
        public int Id { get; set; }
        public string ShopLevelName { get; set; }
        public string ShortName { get; set; }
        public int? RackLimitCount { get; set; }
    }
}
