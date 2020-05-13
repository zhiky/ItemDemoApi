using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectModel
{
    public class GoodPara
    {
        //string name = "",string pricemin = "",string pricemax = "",int type = 0,int band = 0,int CurrentPage = 1,int PageSize = 2
        public string Name { get; set; }
        public string Pricemin { get; set; }
        public string pricemax { get; set; }
        public int Type { get; set; }
        public int Band { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
