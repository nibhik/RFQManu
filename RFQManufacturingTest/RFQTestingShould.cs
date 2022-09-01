using NUnit.Framework;
using RFQManufactMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFQManufacturingTest
{
   public class RFQTestingShould
    {
        [Test]
        public void Create_NewRFQ_ViaConstructor()
        {
            //Arrange
            int id = 1;
            int reorderid = 1;
            string partdetails = "details";
            string status = "raised";
            DateTime reorderdate =DateTime.Now;

            //Act
            var rfqdetails = new PartReorderDetails(id,reorderid,partdetails,status,reorderdate);

            //Assert
            Assert.That(rfqdetails, Is.Not.Null);
            Assert.That(rfqdetails, Is.InstanceOf<PartReorderDetails>());
            Assert.That(rfqdetails.PartId, Is.EqualTo(id));
            Assert.That(rfqdetails.PlantReorderId, Is.EqualTo(reorderid));
            Assert.That(rfqdetails.PartDetails, Is.EqualTo(partdetails));
            Assert.That(rfqdetails.ReorderStatus, Is.EqualTo(status));
            Assert.That(rfqdetails.ReorderDate, Is.EqualTo(reorderdate));
        }

        [Test]
        public void Create_NewRFQDetails_ViaConstructor()
        {
            //Arrange
            int rfqid = 1;
            int demandid = 1;
            int partid = 1;
            string partname = "xyz";
            string quantity = "10";
            DateTime timetoSupply = DateTime.Now;
            string specification = "specifications";

            //Act
            var rfqdetails = new Rfq(rfqid,demandid,partid,partname,timetoSupply, quantity,specification);

            //Assert
            Assert.That(rfqdetails, Is.Not.Null);
            Assert.That(rfqdetails, Is.InstanceOf<Rfq>());
            Assert.That(rfqdetails.rfqId, Is.EqualTo(rfqid));
            Assert.That(rfqdetails.demandid, Is.EqualTo(demandid));
            Assert.That(rfqdetails.Part_Id, Is.EqualTo(partid));
            Assert.That(rfqdetails.partName, Is.EqualTo(partname));
            Assert.That(rfqdetails.Quantity, Is.EqualTo(quantity));
            Assert.That(rfqdetails.timetoSupply, Is.EqualTo(timetoSupply));
            Assert.That(rfqdetails.Specification, Is.EqualTo(specification));
        }


    }
}
