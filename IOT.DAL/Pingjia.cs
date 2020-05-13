using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Model;
using System.Data.SqlClient;
using System.Data;

namespace IOT.DAL
{
    public class Pingjia
    {
        string SQL = "Data Source =.; Initial Catalog = Lazy_e_commerce; Integrated Security = True";
        //显示
        public List<PingjiaModel> Show()
        {
            string sql = "select Aid, GuanProduct.Ptupian,GuanProduct.Pname,Sname,Bname,Uname,case Amessage when 1 then '满意' when 2 then '一般' else '不满意' end Amessages, Ainfor,Atime from Ashop join GuanProduct on Ashop.Pid = GuanProduct.Pid join ShopType on GuanProduct.Ptype = ShopType.Sid join Brand on GuanProduct.Ppinpai = Brand.Bid";
            return DBHelper.GetToList<PingjiaModel>(sql);
        }
        //添加
        public int Add(PingjiaModel m)
        {
            string sql = string.Format("insert into Ashop values('{0}','{1}','{2}','{3}','{4}')", m.Pid, m.Uname, m.Amessage, m.Ainfor, m.Atime);
            return DBHelper.ExecuteNonQuery(sql);
        }
        //反填数据
        public PingjiaModel Find(int id)
        {
            string sql = "select Ptupian,Pname,Sname,Bname  from OrderInfo join GuanProduct on OrderInfo.PId=GuanProduct.Pid join ShopType on GuanProduct.Ptype = ShopType.Sid join Brand on GuanProduct.Ppinpai = Brand.Bid where OrderInfo.PId=" + id;
            return DBHelper.GetToList<PingjiaModel>(sql).FirstOrDefault();
        }
        //绑定下拉
        public List<PingjiaModel> Band()
        {
            using (var conn = new SqlConnection(SQL))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select distinct Amessage ,case Amessage when 1 then '满意' when 2 then '一般' else '不满意' end Apj from Ashop  ";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                List<PingjiaModel> amodels = new List<PingjiaModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    PingjiaModel a = new PingjiaModel();
                    a.Apj = dr["Apj"].ToString();
                    a.Amessage = Convert.ToInt32(dr["Amessage"].ToString());
                    amodels.Add(a);
                }
                return amodels;
            }
        }
        //删除评价
        public int Del(int id)
        {
            string sql = "delete from Ashop where Aid=" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
