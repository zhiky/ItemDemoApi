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
    public class CarInfor
    {
        string comStr = "Data Source=.;Initial Catalog=Lazy_e_commerce;Integrated Security=True";
        //添加购物车
        public CarinforModel AddShop(int CUId, int CSId, int Ccount)
        {
            //定义输出参数
            var pCode = new SqlParameter("Code1", SqlDbType.Int);
            var pMsg = new SqlParameter("Msg1", SqlDbType.VarChar);
            pMsg.Size = 50;
            //定义输出参数方向
            pCode.Direction = ParameterDirection.Output;
            pMsg.Direction = ParameterDirection.Output;
            //执行存储过程
            string sql = string.Format("exec sp_AddCart {0},'{1}','{2}',@Code1 out,@Msg1 out", CUId, CSId, Ccount);
            var resault = DBHelper.ExecuteNonQuery(sql, new[] { pCode, pMsg });

            //定义实体类
            CarinforModel s = new CarinforModel();
            s.Code = Convert.ToInt32(pCode.Value);
            s.Msg = (pMsg.Value).ToString();

            return s;

        }
        //显示购物车列表
        public PageInfors Carlist(int userid)
        {
            //定义输出参数
            var pShopnum = new SqlParameter("Shopnum1", SqlDbType.Int);
            var pShopprice = new SqlParameter("Shopprice1", SqlDbType.Money);

            //定义输出参数方向
            pShopnum.Direction = ParameterDirection.Output;
            pShopprice.Direction = ParameterDirection.Output;

            //执行存储过程
            string sql = string.Format("exec sp_ShowCart '{0}',@Shopnum1 out,@Shopprice1 out", userid);
            var resault = DBHelper.GetToList<CarinforModel>(sql, new[] { pShopnum, pShopprice });

            var p = new PageInfors();
            p.carinfos = resault;
            p.Shopnum = Convert.ToInt32(pShopnum.Value);

            if (pShopprice.Value.ToString() != "")
            {
                p.Shopprice = Convert.ToDecimal(pShopprice.Value);
            }

            return p;

        }
        //删除购物车
        public int DelCar(int id)
        {
            using (var conn = new SqlConnection(comStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("delete from CartInfo where CId='{0}'", id);
                return cmd.ExecuteNonQuery();
            }
        }
        //清空购物车
        public DelCarinfo ClearCar(int id)
        {
            //定义输出参数
            var pCode = new SqlParameter("Code1", SqlDbType.Int);
            var pMsg = new SqlParameter("Msg1", SqlDbType.VarChar);
            pMsg.Size = 50;
            //定义输出参数方向
            pCode.Direction = ParameterDirection.Output;
            pMsg.Direction = ParameterDirection.Output;
            //执行存储过程
            string sql = string.Format("exec sp_ClearCar '{0}',@Code1 out,@Msg1 out", id);
            var resault = DBHelper.ExecuteNonQuery(sql, new[] { pCode, pMsg });

            DelCarinfo d = new DelCarinfo();
            d.Code = Convert.ToInt32(pCode.Value);
            d.Msg = (pMsg.Value).ToString();

            return d;
        }
        //修改购物车中商品数量（加）
        public DelCarinfo Uptjia(int id)
        {
            //定义输出参数
            var pCode = new SqlParameter("Code1", SqlDbType.Int);
            var pMsg = new SqlParameter("Msg1", SqlDbType.VarChar);
            pMsg.Size = 50;
            //定义输出参数方向
            pCode.Direction = ParameterDirection.Output;
            pMsg.Direction = ParameterDirection.Output;
            //执行存储过程
            string sql = string.Format("exec sp_UptCart '{0}',@Code1 out,@Msg1 out", id);
            var resault = DBHelper.ExecuteNonQuery(sql, new[] { pCode, pMsg });

            DelCarinfo d = new DelCarinfo();
            d.Code = Convert.ToInt32(pCode.Value);
            d.Msg = (pMsg.Value).ToString();

            return d;
        }
        //修改购物车中商品数量（减）
        public DelCarinfo Uptjian(int id)
        {
            //定义输出参数
            var pCode = new SqlParameter("Code1", SqlDbType.Int);
            var pMsg = new SqlParameter("Msg1", SqlDbType.VarChar);
            pMsg.Size = 50;
            //定义输出参数方向
            pCode.Direction = ParameterDirection.Output;
            pMsg.Direction = ParameterDirection.Output;
            //执行存储过程
            string sql = string.Format("exec sp_UptCart1 '{0}',@Code1 out,@Msg1 out", id);
            var resault = DBHelper.ExecuteNonQuery(sql, new[] { pCode, pMsg });

            DelCarinfo d = new DelCarinfo();
            d.Code = Convert.ToInt32(pCode.Value);
            d.Msg = (pMsg.Value).ToString();

            return d;
        }
    }
}
