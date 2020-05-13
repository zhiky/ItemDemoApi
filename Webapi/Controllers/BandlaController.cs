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
    public class BandlaController : ApiController
    {
        Pingjia dal = new Pingjia();
        // GET: api/Bandla
        public List<PingjiaModel> Get()
        {
            return dal.Band();
        }
    }
}
