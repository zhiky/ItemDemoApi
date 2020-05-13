using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOT.Model;
using IOT.DAL;

namespace Webapi.Controllers
{
    public class historicController : ApiController
    {
        ShopDAL dal = new ShopDAL();
        Pingjia dals = new Pingjia();
        // GET: api/historic
        //历史记录显示
        public IEnumerable<historic> Get()
        {
            return dal.Shows();
        }

        // POST: api/historic
        //历史记录添加
        public int Post([FromBody]historic m)
        {
            return dal.Add(m);
        }

        [HttpGet]
        //删除评价
        public int Deletes(int id)
        {
            return dals.Del(id);
        }
    }
}
