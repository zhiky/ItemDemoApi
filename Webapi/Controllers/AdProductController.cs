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
    public class AdProductController : ApiController
    {
        // GET: api/AdProduct
        AdproductDal dal = new AdproductDal();
        public AdPageInfor Get(string Name = "", int enable = 0, int store = 0, int CurrentPage = 1, int PageSize = 5)
        {
            var list = dal.AdShow();
            if (!string.IsNullOrEmpty(Name))
            {
                list = list.Where(s => s.Pname.Contains(Name)).ToList();
            }
            if (enable != 2)
            {
                list = list.Where(s => s.Pstate == enable).ToList();
            }
            if (store != 0)
            {
                list = list.Where(s => s.PstoreId == store).ToList(); ;
            }
            //实例化分页类
            var p = new AdPageInfor();
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
            p.adproductModels = list.Skip(CurrentPage * (CurrentPage - 1)).Take(PageSize).ToList();

            p.CurrentPage = CurrentPage;
            return p;
        }
            // GET: api/AdProduct/5
         [HttpGet]
        public AdproductModel GetFind(int id)
        {
            return dal.Fill(id);
        }
        

    }
}
