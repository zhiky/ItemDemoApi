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
    public class OrderController : ApiController
    {
        // GET: api/Order
        OrderDal dal = new OrderDal();
        //订单列表
        // GET: api/Order
        public OrderPageInfor Get(int Uid, int CurrentPage = 1, int PageSize = 5)
        {
            return dal.OrderList(Uid,CurrentPage,PageSize);
        }
        //添加订单
        // POST: api/Order
        public OrderModel Post([FromBody]OrderModel m)
        {
            return dal.AddOrder(m.PId, m.OrderNo);
        }
        [HttpGet]
        public Return GetTui(int id)
        {
            return dal.Returns(id);
        }

   
    }
}
