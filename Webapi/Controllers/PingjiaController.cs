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
    public class PingjiaController : ApiController
    {
        Pingjia dal = new Pingjia();
        // GET: api/Pingjia
        public  PageStu Get(int CurrentPage = 1, int PageSize = 5)
        {
            var list = dal.Show();
            //if (timeone != null && timetwo != null)
            //{
            //    list = list.Where(s => s.Atime >= timeone && s.Atime <= timetwo).ToList();
            //}
            //if (!string.IsNullOrEmpty(names))
            //{
            //    list = list.Where(s => s.Apname.Contains(names)).ToList();
            //}
            //if (xiala != 0 && xiala != null)
            //{
            //    list = list.Where(s => s.Amessage == xiala).ToList();
            //}
            PageStu ps = new PageStu();//实例化

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
            ps.Amodels = list.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList();
            return ps;
        }

        // GET: api/Pingjia/5
        public PingjiaModel Get(int id)
        {
            return dal.Find(id);
        }

        // POST: api/Pingjia
        public int Post([FromBody]PingjiaModel m)
        {
            return dal.Add(m);
        }
        
    }
}
