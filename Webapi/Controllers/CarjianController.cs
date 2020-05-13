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
    public class CarjianController : ApiController
    {
        CarInfor dal = new CarInfor();
        [HttpGet]
        public DelCarinfo Uptjian(int id)
        {
            return dal.Uptjian(id);
        }
    }
}
