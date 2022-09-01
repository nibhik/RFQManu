using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RFQManufactMicroservice.Repository
{
    public class SpecificRepository : IRepository
    {
        public Task<HttpResponseMessage> GetFeeback(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetRFQ(int id)
        {
            throw new NotImplementedException();
        }
    }
}
