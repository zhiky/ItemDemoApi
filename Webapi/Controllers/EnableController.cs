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
    public class EnableController : ApiController
    {
        AdproductDal dal = new AdproductDal();
        // GET: api/Enable
        //状态
        public IEnumerable<AdEnable> Get()
        {
            return dal.AdEnable();
        }
        [HttpGet]
        //修改状态
        public int UptSates(int id)
        {
            return dal.UptSate(id);
        }
    }
}
