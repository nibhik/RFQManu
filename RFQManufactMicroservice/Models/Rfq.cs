using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RFQManufactMicroservice.Models
{
    public class Rfq
    {
        private int partid;

        [Key]
        public int rfqId { get; set; }
        public int demandid { get; set; }

        [ForeignKey("Part_id")]
        public int Part_Id { get; set; }
        public string partName { get; set; }
        public string Quantity { get; set; }
        public DateTime timetoSupply { get; set; }
        public string Specification { get; set; }

        public static implicit operator Rfq(List<Rfq> v)
        {
            throw new NotImplementedException();
        }

       

        public Rfq(int rfqid, int demandid, int partid, string partname, DateTime timetoSupply, string quantity,string specification)
        {
            rfqId = rfqid;
            this.demandid = demandid;
            this.Part_Id = partid;
            partName = partname;
            this.Quantity = quantity;
            this.timetoSupply = timetoSupply;
            Specification = specification;
        }

        public Rfq() { }
    }
}
