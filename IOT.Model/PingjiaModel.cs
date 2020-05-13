using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Model
{
    //评价表（显示）
    public class PingjiaModel
    {
        public int Aid		 { get; set; }
        public int Pid      { get; set; }
        public string Uname    { get; set; }
        public int Amessage { get; set; }
        public string Amessages { get; set; }
        public string Ainfor   { get; set; }
        public string Ptupian { get; set; }
        public string Pname { get; set; }
        public string Sname { get; set; }
        public string Bname { get; set; }
        public string Apj { get; set; }
        public DateTime Atime { get; set; }
    }
    //分页
    public class PageStu
    {
        public List<PingjiaModel> Amodels { get; set; }

        public int TotalCount { get; set; }//总记录数

        public int TotalPage { get; set; }//总页数

        public int CurrentPage { get; set; }//当前页
    }
}
