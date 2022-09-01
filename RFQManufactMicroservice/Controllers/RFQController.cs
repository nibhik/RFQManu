using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using RFQManufactMicroservice.Context;
using RFQManufactMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RFQManufactMicroservice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RFQController : ControllerBase
    {
        private readonly RFQDbContext _context;
        private readonly ILogger<RFQController> logger;

        public RFQController(RFQDbContext context, ILogger<RFQController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetRFQOfPlant/partid")]  
        public async Task<ActionResult<Rfq>> Get(int Id)
        {
            List<PartReorderDetails> partsReorderDetails = new List<PartReorderDetails>();

            string apiurl = "http://localhost:36207/";
            StringValues value;
            using (var client = new HttpClient())
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out value))
                {
                    var jwt = value.ToString().Split(' ')[1];
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Plant/ViewPartsReOrder");
                    //var response = await repository.GetAllTransports();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        partsReorderDetails = JsonConvert.DeserializeObject<List<PartReorderDetails>>(json);
                    }
                }
                else
                {
                    return Unauthorized();
                }

            }

            List<int> distinctPartList = partsReorderDetails.Select(part => part.PartId).Distinct().ToList();


            //var rec = await _context.RFQ.Where(x => x.Part_Id == Id).Select(x => new Rfq()
            //{
            //    rfqId = x.rfqId,
            //    partName = x.partName,
            //    demandid = x.demandid,
            //    Specification = x.Specification,
            //    Quantity = x.Quantity,
            //    timetoSupply = x.timetoSupply
            //}).ToListAsync();

            List<Rfq> rfqRecords = _context.RFQ.Where(rfqRow => distinctPartList.Contains(rfqRow.Part_Id)).ToList();
            var res = from rfq in rfqRecords
                      join reOrder in partsReorderDetails on rfq.Part_Id equals reOrder.PartId
                      where rfq.Part_Id == Id
                      select new Rfq()
                      {
                          rfqId = rfq.rfqId,
                          partName = rfq.partName,
                          demandid = rfq.demandid,
                          Specification = rfq.Specification,
                          Quantity = rfq.Quantity,
                          timetoSupply = rfq.timetoSupply,
                          Part_Id = rfq.Part_Id
                      };
            if (res.ToList().Count == 0)
            {
                logger.LogWarning("PartId Not Found {0}", DateTime.Now);
                return NotFound();
            }
            return Ok(res);
        }


        [Authorize(Roles ="Admin")]
        [HttpGet("GetPotentialVendorsOfRfq/")]
        
        public async Task<ActionResult<Supplier>> GetFeedback(int rId)
        {
            List<SupplierParts> supparts = new List<SupplierParts>();
           
            string apiurl = "http://localhost:29985/";
            StringValues value;
            using (var client = new HttpClient())
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out value))
                {
                    var jwt = value.ToString().Split(' ')[1];
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                    client.BaseAddress = new Uri(apiurl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Supplier/GetAllSupplierOfPart");
                    //var response = await repository.GetAllTransports();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        supparts = JsonConvert.DeserializeObject<List<SupplierParts>>(json);
                    }
                }
                else
                {
                    return Unauthorized();
                }

            }

            List<int> distinctPartList = supparts.Select(part => part.partid).Distinct().ToList();
            List<int> distinctfeedlist = supparts.Select(part => part.Feedback).ToList();
            List<SupplierParts> rfqRecords = supparts.Where(rfqRow => distinctPartList.Contains(rfqRow.partid) && distinctfeedlist.Contains(rfqRow.Feedback)).ToList();

            List<Rfq> rfq = _context.RFQ.ToList();
            
             var rfqViewModel = from s in rfqRecords
                                   join r in rfq on s.partid equals r.Part_Id
                                   where r.rfqId == rId && s.Feedback > 7
                                   select new { s.partid, r.rfqId, s.name, s.Feedback };

            logger.LogWarning(" Potential Vendors Found", DateTime.Now);
            return Ok(rfqViewModel); 
        }
    }
}
