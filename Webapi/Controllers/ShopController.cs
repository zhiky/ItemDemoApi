using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using IOT.DAL;
using IOT.Model;
using SelectModel;

namespace Webapi.Controllers
{
    public class ShopController : ApiController
    {
        ShopDAL dal = new ShopDAL();
        // GET: api/Shop
        public PageInfor Get(string Name = "", string Pricemin = "", string Pricemax = "", int Type = 0, int Band = 0, int CurrentPage = 1, int PageSize = 5)
        {
            var list = dal.Show().Where(s => s.Pstate = true);
            if (!string.IsNullOrEmpty(Name))
            {
                list = list.Where(s => s.Pname.Contains(Name)).ToList();
            }
            if (!string.IsNullOrEmpty(Pricemin) && !string.IsNullOrEmpty(Pricemax))
            {
                list = list.Where(s => s.Pmarket >= Convert.ToInt32(Pricemin) && s.Pmarket <= Convert.ToInt32(Pricemax)).ToList();
            }
            if (Type != 0)
            {
                list = list.Where(s => s.Ptype == Type).ToList();
            }
            if (Band != 0)
            {
                list = list.Where(s => s.Ppinpai == Band).ToList(); ;
            }
            //实例化分页类
            var p = new PageInfor();
            //总记录数
            p.TotalCount = list.Count();
            //计算总页数
            if (p.TotalCount == 0)
            {
                p.TotalPage = 1;
            }
            else if (p.TotalCount % PageSize == 0)
            {
                p.TotalPage = p.TotalCount / PageSize;
            }
            else
            {
                p.TotalPage = (p.TotalCount / PageSize) + 1;
            }
            //纠正当前页不正确的值
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > p.TotalPage)
            {
                CurrentPage = p.TotalPage;
            }
            p.shopModels = list.Skip(CurrentPage * (CurrentPage - 1)).Take(PageSize).ToList();

            p.CurrentPage = CurrentPage;
            return p;
        }


        //商品详情
        // GET: api/Shop/5
        public ShopModel Getone(int did)
        {
            return dal.Fill(did);
        }

        // POST: api/Shop
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shop/5
        public void Delete(int id)
        {
        }
    }
}
