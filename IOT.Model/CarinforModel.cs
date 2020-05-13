using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    public class CarinforModel
    {
        public int CId    { get; set; }
        public int CUId   { get; set; }
        public int CSId   { get; set; }
        public string Ptupian { get; set; }
        public string Pname { get; set; }
        public int Ptype { get; set; }
        public string Sname { get; set; }
        public string Bname { get; set; }
        public double Pmarket { get; set; }
        public int Ccount { get; set; }
        public decimal Amount { get; set; }
        public double heji { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
    //删除购物车商品and清空购物车and加和减数量
    public class DelCarinfo
    {
        public int Code { get; set; }
        public string Msg { get; set; }
    }
    public class PageInfors
    {
        public List<CarinforModel> carinfos { get; set; }
        public int Shopnum { get; set; }
        public decimal Shopprice { get; set; }
    }
}
