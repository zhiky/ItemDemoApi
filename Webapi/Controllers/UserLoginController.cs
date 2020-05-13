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
    public class UserLoginController : ApiController
    {
        LoginDal dal = new LoginDal();
        //登录用户
        // POST: api/Login
        [HttpPost]
        public int UserLogin([FromBody]UserModel m)
        {
            
            return dal.UserLogin(m);
        }
        public UserModel GetUserinfor(string uname)
        {
            return dal.UserLogin(uname);
        }
    }
}
