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
    public class GuanOrderController : ApiController
    {
        GuanOrderDal dal = new GuanOrderDal();
        // GET: api/GuanOrder
        public GuanOrderPageInfor Get(Nullable<DateTime> time1,Nullable<DateTime> time2,string Stnames="",int Ostate=0, int CurrentPage = 1, int PageSize = 5)
        {
            var list = dal.GuanOrderList();
            if (time1!=null && time2!=null)
            {
                list = list.Where(s => s.OrderDate >= time1 && s.OrderDate <= time2).ToList();
            }
            if (!string.IsNullOrEmpty(Stnames))
            {
                list = list.Where(s => s.Stname.Contains(Stnames)).ToList();
            }
            if (Ostate!=0)
            {
                list = list.Where(s => s.OrderStatus == Ostate).ToList();
            }
            GuanOrderPageInfor ps = new GuanOrderPageInfor();//实例化

            ps.TotalCount = list.Count();//总记录数

            if (ps.TotalCount % PageSize == 0)//计算总页数
            {
                ps.TotalPage = ps.TotalCount / PageSize;
            }
            else
            {
                ps.TotalPage = (ps.TotalCount / PageSize) + 1;
            }
            //纠正index页
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > ps.TotalPage)
            {
                CurrentPage = ps.TotalPage;
            }
            //赋值index为当前页
            ps.CurrentPage = CurrentPage;
            //linq查询
            ps.guanOrderModels = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }

        [HttpGet]
        // GET: api/GuanOrder/5
        public GuanOrderModel Gets(int id)
        {
            return dal.GuanOrderxiang(id);
        }
    }
}
