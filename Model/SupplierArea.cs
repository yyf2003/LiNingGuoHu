using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class SupplierArea
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
    }
}
