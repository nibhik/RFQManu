using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFQManufactMicroservice.Models
{
    public class SupplierParts
    {

        public int partid { get; set; }
        public int Supplier_id { get; set; }
        public string name { get; set; }
        public string Location { get; set; }
        public int Feedback { get; set; }
    }
}
