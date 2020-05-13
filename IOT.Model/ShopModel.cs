using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    //商品列表
    public class ShopModel
    {
        public int Pid     { get; set; }
        public string Ptupian { get; set; }
        public string Pname   { get; set; }
        public int Ptype   { get; set; }
        public int Ppinpai { get; set; }
        public int PstoreId { get; set; }
        public string Stname { get; set; }
        public int Pkucun  { get; set; }
        public double Pprice  { get; set; }
        public double Pmarket { get; set; }
        public string Pdanwei { get; set; }
        public string Phuohao { get; set; }
        public string Pguige  { get; set; }
        public string Pzhong  { get; set; }
        public string Pyunfei { get; set; }
        public bool Pstate { get; set; }
        public string Sname { get; set; }
        public string Bname { get; set; }
    }
    //商品分类表
    public class ShopType
    {
        public int Sid      { get; set; }
        public string Sname    { get; set; }
        public string Spicture { get; set; }
    }
    //商品品牌表
    public class Brand
    {
        public int Bid { get; set; }
        public string Bname { get; set; }
        public string Bpicture { get; set; }
    }
    //历史记录表
    public class historic
    {
        public int Hid   { get; set; }
        public string Hname { get; set; }
    }
    
    //分页类
    public class PageInfor
    {
        public List<ShopModel> shopModels { get; set; }
        //当前页
        public int CurrentPage { get; set; }
        //总记录数
        public int TotalCount { get; set; }
        //总页数
        public int TotalPage { get; set; }
    }
}
