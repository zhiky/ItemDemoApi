using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    public class AdproductModel
    {
        public int Pid { get; set; }
        public string Ptupian { get; set; }
        public string Pname { get; set; }
        public int PstoreId { get; set; }
        public int Ptype { get; set; }
        public int Ppinpai { get; set; }
        public int Pkucun { get; set; }
        public double Pprice { get; set; }
        public double Pmarket { get; set; }
        public string Pdanwei { get; set; }
        public string Phuohao { get; set; }
        public string Pguige { get; set; }
        public string Pzhong { get; set; }
        public string Pyunfei { get; set; }
        public int Pstate { get; set; }
        public string Sname { get; set; }
        public string Bname { get; set; }
        public string Stname { get; set; }
        public string Sename { get; set; }
    }
    //商品分类表
    public class AdShopTypes
    {
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Spicture { get; set; }
    }
    //商品品牌表
    public class AdBrand
    {
        public int Bid { get; set; }
        public string Bname { get; set; }
        public string Bpicture { get; set; }
    }
    //店铺表
    public class AdStore
    {
        public int Stid { get; set; }
        public string Stname { get; set; }
    }
    //商品状态表
    public class AdEnable
    {
        public int Seid { get; set; }
        public string Sename { get; set; }
    }
    //下架原因表
    public class Yuanyin
    {
        public int Yid { get; set; }
        public string Yname { get; set; }
    }
    //分页类
    public class AdPageInfor
    {
        public List<AdproductModel> adproductModels { get; set; }
        //当前页
        public int CurrentPage { get; set; }
        //总记录数
        public int TotalCount { get; set; }
        //总页数
        public int TotalPage { get; set; }
    }
}
