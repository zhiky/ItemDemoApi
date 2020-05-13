using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOT.DAL;
using IOT.Model;


namespace Webapi.Controllers
{
    public class StoreController : ApiController
    {
        AdproductDal dal = new AdproductDal();
        // GET: api/Store
        public IEnumerable<AdStore> Get()
        {
            return dal.AdBands();
        }

        // GET: api/Store/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Store
        public int Post([FromBody]Yuanyin m)
        {
            return dal.AddSate(m);
        }

        // PUT: api/Store/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Store/5
        public void Delete(int id)
        {
        }
    }
}
