using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class RackLimitCount
    {
        public int Id { get; set; }
        public int? ShopLevelId { get; set; }
        public int? RackSeatId { get; set; }
        public int? Count { get; set; }
        public string ShopType { get; set; }
    }
}
