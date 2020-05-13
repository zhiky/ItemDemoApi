using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    public class OrderModel
    {
        public int OId         { get; set; }
        public string OrderNo     { get; set; }
        public int UId         { get; set; }
        public int PId         { get; set; }
        public string Ptupian { get; set; }
        public double Pmarket   { get; set; }
        public int Count     { get; set; }
        public decimal Amount      { get; set; }
        public DateTime  OrderDate   { get; set; }
        public string OrderStatus { get; set; }
        public string Uname { get; set; }
        public string Pname { get; set; }
        public double heji { get; set; }
        public int Code1 { get; set; }
        public string Msg1 { get; set; }
    }
    public class OrderPageInfor
    {
        public List<OrderModel> orderModels { get; set; }
        public int Uid { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public int ShopNum { get; set; }
        public int PriceSum { get; set; }
        public int Balancesum { get; set; }
    }
    //退货
    public class Return
    {
        public List<OrderModel> orderModels { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
