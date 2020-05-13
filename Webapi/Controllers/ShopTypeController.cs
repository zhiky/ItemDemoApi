using IOT.DAL;
using IOT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webapi.Controllers
{
    public class ShopTypeController : ApiController
    {
        ShopDAL dal = new ShopDAL();
        // GET: api/ShopType
        public IEnumerable<ShopType> Get()
        {
            return dal.shopTypes();
        }

        // GET: api/ShopType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShopType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShopType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShopType/5
        public void Delete(int id)
        {
        }
    }
}
