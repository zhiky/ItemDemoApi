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
    public class LoginController : ApiController
    {
        // GET: api/Login
        LoginDal dal = new LoginDal();
        //管理员显示列表
        [HttpGet]
        public IEnumerable<LoginModel>  GetLoginsShow()
        {
            return dal.LoginShow();
        }
      
        //添加管理员
        // POST: api/Login
        [HttpPost]
        public int AddLogins([FromBody]LoginModel m)
        {
            return dal.AddLogin(m);
        }



    }
}
