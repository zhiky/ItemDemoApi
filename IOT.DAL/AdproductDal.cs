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
    public class AdproductDal
    {

        //数据库连接字符串
        string comStr = "Data Source=.;Initial Catalog=Lazy_e_commerce;Integrated Security=True";

        //商品列表显示
        public List<AdproductModel> AdShow()
        {
            using (var conn = new SqlConnection(comStr))
            {
                //打开数据库链接
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from GuanProduct join ShopType on GuanProduct.Ptype=ShopType.Sid join Brand on GuanProduct.Ppinpai=Brand.Bid join  Store on GuanProduct.PstoreId = Store.Stid ";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var AdProlist = new List<AdproductModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new AdproductModel();
                    m.Pid = Convert.ToInt32(dr["Pid"]);
                    m.Ptupian = Convert.ToString(dr["Ptupian"]);
                    m.Pname = Convert.ToString(dr["Pname"]);
                    m.PstoreId = Convert.ToInt32(dr["PstoreId"]);
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
                    m.Pstate = Convert.ToInt32(dr["Pstate"]);
                    m.Sname = Convert.ToString(dr["Sname"]);
                    m.Bname = Convert.ToString(dr["Bname"]);
                    m.Stname = Convert.ToString(dr["Stname"]);
                    AdProlist.Add(m);
                }
                return AdProlist;
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

        //绑定店铺列表下拉框
        public List<AdStore> AdBands()
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Store";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var Adstore = new List<AdStore>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new AdStore();
                    m.Stid = Convert.ToInt32(dr["Stid"]);
                    m.Stname = Convert.ToString(dr["Stname"]);
                    Adstore.Add(m);
                }
                return Adstore;
            }
        }

        //绑定状态列表下拉框
        public List<AdEnable> AdEnable()
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from ShopEnable";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                var adEnables = new List<AdEnable>();
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new AdEnable();
                    m.Seid = Convert.ToInt32(dr["Seid"]);
                    m.Sename = Convert.ToString(dr["Sename"]);
                    adEnables.Add(m);
                }
                return adEnables;
            }
        }
        public AdproductModel Fill(int id)
        {
            //using (var conn = new SqlConnection(comStr))
            //{
                string sql = "select * from GuanProduct join ShopType on GuanProduct.Ptype=ShopType.Sid join Brand on GuanProduct.Ppinpai=Brand.Bid join  Store on GuanProduct.PstoreId=Store.Stid where Pid=" + id;
                return DBHelper.GetToList<AdproductModel>(sql).FirstOrDefault();
                //DataTable dt = new DataTable();
                //var da = new SqlDataAdapter(cmd);
                //da.Fill(dt);//填充数据
                //var adlists = new List<AdproductModel>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    var m = new AdproductModel();
                //    m.Pid = Convert.ToInt32(dr["Pid"]);
                //    m.Ptupian = Convert.ToString(dr["Ptupian"]);
                //    m.Pname = Convert.ToString(dr["Pname"]);
                //    m.PstoreId = Convert.ToInt32(dr["PstoreId"]);
                //    m.Ptype = Convert.ToInt32(dr["Ptype"]);
                //    m.Ppinpai = Convert.ToInt32(dr["Ppinpai"]);
                //    m.Pkucun = Convert.ToInt32(dr["Pkucun"]);
                //    m.Pprice = Convert.ToDouble(dr["Pprice"]);
                //    m.Pmarket = Convert.ToDouble(dr["Pmarket"]);
                //    m.Pdanwei = Convert.ToString(dr["Pdanwei"]);
                //    m.Phuohao = Convert.ToString(dr["Phuohao"]);
                //    m.Pguige = Convert.ToString(dr["Pguige"]);
                //    m.Pzhong = Convert.ToString(dr["Pzhong"]);
                //    m.Pyunfei = Convert.ToString(dr["Pyunfei"]);
                //    m.Pstate = Convert.ToInt32(dr["Pstate"]);
                //    m.Sname = Convert.ToString(dr["Sname"]);
                //    m.Bname = Convert.ToString(dr["Bname"]);
                //    m.Stname = Convert.ToString(dr["Stname"]);
                //    m.Sename = Convert.ToString(dr["Sename"]);
                //    adlists.Add(m);
                //}
                //return adlists.FirstOrDefault();
            //}
        }
        //违规下架
        public int UptSate(int id)
        {
            string sql = string.Format("update GuanProduct set Pstate=0 where Pid={0}", id);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //添加下架原因
        public int AddSate(Yuanyin m)
        {
            string sql = string.Format("insert into Yuanyin values('{0}')", m.Yname);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
