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
    public class AddUserController : ApiController
    {
        LoginDal dal = new LoginDal();
        //注册用户
        // POST: api/Login
        [HttpPost]
        public int AddUser([FromBody]UserModel m)
        {
            return dal.AddUser(m);
        }
    }
}
