using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RFQManufactMicroservice.Repository
{
    public interface IRepository
    {
        Task<HttpResponseMessage> GetRFQ(int id);
        Task<HttpResponseMessage> GetFeeback(int id);
    }
}
