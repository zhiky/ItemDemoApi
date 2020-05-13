using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    public class GuanOrderModel
    {
        public int OId { get; set; }
        public string OrderNo { get; set; }
        public int UId { get; set; }
        public int PId { get; set; }
        public int StoreId { get; set; }
        public string Ptupian { get; set; }
        public double Pmarket { get; set; }
        public double Pprice { get; set; }
        public string Pyunfei { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public string Uname { get; set; }
        public string Pname { get; set; }
        public decimal heji { get; set; }
        public string Bname { get; set; }
        public string Sname { get; set; }
        public string Stname { get; set; }
    }
    public class GuanOrderPageInfor
    {
        public List<GuanOrderModel> guanOrderModels { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
    }
}
