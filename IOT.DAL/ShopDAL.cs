using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using IOT.Model;

namespace IOT.DAL
{
    public class ShopDAL
    {
        //数据库连接字符串
        string comStr = "Data Source=.;Initial Catalog=Lazy_e_commerce;Integrated Security=True";

        //商品列表显示
        public List<ShopModel> Show()
        {
            using (var conn = new SqlConnection(comStr))
            {
                //打开数据库链接
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from GuanProduct join ShopType on GuanProduct.Ptype=ShopType.Sid join Brand on GuanProduct.Ppinpai=Brand.Bid join Store on GuanProduct.PstoreId=Store.Stid";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var Shoplist = new List<ShopModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new ShopModel();
                    m.Pid = Convert.ToInt32(dr["Pid"]);
                    m.Ptupian = Convert.ToString(dr["Ptupian"]);
                    m.Pname = Convert.ToString(dr["Pname"]);
                    m.Ptype = Convert.ToInt32(dr["Ptype"]);
                    m.Ppinpai = Convert.ToInt32(dr["Ppinpai"]);
                    m.Pkucun = Convert.ToInt32(dr["Pkucun"]);
                    m.Pprice = Convert.ToDouble(dr["Pprice"]);
                    m.Pmarket = Convert.ToDouble(dr["Pmarket"]);
                    m.Pdanwei = Convert.ToString(dr["Pdanwei"]);
                    m.Phuohao = Convert.ToString(dr["Phuohao"]);
                    m.Pguige = Convert.ToString(dr["Pguige"]);
                    m.Pzhong = Convert.ToString(dr["Pzhong"]);
                    m.Pyunfei = Convert.ToString(dr["Pyunfei"]);
                    m.Pstate = Convert.ToBoolean(dr["Pstate"]);
                    m.Sname = Convert.ToString(dr["Sname"]);
                    m.Bname = Convert.ToString(dr["Bname"]);
                    m.PstoreId = Convert.ToInt32(dr["PstoreId"]);
                    m.Stname = Convert.ToString(dr["Stname"]);
                    Shoplist.Add(m);
                }
                return Shoplist;
            }
        }
        //绑定分类列表下拉框
        public List<ShopType> shopTypes()
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from ShopType";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var shoptypelist = new List<ShopType>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new ShopType();
                    m.Sid = Convert.ToInt32(dr["Sid"]);
                    m.Sname = Convert.ToString(dr["Sname"]);
                    m.Spicture = Convert.ToString(dr["Spicture"]);
                    shoptypelist.Add(m);
                }
                return shoptypelist;
            }
        }
        //绑定品牌列表下拉框
        public List<Brand> Brands()
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Brand";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var Brands = new List<Brand>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new Brand();
                    m.Bid = Convert.ToInt32(dr["Bid"]);
                    m.Bname = Convert.ToString(dr["Bname"]);
                    m.Bpicture = Convert.ToString(dr["Bpicture"]);
                    Brands.Add(m);
                }
                return Brands;
            }
        }
        //添加历史记录
        public int Add(historic m)
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("insert into historic values('{0}')", m.Hname);
                return cmd.ExecuteNonQuery();
            }
        }
        //显示历史记录
        public List<historic> Shows()
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select distinct Hname from historic";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var historiclist = new List<historic>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new historic();
                    m.Hname = Convert.ToString(dr["Hname"]);
                    historiclist.Add(m);
                }
                return historiclist;
            }
        }
        //商品详情
        public ShopModel Fill(int id)
        {
            using (SqlConnection conn = new SqlConnection(comStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Product join ShopType on Product.Ptype=ShopType.Sid join Brand on Product.Ppinpai=Brand.Bid where Pid=" + id;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                ShopModel p = new ShopModel();
                foreach (DataRow dr in dt.Rows)
                {
                    p.Pid = Convert.ToInt32(dr["Pid"].ToString());
                    p.Bname = dr["Bname"].ToString();
                    p.Sname = dr["Sname"].ToString();
                    p.Ptupian = dr["Ptupian"].ToString();
                    p.Pname = dr["Pname"].ToString();
                    p.Ptype = Convert.ToInt32(dr["Ptype"].ToString());
                    p.Ppinpai = Convert.ToInt32(dr["Ppinpai"].ToString());
                    p.Pkucun = Convert.ToInt32(dr["Pkucun"].ToString());
                    p.Pprice = Convert.ToInt32(dr["Pprice"]);
                    p.Pmarket = Convert.ToInt32(dr["Pmarket"].ToString());
                    p.Pdanwei = dr["Pdanwei"].ToString();
                    p.Phuohao = dr["Phuohao"].ToString();
                    p.Pguige = dr["Pguige"].ToString();
                    p.Pzhong = dr["Pzhong"].ToString();
                    p.Pyunfei = dr["Pyunfei"].ToString();
                    p.Pstate = Convert.ToBoolean(dr["Pstate"].ToString());
                }
                return p;
            }
        }
    }
}
