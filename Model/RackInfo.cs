using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class RackInfo
    {
        public int Id { get; set; }
        public int? PositionId { get; set; }
        public string RackType { get; set; }
        public string RackName { get; set; }
        public string Size { get; set; }
        public string Texture { get; set; }
        public string Specification { get; set; }
        public string Units { get; set; }
        public string Category { get; set; }
        public int? StoryBagId { get; set; }
        public int? IsDelete { get; set; }
        public string RackCode { get; set; }
        public decimal? Price { get; set; }
        public int? CountLimit { get; set; }
    }
}
