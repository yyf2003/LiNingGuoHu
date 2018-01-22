using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class RackInShop
    {
        public int Id { get; set; }
        public int? ShopId { get; set; }
        public string PosId { get; set; }
        public int? RackId { get; set; }
        public string Size { get; set; }
        public int? RackCount { get; set; }
        public int? StoryBagId { get; set; }
    }
}
