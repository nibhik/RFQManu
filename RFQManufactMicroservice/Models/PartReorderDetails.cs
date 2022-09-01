using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFQManufactMicroservice.Models
{
    public class PartReorderDetails
    {
        public int PartId { get; set; }
        [Key]
        public int PlantReorderId { get; set; }
        public string PartDetails { get; set; }
        public String ReorderStatus { get; set; }
        public DateTime ReorderDate { get; set; }

        public PartReorderDetails(int partid, int reorderid,string partdetails, string status, DateTime reorderdate)
        {
            this.PartId = partid;
            this.PlantReorderId = reorderid;
            this.PartDetails = partdetails;
            this.ReorderStatus = status;
            this.ReorderDate = reorderdate;
        }
        protected PartReorderDetails() { }
    }
}
