using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MODEL;
using DAL;

namespace Webapi.Controllers
{
    public class RolesController : ApiController
    {
        LoginDal dal = new LoginDal();
        //角色表
        [HttpGet]
        public IEnumerable<Roles> GetRolesBand()
        {
            return dal.BandRoles();
        }
    }
}
