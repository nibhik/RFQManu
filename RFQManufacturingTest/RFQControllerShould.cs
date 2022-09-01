using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RFQManufactMicroservice.Context;
using RFQManufactMicroservice.Controllers;
using RFQManufactMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFQManufacturingTest
{
    public class RFQControllerShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1)]
        public void GetReorderdetailsByPartId_Return200(int Id)
        {
            DateTime dateTime = DateTime.Now;
            Rfq rfq = new Rfq() { rfqId = 1 , demandid = 1 , partName = "Part 1" , Part_Id = 1 , Quantity = "10" , Specification = "nothing" , timetoSupply = dateTime  };
            Assert.Pass();
        }


    }
}
