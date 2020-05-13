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
    public class BrandController : ApiController
    {
        ShopDAL dal = new ShopDAL();
        // GET: api/Brand
        //品牌
        public IEnumerable<Brand> Get()
        {
            return dal.Brands();
        }

        // GET: api/Brand/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Brand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Brand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
