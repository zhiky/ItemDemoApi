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
    public class CarInforsController : ApiController
    {
        CarInfor dal = new CarInfor();
        //购物车列表
        // GET: api/CarInfors
        public PageInfors Get(int userid)
        {
            return dal.Carlist(userid);
        }
        //添加购物车
        //POST: api/CarInfors
        public CarinforModel Post([FromBody]CarinforModel m)
        {
            return dal.AddShop(m.CUId, m.CSId, m.Ccount);
        }

        // PUT: api/CarInfors/5
        public DelCarinfo Put([FromBody]int Cid)
        {
            return dal.Uptjia(Cid);
        }
       [HttpGet]
        //删除购物车
        public int DelCar(int id)
        {
            return dal.DelCar(id);
        }
        //清空购物车
        [HttpPost]
        //批量删除
        public int DelCarles(string CId)
        {
            int t = 0;
            CId = CId.Substring(0, CId.Length - 1);//删除字符串最后一个字符
            string[] datalist = CId.Split(',');
            foreach (var item in datalist)
            {
                int daa = int.Parse(item);
                //调用删除方法
                t = t + dal.DelCar(daa);
            }
            return t;
        }
    }
}
